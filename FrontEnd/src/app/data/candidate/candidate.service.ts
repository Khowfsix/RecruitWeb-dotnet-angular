/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { Candidate } from './candidate.model';

@Injectable({
	providedIn: 'root'
})
export class CandidateService {

	constructor(private api: API) { }

	getById(candidateId: string): Observable<Candidate> {
		return this.api.GET('/api/Candidate/' + candidateId);
	}

	getAllCandidates(): Observable<Candidate[]> {
		return this.api.GET('/api/Candidate/');
	}
}
