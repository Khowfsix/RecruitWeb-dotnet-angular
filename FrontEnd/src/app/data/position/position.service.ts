/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Position, PositionFilterModel } from './position.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root',
})
export class PositionService {
	constructor(private api: API) { }

	public getAllPositions(
		positionFilterModel?: PositionFilterModel,
		sortString?: string,
		pageIndex?: number,
		pageSize?: number,
		recruiterId?: string
	): Observable<any> {
		let url = '/api/Position?';

		if (recruiterId) {
			url += '&recruiterId=' + recruiterId;
		}

		if (positionFilterModel) {
			url += this.buildQueryParams(positionFilterModel);
		}

		if (sortString) {
			url += `&sortString=${sortString}`;
		}

		if (pageIndex) {
			url += `&pageIndex=${pageIndex}`;
		}

		if (pageSize) {
			url += `&pageSize=${pageSize}`;
		}

		return this.api.GET(url);
	}

	private buildQueryParams(positionFilterModel: PositionFilterModel): string {
		let params = '';
		if (positionFilterModel.userId) {
			params += `&userId=${positionFilterModel.userId}`;
		}
		if (positionFilterModel.negotiatedSalary) {
			params += `&negotiatedSalary=${positionFilterModel.negotiatedSalary}`;
		}
		if (positionFilterModel.search) {
			params += `&search=${encodeURIComponent(positionFilterModel.search.trim())}`;
		}
		if (positionFilterModel.fromSalary !== undefined) {
			params += `&fromSalary=${encodeURIComponent(positionFilterModel.fromSalary)}`;
		}
		if (positionFilterModel.toSalary !== undefined) {
			params += `&toSalary=${encodeURIComponent(positionFilterModel.toSalary)}`;
		}
		if (positionFilterModel.fromMaxHiringQty !== undefined) {
			params += `&fromMaxHiringQty=${encodeURIComponent(positionFilterModel.fromMaxHiringQty)}`;
		}
		if (positionFilterModel.toMaxHiringQty !== undefined) {
			params += `&toMaxHiringQty=${encodeURIComponent(positionFilterModel.toMaxHiringQty)}`;
		}

		if (positionFilterModel.fromDate) {
			params += `&fromDate=${positionFilterModel.fromDate}`;
		}
		if (positionFilterModel.toDate) {
			params += `&toDate=${positionFilterModel.toDate}`;
		}
		if (positionFilterModel.stringOfCategoryPositionIds) {
			params += `&stringOfCategoryPositionIds=${encodeURIComponent(positionFilterModel.stringOfCategoryPositionIds)}`;
		}
		if (positionFilterModel.stringOfCompanyIds) {
			params += `&stringOfCompanyIds=${encodeURIComponent(positionFilterModel.stringOfCompanyIds)}`;
		}
		if (positionFilterModel.stringOfLanguageIds) {
			params += `&stringOfLanguageIds=${encodeURIComponent(positionFilterModel.stringOfLanguageIds)}`;
		}

		return params;
	}

	public getAllPositionsByCurrentUser(): Observable<Position[]> {
		return this.api.GET('/api/Position/CurrentUser');
	}

	public getAllMinMaxRange(): Observable<any> {
		return this.api.GET('/api/Position/GetAllMinMaxRange');
	}

	public getById(id: string): Observable<Position> {
		return this.api.GET(`/api/Position/GetPositionById?positionId=${id}`);
	}

	public create(data: any, options?: any): Observable<any> {
		return this.api.POST('/api/Position', data, options);
	}

	public update(id: string, data: any): Observable<any> {
		return this.api.PUT(`/api/Position/${id}`, data);
	}

	public delete(id: string): Observable<any> {
		return this.api.DELETE('/api/Position/' + id);
	}
}
