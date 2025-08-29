import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FiltroService } from '../../services/filtro.service';
import { NgClass, CommonModule } from '@angular/common';

@Component({
  selector: 'app-modal-reserva',
  imports: [NgClass, CommonModule],
  standalone: true,
  templateUrl: './modal-reserva.html',
  styleUrl: './modal-reserva.css',
})
export class ModalReserva {
  @Output() close = new EventEmitter<void>();
  @Input() data!: string | null;

  fechar() {
    this.close.emit(); // avisa o pai que quer fechar
  }

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
