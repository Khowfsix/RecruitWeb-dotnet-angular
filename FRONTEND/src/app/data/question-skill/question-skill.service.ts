import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { QuestionSkill } from './question-skill.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class QuestionSkillService {

	constructor(private api: API) { }

	getAllQuestionSkills(): Observable<QuestionSkill[]> {
		return this.api.GET('/api/QuestionSkill');
	}
}
