import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './shared/header/app-header.component';
import { CalendarioComponent } from './shared/calendario/calendario.component';
import { Gerenciar } from './shared/gerenciar/gerenciar';
import { Filtro } from "./shared/filtro/filtro";
import { ButtonNovoRecurso } from "./shared/button-novo-recurso/button-novo-recurso";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, CalendarioComponent, Gerenciar, Filtro, ButtonNovoRecurso],
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
  standalone: true,
})
export class App {
  protected readonly title = signal('Frontend');
}
