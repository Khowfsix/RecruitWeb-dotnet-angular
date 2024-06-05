import { Component } from '@angular/core';
import { GenericTableComponent } from '../generic/generic-table.component';
import { SkillService } from '../../../data/skill/skill.service';
import { Skill, SkillAddModel } from '../../../data/skill/skill.model';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-skill',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './skill.component.html',
	styleUrl: './skill.component.css',
})
export class SkillComponent {
	public listProps: string[] = [
		"skillId",
		"skillName",
		"description"
	];
	public displayColumn: string[] = [
		"ID",
		"Name",
		"Description"
	];
	public listSkills = new BehaviorSubject<Skill[]>([]);

	constructor(
		public _skillService: SkillService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._skillService.getAllSkills().subscribe(
			skills => {
				this.listSkills.next(skills.filter(sk => sk.isDeleted == false));
			},
			error => console.error(error)
		);
	}

	delete = (skill: Skill): void => {
		this._skillService.deleteSkill(skill.skillId).subscribe(
			(response) => {
				console.log(response);
				this.refreshData();

				this._toastService.success("Delete success", "Delete skill success", {
					timeOut: 3000,
					positionClass: 'toast-top-center',
					toastClass: ' my-custom-toast ngx-toastr',
					progressBar: true
				});
			}
		)
	}

	create = (newSkill: SkillAddModel): void => {
		this._skillService.createSkill(newSkill).subscribe(
			(response) => {
				console.log(response);
				this.refreshData();

				this._toastService.success("Create success", "Create skill success", {
					timeOut: 3000,
					positionClass: 'toast-top-center',
					toastClass: ' my-custom-toast ngx-toastr',
					progressBar: true
				});
			}
		)
	}
}
