import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Recruiter } from './recruiter.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class RecruiterService {

	constructor(private api: API) { }

	getRecruiterByUserId(userId: string): Observable<Recruiter> {
		return this.api.GET('/api/Recruiter/GetRecruiterByUserId/' + userId);
	}
}
