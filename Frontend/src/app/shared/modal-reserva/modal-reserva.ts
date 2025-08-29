import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FiltroService } from '../../services/filtro.service';
import { NgClass, CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Laboratorio } from '../../models/laboratorio';
import { LaboratorioService } from '../../services/laboratorio-service';
import { Notebook } from '../../models/notebook';
import { NotebookService } from '../../services/notebook-service';
import { Sala } from '../../models/sala';
import { SalaService } from '../../services/sala-service';


@Component({
  selector: 'app-modal-reserva',
  imports: [NgClass, CommonModule, FormsModule],
  standalone: true,
  templateUrl: './modal-reserva.html',
  styleUrl: './modal-reserva.css',
})
export class ModalReserva {
  @Output() close = new EventEmitter<void>();
  @Input() data!: string | null;

  laboratorios: Laboratorio[] = [];
  laboratorioSelecionado?: string;

  notebooks: Notebook[] = [];
  notebookSelecionado?: string;

  salas: Sala[] = [];
  salaSelecionada?: string;

  fechar() {
    this.close.emit(); // avisa o pai que quer fechar
  }

  tipoAtual: string = '';
  constructor(private filtroService: FiltroService, 
              private labService: LaboratorioService, 
              private notebookService: NotebookService,
              private salaService: SalaService) {}

  //acionado sempre depois que o componente for carregado
  ngOnInit() {
    this.filtroService.tipoSelected$.subscribe((tipo) => {
      this.tipoAtual = tipo;
    });

    this.labService.getLaboratorios().subscribe(data => {
      this.laboratorios = data;
    });

    this.notebookService.getNotebooks().subscribe(data => {
      this.notebooks = data;
    })

    this.salaService.getSalas().subscribe(data => {
      this.salas = data; 
    })
  }

  //define uma funçção para alterar o tipo selecionado no serviço através do filtro
  selecionar(tipo: string) {
    this.filtroService.setTipoSelected(tipo);
  }
}
