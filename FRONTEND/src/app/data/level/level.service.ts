/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { Level, LevelAddModel, LevelUpdateModel } from './level.model';

@Injectable({
	providedIn: 'root'
})
export class LevelService {

	constructor(private api: API) { }

	public getAllLevels(): Observable<Level[]> {
		return this.api.GET('/api/Level/GetAllLevels');
	}

	public create(data: any): Observable<any> {
		return this.api.POST('/api/Level/CreateLevel', data);
	}

	public deleteLevel(id?: string): Observable<boolean> {
		return this.api.DELETE('/api/Level/' + id);
	}

	public createLevel(newLevel: LevelAddModel): Observable<Level> {
		return this.api.POST('/api/Level/CreateLevel', newLevel);
	}

	public updateLevel(LevelId: string, newLevel: LevelUpdateModel): Observable<Level> {
		return this.api.PUT('/api/Level/' + LevelId, newLevel);
	}
}
