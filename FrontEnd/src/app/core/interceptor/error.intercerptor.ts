import {
	HTTP_INTERCEPTORS,
	HttpEvent,
	HttpHandler,
	HttpInterceptor,
	HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
	providedIn: 'root',
})
class ErrorInterceptor implements HttpInterceptor {
	constructor(private authenticationsService: AuthService) { }
	intercept(
		req: HttpRequest<unknown>,
		next: HttpHandler,
	): Observable<HttpEvent<unknown>> {
		return next.handle(req).pipe(
			catchError((err) => {
				if ([401, 403].indexOf(err.status) !== -1) {
					// auto logout if 401 Unauthorized or 403 Forbidden response returned from api
					const authToken =
						this.authenticationsService.getAuthenticationToken();
					if (authToken) {
						try {
							console.log(`refresh token and recall api`);
							this.authenticationsService.refreshToken();
							return next.handle(req);
						} catch (error) {
							this.authenticationsService.logout();
						}
					}
				}

				const error = err.error || err.statusText;
				return throwError(() => error);
			}),
		);
	}
}

export const ErrorInterceptorProvider = {
	provide: HTTP_INTERCEPTORS,
	useClass: ErrorInterceptor,
	multi: true,
};
