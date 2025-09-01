import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NotebookService } from '../../services/notebook-service';
import { Notebook } from '../../models/notebook';

@Component({
  selector: 'app-modal-edit-notebook',
  imports: [CommonModule, FormsModule],
  standalone: true,
  templateUrl: './modal-edit-notebook.html',
  styleUrl: './modal-edit-notebook.css',
})
export class ModalEditNotebook {
  @Input() notebook!: Notebook; // recebe o notebook já existente
  @Output() close = new EventEmitter<void>();

  notebookEdit!: Notebook;

  constructor(private notebookService: NotebookService) {}

ngOnInit() {
  // cria cópia do objeto original
  this.notebookEdit = { ...this.notebook };

  // garante que a data original continua igual (sem transformar em Date de novo)
  this.notebookEdit.dataAquisicao = this.notebook.dataAquisicao;
}

salvar() {
  if (!this.notebookEdit?.id) return;

  if (typeof this.notebookEdit.dataAquisicao === 'string') {
  this.notebookEdit.dataAquisicao = new Date(this.notebookEdit.dataAquisicao);
}

  console.log('Enviando notebook editado:', this.notebookEdit);
  console.log('dataAquisicao edit:', typeof this.notebookEdit.dataAquisicao, this.notebookEdit.dataAquisicao);


  this.notebookService.updateNotebook(this.notebookEdit.id, this.notebookEdit).subscribe({
    next: (res) => {
      console.log('Notebook atualizado!', res);
      this.fechar();
      window.location.reload(); // simples por enquanto
    },
    error: (err) => {
      console.error('Erro ao editar notebook:', err);
    }
  });
}

  
  
  fechar() {
    this.close.emit();
  }
}
