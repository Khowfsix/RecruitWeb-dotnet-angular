import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Award } from './award.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class AwardService {

	constructor(private api: API) { }

	getAllAwards(): Observable<Award[]> {
		return this.api.GET('/api/Award');
	}
}
