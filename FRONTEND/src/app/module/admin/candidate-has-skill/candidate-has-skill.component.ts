import { Component } from '@angular/core';
import { ActionType, GenericTableComponent } from "../generic/generic-table.component";
import { CandidateHasSkillService } from '../../../data/candidateHasSkill/candidate-has-skill.service';
import { CandidateHasSkill } from '../../../data/candidateHasSkill/candidate-has-skill.model';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-candidate-has-skill',
	standalone: true,
	templateUrl: './candidate-has-skill.component.html',
	styleUrl: './candidate-has-skill.component.css',
	imports: [GenericTableComponent]
})
export class CandidateHasSkillComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"candidateHasSkillId",
		"candidateId",
		"skillId",
		"level",
	];
	public displayColumn: string[] = [
		"Candidate-Has-Skill Id",
		"Candidate Id",
		"Skill Id",
		"Level",
	];
	public listCandidateHasSkills = new BehaviorSubject<CandidateHasSkill[]>([]);

	constructor(
		public _candidatehasskillService: CandidateHasSkillService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._candidatehasskillService.getAll().subscribe(
			candidatehasskills => {
				this.listCandidateHasSkills.next(candidatehasskills);
			},
			error => console.error(error)
		);
	}
}
