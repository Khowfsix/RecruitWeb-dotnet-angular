import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonalProject } from './personal-project.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class PersonalProjectService {

	constructor(private api: API) { }

	getAllPersonalProjects(): Observable<PersonalProject[]> {
		return this.api.GET('/api/PersonalProject');
	}
}
