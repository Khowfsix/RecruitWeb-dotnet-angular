import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { QuestionLanguage } from './question-language.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class QuestionLanguageService {

	constructor(private api: API) { }

	getAllQuestionLanguages(): Observable<QuestionLanguage[]> {
		return this.api.GET('/api/QuestionLanguage');
	}
}
