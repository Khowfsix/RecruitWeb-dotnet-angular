import { Injectable } from '@angular/core';
import { API } from './../../data/api.service';
import { Observable, first } from 'rxjs';
import { Register } from '../../data/authen/register.model';
import { Login } from '../../data/authen/login.model';
import { noTokenURLs } from '../constants/noTokenURLs.constants';
import { CookieService } from 'ngx-cookie-service';
import { WebUser } from '../../data/authentication/web-user.model';
import { HttpHeaders } from '@angular/common/http';
import { JWT } from '../../data/authen/jwt.model';

@Injectable({
	providedIn: 'root',
})
export class AuthService {
	// clientUserInfo: string | null = window.localStorage.getItem('currentUser') || null;

	constructor(private api: API, private cookieService: CookieService) {
		// afterRender(() => {
		// 	console.log(localStorage);
		// 	this.clientUserInfo = localStorage.getItem('currentUser') != '' ? localStorage.getItem('currentUser') : null;
		// });
	}

	register(registerModel: Register): Observable<unknown> {
		return this.api
			.POST('/api/Authentication/Register', registerModel)
			.pipe(first());
	}

	login(loginModel: Login): Observable<unknown> {
		return this.api.POST('/api/Authentication/Login', loginModel);
	}

	logout() {
		this.api.POST('/api/Authentication/Logout');
		this.cookieService.delete('currentUser');
		this.cookieService.delete('jwt');
		this.cookieService.delete('refreshToken');
	}

	// todo: get current user
	getCurrentUser(): Observable<WebUser | null> {
		return this.api.GET('/api/Authentication/UserLogin');
	}

	getAuthenticationToken(): string | null {
		if (this.cookieService.get('jwt')) {
			return this.cookieService.get('jwt');
		}

		console.log('User has no token');
		return null;
	}

	isInWhiteListUrl(url: string): boolean {
		return noTokenURLs.some((item) => item.startsWith(url));
	}

	async isAuthenticated(): Promise<boolean> {
		return new Promise((resolve) => {
			const user = this.cookieService.get('currentUser');
			// console.log(this.clientUserInfo !== null);
			resolve(user !== null);
		})
	}

	async refreshToken(token: string): Promise<boolean> {
		const refreshToken = this.cookieService.get('refreshToken');
		if (!token && !refreshToken) {
			return false;
		}

		let isRefreshSuccess = false;
		const response = await new Promise<{ jwt: JWT, refreshToken: string }>((resolve, reject) => {
			this.api.POST('Authentication/RefreshToken', {
				headers: new HttpHeaders({
					"Content-Type": "application/json"
				})
			}).subscribe({
				next: (res: { jwt: JWT, refreshToken: string }) => resolve(res),
				error: () => { reject; isRefreshSuccess = false; }
			});
		});


		this.cookieService.set('jwt', JSON.stringify(response.jwt));
		this.cookieService.set('refreshToken', response.refreshToken);
		isRefreshSuccess = true;

		return isRefreshSuccess;
	}
}

