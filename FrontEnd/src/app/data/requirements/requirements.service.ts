/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { API } from '../api.service';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class RequirementsService {

	constructor(private api: API) { }

	save(data?: any): Observable<any> {
		return this.api.POST('/api/Requirement', data);
	}

	delete(id?: string): Observable<any> {
		return this.api.DELETE('/api/Requirement/' + id);
	}
}
