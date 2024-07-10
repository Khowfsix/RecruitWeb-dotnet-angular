import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WorkExperience } from './work-experience.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class WorkExperienceService {

	constructor(private api: API) { }

	getAllWorkExperiences(): Observable<WorkExperience[]> {
		return this.api.GET('/api/WorkExperience');
	}

}
