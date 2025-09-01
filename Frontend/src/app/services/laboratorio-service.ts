import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { forkJoin, Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Laboratorio } from '../models/laboratorio';
import { DiaResumo } from '../models/calendario.model';
import { ReservaLaboratorio } from '../models/reserva-laboratorio';

@Injectable({
  providedIn: 'root',
})
export class LaboratorioService {
  private apiUrl = 'http://localhost:5229/api/laboratorios';
  private apiUrlReservas = 'http://localhost:5229/api/reserva-laboratorios';

  constructor(private http: HttpClient) {}

  private handleError(error: any): Observable<never> {
    console.error('Erro na requisição de Laboratório:', error.error);
    return throwError(() => new Error('Falha na operação com Laboratório.'));
  }

  getDisponiveisPorDia(): Observable<DiaResumo[]> {
    const start = new Date(2025, 5, 1); // Junho
    const end = new Date(2025, 9, 31); // Outubro

    return forkJoin([
      this.http.get<Laboratorio[]>(this.apiUrl),
      this.http.get<ReservaLaboratorio[]>(this.apiUrlReservas),
    ]).pipe(
      map(([laboratorios, reservas]) => {
        const total = laboratorios.length;

        // Mapeia reservas por dia
        const reservasPorDia: { [date: string]: number } = {};
        reservas.forEach((reserva) => {
          const dateKey =
            typeof reserva.dataReserva === 'string'
              ? reserva.dataReserva
              : new Date(reserva.dataReserva).toISOString().split('T')[0];
          reservasPorDia[dateKey] = (reservasPorDia[dateKey] || 0) + 1;
        });

        // Gera todas as datas do período
        const dias: DiaResumo[] = [];
        for (let d = new Date(start); d <= end; d.setDate(d.getDate() + 1)) {
          const dateStr = d.toISOString().split('T')[0];
          const disponiveis = Math.max(0, total - (reservasPorDia[dateStr] || 0));

          dias.push({
            date: dateStr,
            total: disponiveis,
            porTipo: { LABORATORIO: disponiveis },
          });
        }

        return dias;
      }),
      catchError((error) => throwError(() => error))
    );
  }

  getLaboratorios(): Observable<Laboratorio[]> {
    return this.http.get<Laboratorio[]>(this.apiUrl).pipe(catchError(this.handleError));
  }

  getLaboratorio(id: number): Observable<Laboratorio> {
    return this.http.get<Laboratorio>(`${this.apiUrl}/${id}`).pipe(catchError(this.handleError));
  }

  updateLaboratorio(id: number, laboratorio: Laboratorio): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, laboratorio).pipe(catchError(this.handleError));
  }

  addLaboratorio(laboratorio: Laboratorio): Observable<Laboratorio> {
    return this.http.post<Laboratorio>(this.apiUrl, laboratorio).pipe(catchError(this.handleError));
  }

  deleteLaboratorio(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`).pipe(catchError(this.handleError));
  }
}
