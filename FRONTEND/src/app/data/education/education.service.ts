import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Education } from './education.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class EducationService {

	constructor(private api: API) { }

	getAllEducations(): Observable<Education[]> {
		return this.api.GET('/api/Education');
	}
}
