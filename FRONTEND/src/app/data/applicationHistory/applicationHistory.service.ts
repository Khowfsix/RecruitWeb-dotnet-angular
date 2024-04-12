/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { ApplicationHistory } from './applicationHistory.model';

@Injectable({
	providedIn: 'root'
})
export class ApplicationHistoryService {

	constructor(private api: API) { }

	getByCandidateId(candidateId: string): Observable<ApplicationHistory[]> {
		return this.api.GET('/api/ApplicationHistory/' + candidateId);
	}
}
