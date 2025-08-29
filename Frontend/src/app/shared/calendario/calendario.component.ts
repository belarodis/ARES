import { Component, signal, effect, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { buildMonthGrid, visibleRangeISO } from './calendario.util';
import { DiaCell, DiaResumo } from '../../models/calendario.model';
import { ReservaService } from '../../services/reserva-service';
import { NotebookService } from '../../services/notebook-service';
import { LaboratorioService } from '../../services/laboratorio-service';
import { SalaService } from '../../services/sala-service';
import { ModalReserva } from '../modal-reserva/modal-reserva';
import { FiltroService } from '../../services/filtro.service';

@Component({
  selector: 'app-calendario',
  standalone: true,
  templateUrl: './calendario.html',
  styleUrls: ['./calendario.css'],
  imports: [CommonModule, ModalReserva],
})
export class CalendarioComponent {
  year = signal(new Date().getFullYear());
  month0 = signal(new Date().getMonth());
  grid = signal<DiaCell[]>([]);

  meses = [
    'Janeiro',
    'Fevereiro',
    'Março',
    'Abril',
    'Maio',
    'Junho',
    'Julho',
    'Agosto',
    'Setembro',
    'Outubro',
    'Novembro',
    'Dezembro',
  ];

  availableNotebooks = signal<DiaResumo[]>([]);
  availableLaboratorios = signal<DiaResumo[]>([]);
  availableSalas = signal<DiaResumo[]>([]);
  diaMaisOcupado = signal<string>('');

  tipoAtual = signal('');
  totalAlocacoesHoje = signal<Record<string, number>>({});

  constructor(
    private notebookService: NotebookService,
    private laboratorioService: LaboratorioService,
    private salaService: SalaService,
    private filtroService: FiltroService,
    private reservaService: ReservaService
  ) {
    effect(() => {
      const cells = buildMonthGrid(this.year(), this.month0());

      const reservasMap = this.tipoSelecionado
        .filter((d) => d.total > 0)
        .reduce<Record<string, DiaResumo>>((acc, d) => {
          acc[d.date] = d;
          return acc;
        }, {});

      this.grid.set(
        cells.map((c) => ({
          ...c,
          resumo: reservasMap[c.iso],
        }))
      );
    });
  }

  ngOnInit(): void {
    this.filtroService.tipoSelected$.subscribe((tipo) => {
      this.tipoAtual.set(tipo);
    });

    this.getAvailableNotebookForCalendario();
    this.getAvailableLaboratorioForCalendario();
    this.getAvailableSalaForCalendario();
    this.getDiaMaisOcupado();
    this.getTotalAlocacoesHoje();
  }

  get tipoSelecionado() {
    if (this.tipoAtual() === 'notebook') {
      return this.availableNotebooks();
    }
    if (this.tipoAtual() === 'laboratorio') {
      return this.availableLaboratorios();
    }
    if (this.tipoAtual() === 'sala') {
      return this.availableSalas();
    }
    return [];
  }

  getTotalAlocacoesHoje() {
    this.reservaService.getAlocacoesHoje().subscribe((totalAlocacoesHoje) => {
      this.totalAlocacoesHoje.set(totalAlocacoesHoje)
      console.log(totalAlocacoesHoje)
    })
  }

  getDiaMaisOcupado() {
    this.reservaService.getDiaMaisOcupadoTodas().subscribe((diaMaisOcupado) => {
      this.diaMaisOcupado.set(diaMaisOcupado);
      console.log(diaMaisOcupado);
    });
  }

  getAvailableNotebookForCalendario(): void {
    this.notebookService.getDisponiveisPorDia().subscribe((availableNotebooks) => {
      this.availableNotebooks.set(availableNotebooks);
    });
  }

  getAvailableLaboratorioForCalendario(): void {
    this.laboratorioService.getDisponiveisPorDia().subscribe((availableLaboratorios) => {
      this.availableLaboratorios.set(availableLaboratorios);
    });
  }

  getAvailableSalaForCalendario(): void {
    this.salaService.getDisponiveisPorDia().subscribe((availableSalas) => {
      this.availableSalas.set(availableSalas);
    });
  }

  prevMonth() {
    let y = this.year();
    let m = this.month0() - 1;
    if (m < 0) {
      m = 11;
      y--;
    }
    this.year.set(y);
    this.month0.set(m);
  }

  nextMonth() {
    let y = this.year();
    let m = this.month0() + 1;
    if (m > 11) {
      m = 0;
      y++;
    }
    this.year.set(y);
    this.month0.set(m);
  }

  dataSelecionada: string | null = null;
  isVisible: boolean = false;

  abrirModal(data: string) {
    console.log(data);
    this.dataSelecionada = data;
    this.isVisible = true;
  }

  fecharModal() {
    this.isVisible = false;
    this.dataSelecionada = null;
  }
}
