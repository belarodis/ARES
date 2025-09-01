import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Funcionario } from '../../models/funcionario';
import { FuncionarioService } from '../../services/funcionario-service';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-button-funcionario',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './button-funcionario.html',
  standalone: true,
  styleUrl: './button-funcionario.css',
})
export class ButtonFuncionario implements OnInit {
  form!: FormGroup;
  public funcionarios: Funcionario[] = [];

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
