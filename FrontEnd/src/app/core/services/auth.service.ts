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
	constructor(private api: API, private cookieService: CookieService) {}

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
		localStorage.removeItem('currentUser');
		this.cookieService.delete('jwt');
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

	isAuthenticated(): boolean {
		return localStorage.getItem('currentUser') !== null;
	}
}
