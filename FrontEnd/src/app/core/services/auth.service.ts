import { Injectable } from '@angular/core';
import { API } from './../../data/api.service';
import { Observable, first } from 'rxjs';
import { Register } from '../../data/authen/register.model';
import { Login } from '../../data/authen/login.model';
import { noTokenURLs } from '../constants/noTokenURLs.constants';
import { Router } from '@angular/router';

@Injectable({
	providedIn: 'root',
})
export class AuthService {
	constructor(private api: API, private router: Router) {}

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
		this.router.navigate(['/auth/login']);
		localStorage.clear();
	}

	// todo: get current user
	getCurrentUser(): Observable<string[]> {
		return this.api.GET('/api/Authentication/UserLogin');
	}

	getAuthenticationToken(): string | null {
		if (
			typeof localStorage === 'undefined' ||
			localStorage.getItem('loginData') === null
		) {
			return null;
		}
		const loginData: { token: string; expiration: string } = JSON.parse(
			localStorage.getItem('loginData')!,
		);
		return loginData.token;
	}

	isInWhiteListUrl(url: string): boolean {
		// return if url in list no need token
		return noTokenURLs.some((item) => item.startsWith(url));
	}

	isAuthenticated(): boolean {
		if (this.getAuthenticationToken() === null) {
			return false;
		}
		return true;
	}
}
