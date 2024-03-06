import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { provideToastr } from 'ngx-toastr';
import { provideAnimations } from '@angular/platform-browser/animations';
import {
	provideHttpClient,
	withFetch,
	withInterceptorsFromDi,
} from '@angular/common/http';
import { provideStore } from '@ngrx/store';
import { AuthInterceptorProvider } from './core/interceptor/token.interceptor';
import { ErrorInterceptorProvider } from './core/interceptor/error.intercerptor';

export const appConfig: ApplicationConfig = {
	providers: [
		provideRouter(routes),
		provideClientHydration(),
		provideAnimationsAsync(),
		provideHttpClient(withFetch(), withInterceptorsFromDi()),

		// provide interceptor
		AuthInterceptorProvider,
		ErrorInterceptorProvider,

		// provide store
		provideStore(),

		// toasts and animations
		provideAnimations(),
		provideToastr(),
	],
};
