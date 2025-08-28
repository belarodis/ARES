import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './shared/header/app-header.component';
import { CalendarioComponent } from './shared/calendario/calendario.component';
import { Gerenciar } from './shared/gerenciar/gerenciar';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, CalendarioComponent, Gerenciar],
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
  standalone: true,
})
export class App {
  protected readonly title = signal('Frontend');
}
