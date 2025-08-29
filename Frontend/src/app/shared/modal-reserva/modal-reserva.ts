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
import { ReservaService } from '../../services/reserva-service';


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
              private salaService: SalaService,
              private reservaService: ReservaService) {}

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


  // ...existing code...
reservar() {
  if (!this.data) return;

  // Exemplo: pegue o id do funcionário logado (ajuste conforme sua lógica)
  const fkFuncionario = 1; // Troque para o id real do usuário logado

  const dataReserva = new Date(this.data);

  if (this.tipoAtual === 'sala' && this.salaSelecionada) {
    this.reservaService.createSalaReservation({
      fkFuncionario,
      fkSala: Number(this.salaSelecionada),
      dataReserva
    }).subscribe({
      next: () => {
        alert('Reserva realizada com sucesso!');
        this.fechar();
      },
      error: (err) => {
        console.error(err);
        alert('Erro ao tentar reservar.');
      }
    });
  } else if (this.tipoAtual === 'laboratorio' && this.laboratorioSelecionado) {
    this.reservaService.createLaboratorioReservation({
      fkFuncionario,
      fkLaboratorio: Number(this.laboratorioSelecionado),
      dataReserva
    }).subscribe({
      next: () => {
        alert('Reserva realizada com sucesso!');
        this.fechar();
      },
      error: (err) => {
        console.error(err);
        alert('Erro ao tentar reservar.');
      }
    });
  } else if (this.tipoAtual === 'notebook' && this.notebookSelecionado) {
    this.reservaService.createNotebookReservation({
      fkFuncionario,
      fkNotebook: Number(this.notebookSelecionado),
      dataReserva
    }).subscribe({
      next: () => {
        alert('Reserva realizada com sucesso!');
        this.fechar();
      },
      error: (err) => {
        console.error(err);
        alert('Erro ao tentar reservar.');
      }
    });
  } else {
    alert('Selecione um recurso para reservar.');
    return;
  }
  }
}
