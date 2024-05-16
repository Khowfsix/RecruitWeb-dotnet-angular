import { Injectable } from '@angular/core';
import { API } from '../api.service';
import { Skill, SkillAddModel } from './skill.model';
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

	deleteSkill(id?: string): Observable<boolean> {
		console.log(`start`);
		return this.api.DELETE('/api/Skill/' + id);
	}

	createSkill(newSkill: SkillAddModel): Observable<Skill> {
		return this.api.POST('/api/Skill/', newSkill);
	}
}
