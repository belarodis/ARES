import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Sala } from '../models/sala';

@Injectable({
  providedIn: 'root'
})
export class SalaService {
  private apiUrl = 'http://localhost:5229/api/salas';

  constructor(private http: HttpClient) { }

  private handleError(error: any): Observable<never> {
    console.error('Erro na requisição de Sala:', error.error);
    return throwError(() => new Error('Falha na operação com Sala.'));
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