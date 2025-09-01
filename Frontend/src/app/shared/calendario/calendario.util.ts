// src/app/shared/calendario/calendar.util.ts

import { DiaCell } from '../../models/calendario.model';


function makeUTC(y: number, m: number, d: number) {
  return new Date(Date.UTC(y, m, d));
}
function pad(n: number) { return n < 10 ? `0${n}` : `${n}`; }
export function toISOUTC(d: Date) {
  return `${d.getUTCFullYear()}-${pad(d.getUTCMonth() + 1)}-${pad(d.getUTCDate())}`;
}
export function daysInMonthUTC(y: number, m: number) {
  return new Date(Date.UTC(y, m + 1, 0)).getUTCDate();
}
export function addDaysUTC(base: Date, delta: number) {
  return makeUTC(base.getUTCFullYear(), base.getUTCMonth(), base.getUTCDate() + delta);
}

/** Gera sempre 6 linhas x 7 colunas (42 células). Começa na segunda-feira. */
export function buildMonthGrid(year: number, month0: number): DiaCell[] {
  const first = makeUTC(year, month0, 1);               // 1º dia do mês
  const firstWeekdayMon0 = (first.getUTCDay() + 6) % 7; // dom=0 => 6 ; seg=1 => 0
  const start = addDaysUTC(first, -firstWeekdayMon0);   // início da grade
  const todayISO = toISOUTC(makeUTC(new Date().getFullYear(), new Date().getMonth(), new Date().getDate()));
  const cells: DiaCell[] = [];
  for (let i = 0; i < 42; i++) {
    const d = addDaysUTC(start, i);
    const iso = toISOUTC(d);
    cells.push({
      iso,
      inMonth: d.getUTCMonth() === month0,
      isToday: iso === todayISO
    });
  }
  return cells;
}

/** Retorna o intervalo visível (min/max ISO) para buscar no back. */
export function visibleRangeISO(grid: DiaCell[]) {
  return { start: grid[0].iso, end: grid[grid.length - 1].iso };
}
