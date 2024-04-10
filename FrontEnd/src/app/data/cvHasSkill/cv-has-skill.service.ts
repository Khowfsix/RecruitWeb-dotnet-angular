/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CvHasSkill } from './cv-has-skill.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class CvHasSkillService {

	constructor(private api: API) { }

	getAllByCvId(cvId: string): Observable<CvHasSkill[]> {
		return this.api.GET('/api/CvHasSkill?cvId=' + cvId);
	}
}
