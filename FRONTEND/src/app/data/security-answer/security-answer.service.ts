import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SecurityAnswer } from './security-answer.module';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class SecurityAnswerService {

	constructor(private api: API) { }

	getAllSecurityAnswers(): Observable<SecurityAnswer[]> {
		return this.api.GET('/api/SecurityAnswer');
	}

}
