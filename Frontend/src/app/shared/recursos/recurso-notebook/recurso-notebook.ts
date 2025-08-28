import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Notebook } from '../../../models/notebook';

@Component({
  selector: 'app-recurso-notebook',
  imports: [CommonModule],
  templateUrl: './recurso-notebook.html',
  styleUrl: '../recurso.css'
})
export class RecursoNotebook {
  @Input() notebook?: Notebook; 
}
