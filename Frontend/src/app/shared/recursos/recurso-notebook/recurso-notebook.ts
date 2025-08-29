import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Notebook } from '../../../models/notebook';
import { NotebookService } from '../../../services/notebook-service';
import { ModalEditNotebook } from "../../modal-edit-notebook/modal-edit-notebook";

@Component({
  selector: 'app-recurso-notebook',
  imports: [CommonModule, ModalEditNotebook],
  templateUrl: './recurso-notebook.html',
  styleUrl: '../recurso.css',
})
export class RecursoNotebook {
@Input({ required: true }) notebook!: Notebook;

  constructor(private notebookService: NotebookService) {}

  deletarNotebook(id: number) {
    if (confirm('Tem certeza que deseja excluir este notebook?')) {
      this.notebookService.deleteNotebook(id).subscribe({
        next: () => {
          console.log('Notebook deletado com sucesso!');
          // aqui tu só avisa o pai que esse recurso foi deletado
          window.location.reload();
        },
        error: (err) => console.error('Erro ao deletar notebook:', err),
      });
    }
  }

  isEditVisible: boolean = false;

  abrirModalEdicao() {
    this.isEditVisible = true;
  }

  fecharModalEdicao() {
    this.isEditVisible = false;
  }
}
