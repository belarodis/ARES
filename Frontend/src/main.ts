import { bootstrapApplication } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import type { ApplicationConfig } from '@angular/core';

import { appConfig } from './app/app.config';
import { App } from './app/app';

const config: ApplicationConfig = {
  ...appConfig,
  providers: [...(appConfig.providers ?? []), provideAnimations()],
};

bootstrapApplication(App, config).catch(err => console.error(err));
