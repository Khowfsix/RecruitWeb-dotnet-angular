/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { BehaviorSubject } from 'rxjs';
import { QuestionService } from '../../../../data/question/question.service';
import { RightTableComponent } from '../../interview-id/question-table/right-table/right-table.component';
import { LeftTableComponent } from '../left-table/left-table.component';
import { CategoryQuestionService } from '../../../../data/categoryQuestion/category-question.service';
import { CategoryQuestion } from '../../../../data/categoryQuestion/categoryQuestion.model';

@Component({
	selector: 'app-question-transfer',
	standalone: true,
	imports: [
		LeftTableComponent,
		RightTableComponent,
		MatFormFieldModule,
		MatSelectModule,
		MatIconModule,
		MatInputModule,
		MatButtonModule,

		FormsModule,
		ReactiveFormsModule,
		CommonModule,
	],
	templateUrl: './question-transfer.component.html',
	styleUrl: './question-transfer.component.css',
})
export class QuestionTransferComponent {
	@Input() set leftTable(value: any) {
		this.leftData?.next(value);
	}
	@Input() set rightTable(value: any) {
		this.rightData?.next(value);
	}
	@Input() cate?: number;

	leftData?: BehaviorSubject<any> = new BehaviorSubject<any>([]);
	rightData?: BehaviorSubject<any> = new BehaviorSubject<any>([]);
	leftData$: any;
	rightData$: any;

	data?: BehaviorSubject<any> = new BehaviorSubject<any>([]);
	currentSubTab = 0;
	currentQues: number[] = [];

	categoryQuestion: CategoryQuestion[] = [];
	constructor(
		private questionService: QuestionService,
		private _categoryQuesService: CategoryQuestionService,
	) {
		_categoryQuesService.getAllCategoryQuestions().subscribe((data) => {
			this.categoryQuestion = data;
		});
	}

	ngOnInit() {
		this.refreshTable();
	}

	refreshTable() {
		this.leftData?.asObservable().subscribe((data) => {
			this.leftData$ = data;
			console.log(data);
		});

		this.rightData?.asObservable().subscribe((data) => {
			this.rightData$ = data;
			console.log(data);
		});
	}

	setCurrentSubTab(value: number) {
		this.currentSubTab = value;
	}

	setCurrentQues(numbers: number[]) {
		// Handle the array of numbers received from the event
		this.currentQues = numbers;
	}

	setCurrentQuesFromEvent(event: Event) {
		const target = event.target as HTMLInputElement;
		const value = target.value;

		// Parse the value to get the numbers and pass them to setCurrentQues
		const numbers = value.split(',').map((num) => parseInt(num.trim(), 10));
		this.setCurrentQues(numbers);
	}

	selectedQuestion: any = null;

	onQuestionSelected(question: any) {
		this.selectedQuestion = question;
	}

	handleTransfer() {
		// const newQues = {
		// 	categoryOrder: this.cate,
		// 	subOrder: this.currentSubTab,
		// 	chosenQuestionId: this.selectedQuestion.questionid,
		// };

		// Remove question from left table
		let data;
		this.leftData?.asObservable().subscribe((newData) => {
			data = newData;
		});
		// eslint-disable-next-line no-constant-condition
		while (true) {
			const leftSubSet = this.getSubSet(data);
			if (leftSubSet && leftSubSet.questions) {
				const index = leftSubSet.questions.findIndex(
					(q: { questionid: any }) =>
						q.questionid === this.selectedQuestion.questionid,
				);
				if (index > -1) {
					leftSubSet.questions.splice(index, 1);
					this.leftData?.next(data);
					break;
				}
			}
		}

		// Add question to right table
		this.rightData?.asObservable().subscribe((newData) => {
			data = newData;
		});
		// eslint-disable-next-line no-constant-condition
		while (true) {
			const rightSubSet = this.getSubSet(data);
			if (rightSubSet) {
				if (!rightSubSet.questions) {
					rightSubSet.questions = [];
				}
				rightSubSet.questions.push({
					...this.selectedQuestion,
					score: '',
				});
				this.rightData?.next(data);
				break;
			}
		}

		this.refreshTable();

		// this.data?.next(this.rightTable);

		// Reset selection
		this.selectedQuestion = null;

		// Optional: Call API to persist changes
		// this.questionService
		// 	.transferQuestion(newQues as NewQuestion)
		// 	.subscribe(
		// 		(response) => {
		// 			console.log(
		// 				'Question transferred successfully',
		// 				response,
		// 			);
		// 			// You might want to update your local data here based on the response
		// 		},
		// 		(error) => {
		// 			console.error('Error transferring question', error);
		// 			// You might want to revert your local changes here
		// 		},
		// 	);
	}

	private getSubSet(table: any): any {
		if (this.cate === 0) return table;
		if (this.cate === 1) return table.languages[this.currentSubTab];
		if (this.cate === 2) return table.skills[this.currentSubTab];
		return null;
	}

	///======================================

	newQuestion: string = '';
	public questions: newQues[] = [];

	addQuestion() {
		if (this.newQuestion.trim()) {
			this.questions.push({
				text: this.newQuestion,
				score: 0,
				cate: this.cate!,
				categoryId:
					this.categoryQuestion[this.cate!].categoryQuestionId!,
			});
			this.newQuestion = '';
			this.questionsChange.emit(this.questions);
		}
	}

	deleteQuestion(index: number) {
		this.questions.splice(index, 1);
		this.questionsChange.emit(this.questions);
	}

	onScoreChange() {
		this.questionsChange.emit(this.questions);
	}

	@Output() questionsChange = new EventEmitter<newQues[]>();
}

export interface newQues {
	text: string;
	score: number;
	cate: number;
	categoryId: string;
}
