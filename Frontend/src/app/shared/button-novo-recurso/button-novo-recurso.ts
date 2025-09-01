import { Component } from '@angular/core';
import { ModalNotebook } from '../modal-notebook/modal-notebook';

@Component({
  selector: 'app-button-novo-recurso',
  imports: [ModalNotebook],
  templateUrl: './button-novo-recurso.html',
  styleUrl: './button-novo-recurso.css',
})
export class ButtonNovoRecurso {
  isVisible: boolean = false;

  abrirModal() {
    this.isVisible = true;
  }

  fecharModal() {
    this.isVisible = false;
  }
}
