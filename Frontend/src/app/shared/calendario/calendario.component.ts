import { Component, signal, effect } from '@angular/core';
import { CommonModule } from '@angular/common';
import { buildMonthGrid, visibleRangeISO } from './calendario.util';
import { DiaCell, DiaResumo } from '../../models/calendario.model';

@Component({
  selector: 'app-calendario',
  standalone: true,
  templateUrl: './calendario.html',
  styleUrls: ['./calendario.css'],
  imports: [CommonModule],
})
export class CalendarioComponent {
  year = signal(new Date().getFullYear());
  month0 = signal(new Date().getMonth());
  grid = signal<DiaCell[]>([]);

  meses = [
  'Janeiro', 'Fevereiro', 'Março', 'Abril',
  'Maio', 'Junho', 'Julho', 'Agosto',
  'Setembro', 'Outubro', 'Novembro', 'Dezembro'
];


  constructor() {
    effect(() => {
      const cells = buildMonthGrid(this.year(), this.month0());

      const reservasMap = this.reservasMock.reduce<Record<string, DiaResumo>>((acc, d) => {
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


  private reservasMock: DiaResumo[] = [
    { date: '2025-08-05', total: 3, porTipo: { NOTEBOOK: 2, SALA: 1 } },
    { date: '2025-08-14', total: 5, porTipo: { LABORATORIO: 3, NOTEBOOK: 2 } },
    { date: '2025-08-27', total: 1, porTipo: { SALA: 1 } },
  ];

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
}
