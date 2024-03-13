import { ApplicationConfig, importProvidersFrom } from '@angular/core';
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
import { CookieService } from 'ngx-cookie-service';
import { NetworkInterceptorProvider } from './core/interceptor/network.interceptor';

export const appConfig: ApplicationConfig = {
	providers: [
		provideRouter(routes),
		provideClientHydration(),
		provideAnimationsAsync(),
		provideHttpClient(withFetch(), withInterceptorsFromDi()),

		// provide interceptor
		AuthInterceptorProvider,
		ErrorInterceptorProvider,
		NetworkInterceptorProvider,

		// provide store
		provideStore(),

		// toasts and animations
		provideAnimations(),
		provideToastr(),

		// cookie service
		importProvidersFrom([CookieService]),
		{ provide: 'LOCALSTORAGE', useFactory: getLocalStorage }
	],
};

export function getLocalStorage() {
	return (typeof window !== "undefined") ? window.localStorage : null;
}
