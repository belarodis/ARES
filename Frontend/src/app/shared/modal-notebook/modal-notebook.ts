import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-modal-notebook',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './modal-notebook.html',
  styleUrl: './modal-notebook.css',
})
export class ModalNotebook {
  @Output() close = new EventEmitter<void>();

  fechar() {
    this.close.emit(); // avisa o pai que quer fechar
  }
}
