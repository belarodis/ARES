import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './shared/header/app-header.component';
import { Calendario } from "./shared/calendario/calendario";
import { Gerenciar } from "./shared/gerenciar/gerenciar";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, Calendario, Gerenciar],
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
  standalone: true,
})
export class App {
  protected readonly title = signal('Frontend');
}
