import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SecurityQuestion } from './security-question.module';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class SecurityQuestionService {

	constructor(private api: API) { }

	getAllSecurityQuestions(): Observable<SecurityQuestion[]> {
		return this.api.GET('/api/SecurityQuestion');
	}

}
