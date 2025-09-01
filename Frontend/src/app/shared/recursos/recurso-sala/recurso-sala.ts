import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Sala } from '../../../models/sala'; 

@Component({
  selector: 'app-recurso-sala',
  imports: [CommonModule],
  templateUrl: './recurso-sala.html',
  styleUrl: '../recurso.css'
})
export class RecursoSala {
  @Input() sala?: Sala; 
}
