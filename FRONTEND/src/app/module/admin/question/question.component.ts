/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { QuestionService } from '../../../data/question/question.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { Question } from '../../../data/question/question.model';

@Component({
	selector: 'app-question',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './question.component.html',
	styleUrl: './question.component.css'
})
export class QuestionComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"questionId",
		"questionString",
		"categoryQuestionId",
	];
	public displayColumn: string[] = [
		"Question Id",
		"Question String",
		"Category-Question Id",
	];

	public listQuestions = new BehaviorSubject<Question[]>([]);

	constructor(
		public _questionService: QuestionService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._questionService.getAll().subscribe(
			questions => {
				this.listQuestions.next(questions);
			},
			error => console.error(error)
		);
	}
}
