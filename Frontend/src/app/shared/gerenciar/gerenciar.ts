import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Laboratorio } from '../../models/laboratorio';
import { LaboratorioService } from '../../services/laboratorio-service';
import { Sala } from '../../models/sala';
import { SalaService } from '../../services/sala-service';
import { Notebook } from '../../models/notebook';
import { NotebookService } from '../../services/notebook-service';
import { RecursoNotebook } from "../recursos/recurso-notebook/recurso-notebook";
import { RecursoSala } from '../recursos/recurso-sala/recurso-sala';
import { RecursoLaboratorio } from '../recursos/recurso-laboratorio/recurso-laboratorio';

@Component({
  selector: 'app-gerenciar',
  imports:  [CommonModule, RecursoNotebook, RecursoSala, RecursoLaboratorio],
  standalone: true,
  templateUrl: './gerenciar.html',
  styleUrl: './gerenciar.css'
})
export class Gerenciar {
  laboratorios: Laboratorio[] = [];
  notebooks: Notebook[] = [];
  salas: Sala[] = [];

  constructor(private laboratorioService: LaboratorioService, 
              private notebookService: NotebookService,
              private salaService: SalaService
  ) {}

  ngOnInit() {
    this.laboratorioService.getLaboratorios().subscribe((data) => {
      this.laboratorios = data;
      console.log('Notebooks:', this.notebooks);
    });

    this.notebookService.getNotebooks().subscribe((data) =>{
      this.notebooks = data;
    });

    this.salaService.getSalas().subscribe((data) =>{
      this.salas = data;
    });
  }
}
