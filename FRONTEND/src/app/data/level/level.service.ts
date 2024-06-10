/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { Level } from './level.model';

@Injectable({
	providedIn: 'root'
})
export class LevelService {

	constructor(private api: API) { }

	getAllLevels(): Observable<Level[]> {
		return this.api.GET('/api/Level/GetAllLevels');
	}

	create(data: any): Observable<any> {
		return this.api.POST('/api/Level/CreateLevel', data);
	}
}
