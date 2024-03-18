import { Injectable } from '@angular/core';
import { API } from './../../data/api.service';
import { Observable, first } from 'rxjs';
import { Register } from '../../data/authen/register.model';
import { Login } from '../../data/authen/login.model';
import { noTokenURLs } from '../constants/noTokenURLs.constants';
import { CookieService } from 'ngx-cookie-service';
import { WebUser } from '../../data/authentication/web-user.model';

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

	async refreshToken(): Promise<boolean> {
		/*
			ta đem refresh token
			gọi cho máy chủ trả về json
			new string access token
			cookie lưu lại để xài lần sau

			xem cookie có đang hợp lệ?
			nếu được rồi ta gọi api
			response nếu được hàng 2 - http status code = 200 :v
			lưu token mới, return true nè
		*/
		const refreshToken = this.cookieService.get('refreshToken');
		const accessToken = this.cookieService.get('jwt');
		if (!accessToken && !refreshToken) {
			return false;
		}

		let isRefreshSuccess = false;
		const response = await new Promise<string | null>((resolve, reject) => {
			this.api.POST('Authentication/RefreshToken').subscribe({
				next: (data) => {
					if (data.status === 200) {
						resolve(data.newAccessToken);
					}
					resolve(null);
				},
				error: (error) => {
					reject(error);
				},
			});
		});

		if (!response) {
			return isRefreshSuccess;
		}
		this.cookieService.set('jwt', response);
		isRefreshSuccess = true;

		return isRefreshSuccess;
	}
}

