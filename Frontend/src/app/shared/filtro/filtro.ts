import { Component } from '@angular/core';
import { FiltroService } from '../../services/filtro.service';
import { NgClass, CommonModule } from '@angular/common';

@Component({
  selector: 'app-filtro',
  imports: [NgClass, CommonModule],
  standalone: true,
  templateUrl: './filtro.html',
  styleUrl: './filtro.css',
})
export class Filtro {
  tipoAtual: string = '';
  constructor(private filtroService: FiltroService) {}

  //acionado sempre depois que o componente for carregado
  ngOnInit() {
    this.filtroService.tipoSelected$.subscribe((tipo) => {
      this.tipoAtual = tipo;
    });
  }

  //define uma funçção para alterar o tipo selecionado no serviço através do filtro
  selecionar(tipo: string) {
    this.filtroService.setTipoSelected(tipo);
  }
}
