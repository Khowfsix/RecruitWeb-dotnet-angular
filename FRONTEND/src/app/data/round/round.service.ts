import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Round } from './round.module';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class RoundService {

	constructor(private api: API) { }

	getAllRounds(): Observable<Round[]> {
		return this.api.GET('/api/Round');
	}

}
