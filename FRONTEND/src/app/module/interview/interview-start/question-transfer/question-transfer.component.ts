/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Input } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { QuestionService } from '../../../../data/question/question.service';
import { RightTableComponent } from '../../interview-id/question-table/right-table/right-table.component';
import { ButtonTransferComponent } from '../button-transfer/button-transfer.component';
import { LeftTableComponent } from '../left-table/left-table.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Question } from '../../../../data/question/question.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
	selector: 'app-question-transfer',
	standalone: true,
	imports: [
		LeftTableComponent,
		RightTableComponent,
		MatFormFieldModule,
		MatSelectModule,
		MatIconModule,

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

	constructor(private questionService: QuestionService) {}

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

	questionForm?: FormGroup;
	categories: string[] = [
		'Category 1',
		'Category 2',
		'Category 3',
		'Category 4',
	];
	questions: Question[] = [];
	displayedColumns: string[] = [
		'questionText',
		'category',
		'points',
		'actions',
	];
	dataSource?: MatTableDataSource<Question>;

	onSubmit() {
		if (this.questionForm!.valid) {
			const newQuestion: Question = this.questionForm!.value;
			this.questions.push(newQuestion);
			this.dataSource!.data = this.questions;
			this.questionForm!.reset({ category: '', points: null });
		}
	}

	updatePoints(question: Question, event: Event) {
		// const input = event.target as HTMLInputElement;
		// question.points = input.value ? Number(input.value) : null;
	}

	deleteQuestion(question: Question) {
		const index = this.questions.indexOf(question);
		if (index > -1) {
			this.questions.splice(index, 1);
			// this.dataSource.data = this.questions;
		}
	}

	private getSubSet(table: any): any {
		if (this.cate === 0) return table;
		if (this.cate === 1) return table.languages[this.currentSubTab];
		if (this.cate === 2) return table.skills[this.currentSubTab];
		return null;
	}
}
