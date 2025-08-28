import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ReservaLaboratorio } from '../models/reserva-laboratorio';
import { ReservaNotebook } from '../models/reserva-notebook';
import { ReservaSala } from '../models/reserva-sala';

export interface ReservaPayload {
  fkFuncionario: number;
  fkRecurso: number;
  dataReserva: string;
}

@Injectable({
  providedIn: 'root'
})

export class ReservaService {
  private apiUrl = 'http://localhost:5229/api';

  constructor(private http: HttpClient) { }

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

  createNotebookReservation(reserva: { fkFuncionario: number; fkNotebook: number; dataReserva: Date }): Observable<ReservaNotebook> {
    const payload: ReservaPayload = {
      fkFuncionario: reserva.fkFuncionario,
      fkRecurso: reserva.fkNotebook,
      dataReserva: this.toApiDateString(reserva.dataReserva)
    };
    return this.http.post<ReservaNotebook>(`${this.apiUrl}/reservanotebooks`, payload).pipe(
      catchError(this.handleError)
    );
  }

  createSalaReservation(reserva: { fkFuncionario: number; fkSala: number; dataReserva: Date }): Observable<ReservaSala> {
    const payload: ReservaPayload = {
      fkFuncionario: reserva.fkFuncionario,
      fkRecurso: reserva.fkSala,
      dataReserva: this.toApiDateString(reserva.dataReserva)
    };
    return this.http.post<ReservaSala>(`${this.apiUrl}/reservasalas`, payload).pipe(
      catchError(this.handleError)
    );
  }

  createLaboratorioReservation(reserva: { fkFuncionario: number; fkLaboratorio: number; dataReserva: Date }): Observable<ReservaLaboratorio> {
    const payload: ReservaPayload = {
      fkFuncionario: reserva.fkFuncionario,
      fkRecurso: reserva.fkLaboratorio,
      dataReserva: this.toApiDateString(reserva.dataReserva)
    };
    return this.http.post<ReservaLaboratorio>(`${this.apiUrl}/reservalaboratorios`, payload).pipe(
      catchError(this.handleError)
    );
  }
}