import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Recruiter, RecruiterAddModel } from './recruiter.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class RecruiterService {

	constructor(private api: API) { }

	public getAll(): Observable<Recruiter[]> {
		return this.api.GET('/api/Recruiter/GetAllRecruiter');
	}

	public getNotDeletedRecruiterByUserId(userId?: string): Observable<Recruiter> {
		let url = '/api/Recruiter/GetRecruiterByUserId/' + userId;
		url += '?isDeleted=' + false;
		return this.api.GET(url);
	}

	public getRecruiterByUserId(userId: string): Observable<Recruiter> {
		const url = '/api/Recruiter/GetRecruiterByUserId/' + userId;
		return this.api.GET(url);
	}

	UpdateStatus(recruiterId?: string, isActived?: boolean, isDeleted?: boolean) {
		const url = `/api/Recruiter/UpdateStatus/${recruiterId}?isActived=${isActived}&isDeleted=${isDeleted}`
		return this.api.PUT(url);
	}

	public saveRecruiter(addModel: RecruiterAddModel): Observable<Recruiter> {
		return this.api.POST('/api/Recruiter/SaveRecruiter', addModel)
	}
}
