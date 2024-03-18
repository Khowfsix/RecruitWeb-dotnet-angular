import { Injectable } from '@angular/core';
import {
	HttpInterceptor,
	HttpRequest,
	HttpHandler,
	HttpEvent,
	HTTP_INTERCEPTORS,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
	providedIn: 'root',
})
class AuthInterceptor implements HttpInterceptor {
	constructor(private authService: AuthService) { }

	intercept(
		req: HttpRequest<unknown>,
		next: HttpHandler,
	): Observable<HttpEvent<unknown>> {
		if (!this.authService.isInWhiteListUrl(req.url)) {
			const authToken = this.authService.getAuthenticationToken();

			if (authToken !== null) {
				req = req.clone({
					headers: req.headers.set(
						'Authorization',
						`Bearer ${authToken}`,
					),
				});
			}
		}

		// Gửi request đã được chỉnh sửa hoặc request gốc nếu không có token
		return next.handle(req);
	}
}

export const AuthInterceptorProvider = {
	provide: HTTP_INTERCEPTORS,
	useClass: AuthInterceptor,
	multi: true,
};
