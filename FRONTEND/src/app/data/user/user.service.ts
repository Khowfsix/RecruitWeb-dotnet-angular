import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class UserService {

	constructor(private api: API) { }

	getAllUsers(): Observable<User[]> {
		return this.api.GET('/api/User');
	}
}
