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

	public getAll(): Observable<CandidateJoinEvent[]> {
		return this.api.GET('/api/CandidateJoinEvent');
	}

	public getAllByCandidateId(candidateId?: string): Observable<CandidateJoinEvent[]> {
		return this.api.GET('/api/CandidateJoinEvent?candidateId=' + candidateId);
	}

	public getAllByEventId(eventId?: string, search?: string): Observable<CandidateJoinEvent[]> {
		let url = '/api/CandidateJoinEvent?eventId=' + eventId;
		if (search) {
			url += '&search=' + search;
		}
		return this.api.GET(url);
	}

	public save(data: any, options?: any) {
		return this.api.POST('/api/CandidateJoinEvent', data, options);
	}

	public delete(candidateJoinEventId: string) {
		return this.api.DELETE('/api/CandidateJoinEvent/' + candidateJoinEventId);
	}
}
