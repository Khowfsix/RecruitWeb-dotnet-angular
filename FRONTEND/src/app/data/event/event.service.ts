/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { API } from '../api.service';
import { Observable } from 'rxjs';
import { Event, EventFilter } from './event.model';

@Injectable({
	providedIn: 'root'
})
export class EventService {

	constructor(
		private api: API
	) { }

	public getById(id: string) {
		return this.api.GET('/api/Event?id=' + id);
	}

	public delete(id: string): Observable<any> {
		return this.api.DELETE('/api/Event/' + id);
	}

	public update(eventId: string, data: any) {
		return this.api.PUT('/api/Event/' + eventId, data);
	}

	public save(data: any, options?: any) {
		return this.api.POST('/api/Event', data, options);
	}

	public getAllByRecruiterId(recruiterId: string, eventFilter?: EventFilter, sortString?: string): Observable<Event[]> {
		let url = '/api/Event?recruiterId=' + recruiterId + '&';

		if (sortString) {
			url += 'sortString=' + sortString;
		}
		if (eventFilter) {
			url += this.buildQueryParams(eventFilter);
		}
		return this.api.GET(url);
	}

	private buildQueryParams(eventFilter: EventFilter): string {
		let params = '';

		if (eventFilter.search) {
			params += `&search=${eventFilter.search}`;
		}
		if (eventFilter.fromDate) {
			params += `&fromDate=${eventFilter.fromDate}`;
		}
		if (eventFilter.toDate) {
			params += `&toDate=${eventFilter.toDate}`;
		}
		if (eventFilter.fromMaxParticipants !== undefined) {
			params += `&fromMaxParticipants=${eventFilter.fromMaxParticipants}`;
		}
		if (eventFilter.toMaxParticipants !== undefined) {
			params += `&toMaxParticipants=${eventFilter.toMaxParticipants}`;
		}
		return params;
	}
}
