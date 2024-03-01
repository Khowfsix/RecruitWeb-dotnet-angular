import { Injectable } from '@angular/core';
import {
	HttpInterceptor,
	HttpRequest,
	HttpHandler,
	HttpEvent,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { noTokenURLs } from '../constants/noTokenURLs.constants';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
	intercept(
		req: HttpRequest<unknown>,
		next: HttpHandler,
	): Observable<HttpEvent<unknown>> {
		if (!this.isInWhiteListUrl(req.url)) {
			const authToken = this.getAuthenticationToken();

			if (authToken) {
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

	private getAuthenticationToken() {
		return localStorage.getItem('authToken');
	}

	private isInWhiteListUrl(url: string): boolean {
		// return if url in list no need token
		return noTokenURLs.some((item) => item.startsWith(url));
	}
}
