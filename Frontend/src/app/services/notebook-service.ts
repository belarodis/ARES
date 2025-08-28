import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Notebook } from '../models/notebook'; 

@Injectable({
  providedIn: 'root'
})
export class NotebookService {
  private apiUrl = 'http://localhost:5229/api/notebooks';

  constructor(private http: HttpClient) { }

  private toApiDateString(date: Date): string {
    return date.toISOString().split('T')[0];
  }

  private handleError(error: any): Observable<never> {
    console.error('Erro na requisição de Notebook:', error.error);
    return throwError(() => new Error('Falha na operação com Notebook.'));
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