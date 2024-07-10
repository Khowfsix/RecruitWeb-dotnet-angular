/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { BlackList, BlackListAddModel } from './blacklist.model';

@Injectable({
	providedIn: 'root'
})
export class BlackListService {

	constructor(private api: API) { }

	getAll(): Observable<BlackList[]> {
		return this.api.GET('/api/BlackList');
	}
	deleteBlackList(id?: string): Observable<boolean> {
		console.log(`start`);
		return this.api.DELETE('/api/BlackList/' + id);
	}

	createBlackList(newBlackList: BlackListAddModel): Observable<BlackList> {
		return this.api.POST('/api/BlackList/', newBlackList);
	}
}
