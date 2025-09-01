import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { forkJoin, Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Notebook } from '../models/notebook';
import { DiaResumo } from '../models/calendario.model';
import { ReservaNotebook } from '../models/reserva-notebook';

@Injectable({
  providedIn: 'root',
})
export class NotebookService {
  private apiUrl = 'http://localhost:5229/api/notebooks';
  private apiUrlReservas = 'http://localhost:5229/api/reserva-notebooks';

  constructor(private http: HttpClient) {}

  private toApiDateString(date: Date): string {
    return date.toISOString().split('T')[0];
  }

  private handleError(error: any): Observable<never> {
    console.error('Erro na requisição de Notebook:', error.error);
    return throwError(() => new Error('Falha na operação com Notebook.'));
  }

  getDisponiveisPorDia(): Observable<DiaResumo[]> {
    const start = new Date(2025, 5, 1); // Junho (mês 5)
    const end = new Date(2025, 9, 31); // Outubro (mês 9)

    return forkJoin([
      this.http.get<Notebook[]>(this.apiUrl),
      this.http.get<ReservaNotebook[]>(this.apiUrlReservas),
    ]).pipe(
      map(([notebooks, reservas]) => {
        const totalNotebooks = notebooks.length;

        // Mapeia reservas por data
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
          const disponiveis = Math.max(0, totalNotebooks - (reservasPorDia[dateStr] || 0));

          dias.push({
            date: dateStr,
            total: disponiveis,
            porTipo: { NOTEBOOK: disponiveis },
          });
        }
        return dias;
      }),
      catchError((error) => throwError(() => error))
    );
  }

  getNotebooks(): Observable<Notebook[]> {
    return this.http.get<Notebook[]>(this.apiUrl).pipe(catchError(this.handleError));
  }

  getNotebook(id: number): Observable<Notebook> {
    return this.http.get<Notebook>(`${this.apiUrl}/${id}`).pipe(catchError(this.handleError));
  }

  addNotebook(notebook: Notebook): Observable<Notebook> {
    const dataToSend = { ...notebook, dataAquisicao: this.toApiDateString(notebook.dataAquisicao) };
    return this.http.post<Notebook>(this.apiUrl, dataToSend).pipe(catchError(this.handleError));
  }

  updateNotebook(id: number, notebook: Notebook): Observable<any> {
    const dataToSend = { ...notebook, dataAquisicao: this.toApiDateString(notebook.dataAquisicao) };
    return this.http.put(`${this.apiUrl}/${id}`, dataToSend).pipe(catchError(this.handleError));
  }

  deleteNotebook(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`).pipe(catchError(this.handleError));
  }
}
