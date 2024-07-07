/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryPosition, CategoryPositionAddModel, CategoryPositionUpdateModel } from './category-position.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class CategoryPositionService {

	constructor(private api: API) { }

	public getAllCategoryPositions(): Observable<CategoryPosition[]> {
		return this.api.GET('/api/CategoryPosition/GetAllCategoryPositions');
	}

	public create(data: CategoryPositionAddModel): Observable<any> {
		return this.api.POST('/api/CategoryPosition/CreateCategoryPosition', data);
	}

	public updateCategoryPosition(categoryPositionId: string,
		newCategoryPosition: CategoryPositionUpdateModel): Observable<CategoryPosition> {
		return this.api.PUT('/api/CategoryPosition/' + categoryPositionId, newCategoryPosition);
	}
}
