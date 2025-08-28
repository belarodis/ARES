// filtro.service.ts
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class FiltroService {
  private tipoSelectedSource = new BehaviorSubject<string>('notebook'); 
  tipoSelected$ = this.tipoSelectedSource.asObservable();

  setTipoSelected(tipo: string) {
    this.tipoSelectedSource.next(tipo);
  }
}
