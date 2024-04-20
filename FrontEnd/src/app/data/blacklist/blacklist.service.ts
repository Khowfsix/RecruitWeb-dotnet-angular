/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { BlackList } from './blacklist.model';

@Injectable({
	providedIn: 'root'
})
export class BlackListService {

	constructor(private api: API) { }

	getAll(): Observable<BlackList[]> {
		return this.api.GET('/api/BlackList');
	}
}
