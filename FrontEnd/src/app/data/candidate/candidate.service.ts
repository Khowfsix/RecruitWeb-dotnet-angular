/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { Candidate } from './candidate.model';
import { PersonalDetail } from './personalDetail';
import { WebUser } from '../authentication/web-user.model';

@Injectable({
	providedIn: 'root'
})
export class CandidateService {

	constructor(private api: API) { }

	getById(candidateId: string): Observable<Candidate> {
		return this.api.GET('/api/Candidate/' + candidateId);
	}

	updatePersonalDetail(userId: string, data: PersonalDetail): Observable<WebUser> {
		return this.api.PUT('/api/Candidate/UpdateCandidateProfile/' + userId, data);
	}

	getAllCandidates(): Observable<Candidate[]> {
		return this.api.GET('/api/Candidate');
	}
}
