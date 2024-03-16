import { Injectable } from '@angular/core';
import { API } from '../api.service';
import { Skill } from './skill.model';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class SkillService {

	constructor(private api: API) { }

	getAllSkills(query?: string): Observable<Skill[]> {
		if (query)
			return this.api.GET('/api/Skill?query=' + query);
		return this.api.GET('/api/Skill');
	}

	getSkillById(id?: string): Observable<Skill> {
		return this.api.GET('/api/Skill/GetSkillById?skillId=' + id);
	}

}
