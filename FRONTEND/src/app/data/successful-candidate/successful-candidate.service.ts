import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SuccessfulCandidate } from './successful-candidate.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class SuccessfulCandidateService {

	constructor(private api: API) { }

	getAllSuccessfulCandidates(): Observable<SuccessfulCandidate[]> {
		return this.api.GET('/api/SuccessfulCadidate');
	}

}
