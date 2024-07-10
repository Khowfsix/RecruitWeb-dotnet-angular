/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CandidateHasSkill } from './candidate-has-skill.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class CandidateHasSkillService {

	constructor(private api: API) { }

	public getAllByCandidateId(candidateId?: string): Observable<CandidateHasSkill[]> {
		return this.api.GET('/api/CandidateHasSkill?candidateId=' + candidateId);
	}
	public getAll(): Observable<CandidateHasSkill[]> {
		return this.api.GET('/api/CandidateHasSkill');
	}
}
