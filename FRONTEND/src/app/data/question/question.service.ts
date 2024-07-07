/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root',
})
export class QuestionService {
	constructor(private api: API) { }

	public getAll(): Observable<any> {
		const url = '/api/Question';
		return this.api.GET(url);
	}
}
