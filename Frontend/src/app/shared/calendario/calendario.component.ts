import { Component, signal, effect, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { buildMonthGrid, visibleRangeISO } from './calendario.util';
import { DiaCell, DiaResumo } from '../../models/calendario.model';
import { ReservaService } from '../../services/reserva-service';
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

  reservasNotebooks = signal<DiaResumo[]>([]);
  reservasLaboratorios = signal<DiaResumo[]>([]);
  reservasSalas = signal<DiaResumo[]>([]);

  private reservasMock: DiaResumo[] = [
    { date: '2025-08-05', total: 3, porTipo: { NOTEBOOK: 2, SALA: 1 } },
    { date: '2025-08-14', total: 5, porTipo: { LABORATORIO: 3, NOTEBOOK: 2 } },
    { date: '2025-08-27', total: 1, porTipo: { SALA: 1 } },
  ];

  constructor(private reservaService: ReservaService) {
    effect(() => {
      const cells = buildMonthGrid(this.year(), this.month0());

      const reservasMap = this.reservasNotebooks().reduce<Record<string, DiaResumo>>((acc, d) => {
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
    this.getReservasNotebookForCalendario();
    this.getReservasLaboratorioForCalendario();
    this.getReservasSalaForCalendario();
  }

  getReservasNotebookForCalendario(): void {
    this.reservaService.getReservasNotebookForCalendario().subscribe((reservasNotebooks) => {
      this.reservasNotebooks.set(reservasNotebooks)
      console.log(reservasNotebooks)
    })
  }

  getReservasLaboratorioForCalendario(): void {
    this.reservaService.getReservasLaboratorioForCalendario().subscribe((reservasLaboratorios) => {
      this.reservasLaboratorios.set(reservasLaboratorios)
      console.log(reservasLaboratorios)
    })
  }

  getReservasSalaForCalendario(): void {
    this.reservaService.getReservasSalaForCalendario().subscribe((reservasSalas) => {
      this.reservasSalas.set(reservasSalas)
      console.log(reservasSalas)
    })
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
