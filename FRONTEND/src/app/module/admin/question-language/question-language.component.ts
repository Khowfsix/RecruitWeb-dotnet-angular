import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { QuestionLanguageService } from '../../../data/question-language/question-language.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { QuestionLanguage } from '../../../data/question-language/question-language.model';

@Component({
	selector: 'app-question-language',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './question-language.component.html',
	styleUrl: './question-language.component.css'
})
export class QuestionLanguageComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"questionLanguageId",
		"questionId",
		"languageId",
	];
	public displayColumn: string[] = [
		"Question-Language Id",
		"Question Id",
		"Language Id",
	];
	public listQuestionLanguages = new BehaviorSubject<QuestionLanguage[]>([]);

	constructor(
		public _questionLanguageService: QuestionLanguageService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._questionLanguageService.getAllQuestionLanguages().subscribe(
			questionLanguages => {
				this.listQuestionLanguages.next(questionLanguages);
			},
			error => console.error(error)
		);
	}
}
