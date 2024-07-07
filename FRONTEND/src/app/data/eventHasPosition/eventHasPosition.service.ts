/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { API } from '../api.service';
import { Observable } from 'rxjs';
import { EventHasPosition } from './eventHasPosition.model';
// import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class EventHasPositionService {

	constructor(
		private api: API
	) { }

	public getAll(): Observable<EventHasPosition[]> {
		return this.api.GET('/api/EventHasPosition/');
	}

	public delete(id?: string): Observable<any> {
		return this.api.DELETE('/api/EventHasPosition/' + id);
	}

	public save(data: any, options?: any) {
		return this.api.POST('/api/EventHasPosition', data, options);
	}
}
