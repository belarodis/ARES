import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Laboratorio } from '../models/laboratorio';

@Injectable({
  providedIn: 'root'
})
export class LaboratorioService {
  private apiUrl = 'http://localhost:5229/api/laboratorios';

  constructor(private http: HttpClient) { }

  private handleError(error: any): Observable<never> {
    console.error('Erro na requisição de Laboratório:', error.error);
    return throwError(() => new Error('Falha na operação com Laboratório.'));
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