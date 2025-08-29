import { Component, signal, effect, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { buildMonthGrid, visibleRangeISO } from './calendario.util';
import { DiaCell, DiaResumo } from '../../models/calendario.model';
import { ReservaService } from '../../services/reserva-service';
import { NotebookService } from '../../services/notebook-service';
import { LaboratorioService } from '../../services/laboratorio-service';
import { SalaService } from '../../services/sala-service';
import { ModalReserva } from "../modal-reserva/modal-reserva";

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

  constructor(
    private notebookService: NotebookService,
    private laboratorioService: LaboratorioService,
    private salaService: SalaService
  ) {
    effect(() => {
      const cells = buildMonthGrid(this.year(), this.month0());

      const reservasMap = this.availableSalas()
      .filter(d => d.total > 0)
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
    this.getAvailableNotebookForCalendario();
    this.getAvailableLaboratorioForCalendario();
    this.getAvailableSalaForCalendario();
  }

  getAvailableNotebookForCalendario(): void {
    this.notebookService.getDisponiveisPorDia().subscribe((availableNotebooks) => {
      this.availableNotebooks.set(availableNotebooks);
      console.log(availableNotebooks);
    });
  }

  getAvailableLaboratorioForCalendario(): void {
    this.laboratorioService.getDisponiveisPorDia().subscribe((availableLaboratorios) => {
      this.availableLaboratorios.set(availableLaboratorios);
      console.log(availableLaboratorios);
    });
  }

  getAvailableSalaForCalendario(): void {
    this.salaService.getDisponiveisPorDia().subscribe((availableSalas) => {
      this.availableSalas.set(availableSalas);
      console.log(availableSalas);
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
  isVisible: boolean = false
  
  abrirModal(data: string){
    console.log(data);
    this.dataSelecionada = data;
    this.isVisible = true;
  }

  fecharModal(){
    this.isVisible = false;
    this.dataSelecionada = null;
  }

}
