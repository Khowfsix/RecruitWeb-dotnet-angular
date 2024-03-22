import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { WebUser } from './web-user.model';

@Injectable({
	providedIn: 'root'
})
export class AuthenticationService {

	constructor(private api: API) { }

	userLogin(): Observable<WebUser> {
		return this.api.GET('/api/Authentication/UserLogin');
	}
}
