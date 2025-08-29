import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-modal-reserva',
  imports: [],
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
}
