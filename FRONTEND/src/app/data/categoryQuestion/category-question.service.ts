/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryQuestion, CategoryQuestionAddModel, CategoryQuestionUpdateModel } from './categoryQuestion.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class CategoryQuestionService {

	constructor(private api: API) { }

	public getAllCategoryQuestions(): Observable<CategoryQuestion[]> {
		return this.api.GET('/api/CategoryQuestion');
	}

	public create(data: CategoryQuestionAddModel): Observable<any> {
		return this.api.POST('/api/CategoryQuestion', data);
	}

	public updateCategoryQuestion(categoryQuestionId: string,
		newCategoryQuestion: CategoryQuestionUpdateModel): Observable<CategoryQuestion> {
		return this.api.PUT('/api/CategoryQuestion/' + categoryQuestionId, newCategoryQuestion);
	}
}
