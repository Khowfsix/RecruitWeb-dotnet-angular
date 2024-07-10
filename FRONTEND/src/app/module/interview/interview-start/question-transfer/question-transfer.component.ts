/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Input } from '@angular/core';
import { QuestionService } from '../../../../data/question/question.service';
import { LeftTableComponent } from '../left-table/left-table.component';
import { RightTableComponent } from '../../interview-id/question-table/right-table/right-table.component';
import { ButtonTransferComponent } from '../button-transfer/button-transfer.component';

@Component({
	selector: 'app-question-transfer',
	standalone: true,
	imports: [
		LeftTableComponent,
		RightTableComponent,
		ButtonTransferComponent
	],
	templateUrl: './question-transfer.component.html',
	styleUrl: './question-transfer.component.css'
})
export class QuestionTransferComponent {
	@Input() leftTable: any;
	@Input() rightTable: any;
	@Input() cate?: number;

	currentSubTab = 0;
	currentQues: number[] = [];

	constructor(private questionService: QuestionService) { }

	ngOnInit() { }

	handleTransfer() {
		// const newQues = {
		// 	categoryOrder: this.cate,
		// 	subOrder: this.currentSubTab,
		// 	chosenQuestionId: this.currentQues[0]
		// };
		// this.questionService.transferQuestion(newQues).subscribe(
		// 	response => {
		// 		console.log('Question transferred successfully', response);
		// 		// Thực hiện các hành động cần thiết sau khi chuyển câu hỏi
		// 	},
		// 	error => {
		// 		console.error('Error transferring question', error);
		// 	}
		// );
	}

	setCurrentSubTab(value: number) {
		this.currentSubTab = value;
	}

	setCurrentQues(value: number[]) {
		this.currentQues = value;
	}
}
