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
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Injectable({
	providedIn: 'root',
})
class ErrorInterceptor implements HttpInterceptor {
	constructor(
		private authenticationsService: AuthService,
		private toastService: ToastrService,
		private router: Router
	) { }
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

				if ([500].indexOf(err.status) !== -1) {
					this.toastService.error("Error! An error occurred. Please try again later", "Transmission error", {
						progressBar: true,
						timeOut: 3000,
					});

					this.router.navigate(['/']);
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
