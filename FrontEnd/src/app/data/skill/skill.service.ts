import { Injectable } from '@angular/core';
import { API } from '../api.service';
import { Skill, SkillAddModel, SkillUpdateModel } from './skill.model';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class SkillService {

	constructor(private api: API) { }

	public getAllSkills(query?: string): Observable<Skill[]> {
		if (query)
			return this.api.GET('/api/Skill?query=' + query);
		return this.api.GET('/api/Skill');
	}

	public getSkillById(id?: string): Observable<Skill> {
		return this.api.GET('/api/Skill/GetSkillById?skillId=' + id);
	}

	public deleteSkill(id?: string): Observable<boolean> {
		return this.api.DELETE('/api/Skill/' + id);
	}

	public createSkill(newSkill: SkillAddModel): Observable<Skill> {
		return this.api.POST('/api/Skill/', newSkill);
	}

	public updateSkill(skillId: string, newSkill: SkillUpdateModel): Observable<Skill> {
		return this.api.PUT('/api/Skill/' + skillId, newSkill);
	}
}
