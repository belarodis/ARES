import { Component } from '@angular/core';
import { ButtonFuncionario } from "../button-funcionario/button-funcionario";

@Component({
  selector: 'app-header', // nome da tag
  standalone: true, // standalone (sem NgModule)
  templateUrl: './app-header.component.html', // caminho do HTML
  styleUrls: ['./app-header.component.css'],
  imports: [ButtonFuncionario], // caminho do CSS
})
export class HeaderComponent {}
