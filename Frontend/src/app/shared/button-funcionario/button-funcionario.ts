import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Funcionario } from '../../models/funcionario';
import { FuncionarioService } from '../../services/funcionario-service';
import { Form, FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-button-funcionario',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './button-funcionario.html',
  styleUrl: './button-funcionario.css',
})
export class ButtonFuncionario implements OnInit {
  form!: FormGroup;
  public funcionarios: Funcionario[] = [
    {
      id: 1,
      matricula: '2025A001',
      nome: 'Maria Silva',
      cargo: 'Analista de Sistemas',
      dataAdmissao: new Date('2023-03-15'),
      reservasLaboratorio: [],
      reservasNotebook: [],
      reservasSala: [],
    },
  ];

  constructor(private funcionarioService: FuncionarioService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      funcionario: [''],
    });

    this.getFuncionarios();
  }

  getFuncionarios(): void {
    this.funcionarioService.getFuncionarios().subscribe((funcionarios) => {
      this.funcionarios = funcionarios;
    });
  }
}
