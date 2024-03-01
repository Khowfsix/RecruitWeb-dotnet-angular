import { Injectable } from '@angular/core';
import { API } from './../../data/api.service';
import { Observable } from 'rxjs';
import { Register } from '../../data/authen/register.model';
import { Login } from '../../data/authen/login.model';

@Injectable({
	providedIn: 'root',
})
export class AuthService {
	constructor(private API: API) {}

	register(registerModel: Register): Observable<unknown> {
		return this.API.POST('/api/Authentication/Register', registerModel);
	}

	login(loginModel: Login): Observable<unknown> {
		return this.API.POST('/api/Authentication/Login', loginModel);
	}

	// todo: get current user
	getCurrentUser(): Observable<unknown> {
		return this.API.GET('/api/Authentication/UserLogin');
	}
}
