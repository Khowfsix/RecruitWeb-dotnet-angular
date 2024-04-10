/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { Application } from './application.model';

@Injectable({
	providedIn: 'root'
})
export class ApplicationService {

	constructor(private api: API) { }

	getAll(): Observable<Application[]> {
		return this.api.GET('/api/Application');
	}

	getAllByPositionId(positionId?: string, search?: string, sortString?: string, notInBlackList?: boolean): Observable<Application[]> {
		let url = '/api/Application?positionId=' + positionId;
		if (search)
			url = url + '&search=' + search;
		if (sortString)
			url = url + '&sortString=' + sortString;
		if (notInBlackList)
			url = url + '&notInBlackList=' + notInBlackList;
		return this.api.GET(url);
	}
}
