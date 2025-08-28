import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

export interface ReservaStatusDto {
  dataReserva: string;
  tipoRecurso: string;
  nomeRecurso: string;
  funcionarioNome: string;
}

export interface BusiestDayDto {
  data: string;
  totalReservas: number;
}

@Injectable({
  providedIn: 'root'
})
export class StatusService {
  private apiUrl = 'http://localhost:5229/api/status';

  constructor(private http: HttpClient) { }

  private toApiDateString(date: Date): string {
    return date.toISOString().split('T')[0];
  }

  private handleError(error: any): Observable<never> {
    console.error('Erro na requisição de status:', error.error);
    return throwError(() => new Error('Falha ao buscar dados de status.'));
  }

  getReservationsByPeriod(startDate: Date, endDate: Date): Observable<ReservaStatusDto[]> {
    const params = new HttpParams()
      .set('startDate', this.toApiDateString(startDate))
      .set('endDate', this.toApiDateString(endDate));
    return this.http.get<ReservaStatusDto[]>(this.apiUrl, { params }).pipe(
      catchError(this.handleError)
    );
  }

  getBusiestDays(startDate: Date, endDate: Date): Observable<BusiestDayDto[]> {
    const params = new HttpParams()
      .set('startDate', this.toApiDateString(startDate))
      .set('endDate', this.toApiDateString(endDate));
    return this.http.get<BusiestDayDto[]>(`${this.apiUrl}/busiest-days`, { params }).pipe(
      catchError(this.handleError)
    );
  }
}