/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryPosition } from './category-position.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class CategoryPositionService {

	constructor(private api: API) { }

	getAllCategoryPositions(): Observable<CategoryPosition[]> {
		return this.api.GET('/api/CategoryPosition/GetAllCategoryPositions');
	}

	create(data: any): Observable<any> {
		return this.api.POST('/api/CategoryPosition/CreateCategoryPosition', data);
	}
}
