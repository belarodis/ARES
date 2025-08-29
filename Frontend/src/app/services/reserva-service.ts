import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ReservaLaboratorio } from '../models/reserva-laboratorio';
import { ReservaNotebook } from '../models/reserva-notebook';
import { ReservaSala } from '../models/reserva-sala';
import { DiaResumo } from '../models/calendario.model';

export interface ReservaPayload {
  fkFuncionario: number;
  fkRecurso: number;
  dataReserva: string;
}

@Injectable({
  providedIn: 'root',
})
export class ReservaService {
  private apiUrlNotebooks = 'http://localhost:5229/api/reserva-notebooks';
  private apiUrlLaboratorios = 'http://localhost:5229/api/reserva-laboratorios';
  private apiUrlSalas = 'http://localhost:5229/api/reserva-salas';

  constructor(private http: HttpClient) {}

  private handleError(error: HttpErrorResponse): Observable<never> {
    if (error.status === 400 && typeof error.error === 'string') {
      return throwError(() => new Error(error.error));
    }
    console.error('Um erro desconhecido ocorreu:', error.error);
    return throwError(() => new Error('Ocorreu um erro desconhecido. Tente novamente.'));
  }

  private toApiDateString(date: Date): string {
    return date.toISOString().split('T')[0];
  }

  getReservasNotebookForCalendario(): Observable<DiaResumo[]> {
    return this.http.get<ReservaNotebook[]>(this.apiUrlNotebooks).pipe(
      map((reservas: ReservaNotebook[]) => {
        const resumoPorDia: { [date: string]: DiaResumo } = {};

        reservas.forEach((reserva) => {
          const dateKey =
            typeof reserva.dataReserva === 'string'
              ? reserva.dataReserva
              : new Date(reserva.dataReserva).toISOString().split('T')[0];

          if (!resumoPorDia[dateKey]) {
            resumoPorDia[dateKey] = {
              date: dateKey,

              total: 0,

              porTipo: { NOTEBOOK: 0 },
            };
          }

          resumoPorDia[dateKey].total += 1;

          resumoPorDia[dateKey].porTipo.NOTEBOOK =
            (resumoPorDia[dateKey].porTipo.NOTEBOOK || 0) + 1;
        });

        return Object.values(resumoPorDia);
      }),

      catchError(this.handleError)
    );
  }

  getReservasLaboratorioForCalendario(): Observable<DiaResumo[]> {
    return this.http.get<ReservaLaboratorio[]>(this.apiUrlLaboratorios).pipe(
      map((reservas: ReservaLaboratorio[]) => {
        const resumoPorDia: { [date: string]: DiaResumo } = {};

        reservas.forEach((reserva) => {
          const dateKey =
            typeof reserva.dataReserva === 'string'
              ? reserva.dataReserva
              : new Date(reserva.dataReserva).toISOString().split('T')[0];

          if (!resumoPorDia[dateKey]) {
            resumoPorDia[dateKey] = {
              date: dateKey,

              total: 0,

              porTipo: { LABORATORIO: 0 },
            };
          }

          resumoPorDia[dateKey].total += 1;

          resumoPorDia[dateKey].porTipo.LABORATORIO =
            (resumoPorDia[dateKey].porTipo.LABORATORIO || 0) + 1;
        });

        return Object.values(resumoPorDia);
      }),

      catchError(this.handleError)
    );
  }

  getReservasSalaForCalendario(): Observable<DiaResumo[]> {
    return this.http.get<ReservaSala[]>(this.apiUrlSalas).pipe(
      map((reservas: ReservaSala[]) => {
        const resumoPorDia: { [date: string]: DiaResumo } = {};

        reservas.forEach((reserva) => {
          const dateKey =
            typeof reserva.dataReserva === 'string'
              ? reserva.dataReserva
              : new Date(reserva.dataReserva).toISOString().split('T')[0];

          if (!resumoPorDia[dateKey]) {
            resumoPorDia[dateKey] = {
              date: dateKey,

              total: 0,

              porTipo: { SALA: 0 },
            };
          }

          resumoPorDia[dateKey].total += 1;

          resumoPorDia[dateKey].porTipo.SALA = (resumoPorDia[dateKey].porTipo.SALA || 0) + 1;
        });

        return Object.values(resumoPorDia);
      }),

      catchError(this.handleError)
    );
  }

  createNotebookReservation(reserva: {
    fkFuncionario: number;
    fkNotebook: number;
    dataReserva: Date;
  }): Observable<ReservaNotebook> {
    const payload: ReservaPayload = {
      fkFuncionario: reserva.fkFuncionario,
      fkRecurso: reserva.fkNotebook,
      dataReserva: this.toApiDateString(reserva.dataReserva),
    };
    return this.http
      .post<ReservaNotebook>(`${this.apiUrlNotebooks}/reserva-notebooks`, payload)
      .pipe(catchError(this.handleError));
  }

  createSalaReservation(reserva: {
    fkFuncionario: number;
    fkSala: number;
    dataReserva: Date;
  }): Observable<ReservaSala> {
    const payload: ReservaPayload = {
      fkFuncionario: reserva.fkFuncionario,
      fkRecurso: reserva.fkSala,
      dataReserva: this.toApiDateString(reserva.dataReserva),
    };
    return this.http
      .post<ReservaSala>(`${this.apiUrlSalas}/reserva-salas`, payload)
      .pipe(catchError(this.handleError));
  }

  createLaboratorioReservation(reserva: {
    fkFuncionario: number;
    fkLaboratorio: number;
    dataReserva: Date;
  }): Observable<ReservaLaboratorio> {
    const payload: ReservaPayload = {
      fkFuncionario: reserva.fkFuncionario,
      fkRecurso: reserva.fkLaboratorio,
      dataReserva: this.toApiDateString(reserva.dataReserva),
    };
    return this.http
      .post<ReservaLaboratorio>(`${this.apiUrlLaboratorios}/reserva-laboratorios`, payload)
      .pipe(catchError(this.handleError));
  }
}
