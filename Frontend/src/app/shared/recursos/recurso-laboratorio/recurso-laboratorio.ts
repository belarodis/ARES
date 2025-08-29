import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Laboratorio } from '../../../models/laboratorio';

@Component({
  selector: 'app-recurso-laboratorio',
  imports: [CommonModule],
  templateUrl: './recurso-laboratorio.html',
  styleUrl: '../recurso.css',
})
export class RecursoLaboratorio {
  @Input() laboratorio?: Laboratorio;

  showTooltip = false;
  tooltipX = 0;
  tooltipY = 0;

  onMouseMove(event: MouseEvent) {
    this.tooltipX = event.clientX + 12;
    this.tooltipY = event.clientY + 12;
  }
}
