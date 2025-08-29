import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { forkJoin, Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Sala } from '../models/sala';
import { DiaResumo } from '../models/calendario.model';
import { ReservaSala } from '../models/reserva-sala';

@Injectable({
  providedIn: 'root',
})
export class SalaService {
  private apiUrl = 'http://localhost:5229/api/salas';
  private apiUrlReservas = 'http://localhost:5229/api/reserva-salas';

  constructor(private http: HttpClient) {}

  private handleError(error: any): Observable<never> {
    console.error('Erro na requisição de Sala:', error.error);
    return throwError(() => new Error('Falha na operação com Sala.'));
  }

  getDisponiveisPorDia(): Observable<DiaResumo[]> {
    const start = new Date(2025, 5, 1); // Junho
    const end = new Date(2025, 9, 31); // Outubro

    return forkJoin([
      this.http.get<Sala[]>(this.apiUrl),
      this.http.get<ReservaSala[]>(this.apiUrlReservas),
    ]).pipe(
      map(([salas, reservas]) => {
        const total = salas.length;

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
            porTipo: { SALA: disponiveis },
          });
        }

        return dias;
      }),
      catchError((error) => throwError(() => error))
    );
  }

  getSalas(): Observable<Sala[]> {
    return this.http.get<Sala[]>(this.apiUrl).pipe(catchError(this.handleError));
  }

  getSala(id: number): Observable<Sala> {
    return this.http.get<Sala>(`${this.apiUrl}/${id}`).pipe(catchError(this.handleError));
  }

  updateSala(id: number, sala: Sala): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, sala).pipe(catchError(this.handleError));
  }

  addSala(sala: Sala): Observable<Sala> {
    return this.http.post<Sala>(this.apiUrl, sala).pipe(catchError(this.handleError));
  }

  deleteSala(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`).pipe(catchError(this.handleError));
  }
}
