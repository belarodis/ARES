import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NotebookService } from '../../services/notebook-service';
import { Notebook } from '../../models/notebook';


@Component({
  selector: 'app-modal-notebook',
  imports: [CommonModule, FormsModule],
  standalone: true,
  templateUrl: './modal-notebook.html',
  styleUrl: './modal-notebook.css',
})
export class ModalNotebook {
  @Output() close = new EventEmitter<void>();

  fechar() {
    this.close.emit(); // avisa o pai que quer fechar
  }

  // objeto notebook ligado ao form
notebook: Notebook = {
  id: 0, // pode ser 0, o back gera o id
  nPatrimonio: '',
  descricao: '',
  dataAquisicao: new Date() // ou deixa o usuário preencher
};

  constructor(private notebookService: NotebookService) {}

salvar() {
  console.log('Notebook preenchido:', this.notebook);

  this.notebookService.addNotebook(this.notebook).subscribe({
    next: (res: Notebook) => {
      console.log('Notebook salvo!', res);
      this.fechar();
      window.location.reload();
    },
    error: (err) => console.error('Erro ao salvar notebook:', err)
  });
}

}
