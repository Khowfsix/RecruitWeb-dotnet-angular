/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { QuestionSkillService } from '../../../data/question-skill/question-skill.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { QuestionSkill } from '../../../data/question-skill/question-skill.model';

@Component({
	selector: 'app-question-skill',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './question-skill.component.html',
	styleUrl: './question-skill.component.css'
})
export class QuestionSkillComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"questionSkillsId",
		"questionId",
		"skillId",
	];
	public displayColumn: string[] = [
		"QuestionSkill Id",
		"Question Id",
		"Skill Id",
	];

	public listQuestionSkills = new BehaviorSubject<QuestionSkill[]>([]);

	constructor(
		public _questionSkillService: QuestionSkillService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._questionSkillService.getAllQuestionSkills().subscribe(
			questionSkills => {
				this.listQuestionSkills.next(questionSkills);
			},
			error => console.error(error)
		);
	}
}
