/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CandidateJoinEvent } from './candidate-join-event.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class CandidateJoinEventService {

	constructor(private api: API) { }

	getAllByCandidateId(candidateId?: string): Observable<CandidateJoinEvent[]> {
		return this.api.GET('/api/CandidateJoinEvent?candidateId=' + candidateId);
	}
}
