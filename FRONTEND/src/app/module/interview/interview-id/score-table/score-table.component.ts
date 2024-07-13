/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import katex from 'katex';
import { BehaviorSubject } from 'rxjs';
import { CategoryQuestionService } from '../../../../data/categoryQuestion/category-question.service';
import { CategoryQuestion } from '../../../../data/categoryQuestion/categoryQuestion.model';
import { CalculationService } from '../../../../shared/service/calculate.service';
import { newQues } from '../../interview-start/question-transfer/question-transfer.component';

@Component({
	selector: 'app-score-table',
	standalone: true,
	imports: [CommonModule, MatTableModule],
	templateUrl: './score-table.component.html',
	styleUrl: './score-table.component.css',
})
export class ScoreTableComponent {
	@Input() allResult?: any[];

	@Input() softResult$ = new BehaviorSubject<any>([]);
	softResult?: newQues[];

	@Input() langResult$ = new BehaviorSubject<any>([]);
	langResult?: newQues[];

	@Input() expertResult$ = new BehaviorSubject<any>([]);
	expertResult?: newQues[];

	displayedColumns: string[] = ['category', 'score', 'formula'];
	dataSource?: any[];

	categoryQuestion: CategoryQuestion[] = [];

	constructor(
		private calculationService: CalculationService,
		private _categoryQuesService: CategoryQuestionService,
	) {
		_categoryQuesService.getAllCategoryQuestions().subscribe((data) => {
			this.categoryQuestion = data;
		});
	}

	// ngOnChanges(changes: SimpleChanges) {
	// 	if (changes['softResult']) {
	// 		console.log(...changes['softResult'].currentValue);
	// 		this.updateTable();

	// 		// this.columnsToDisplayWithExpand = [
	// 		// 	...changes['displayedColumns'].currentValue,
	// 		// 	'action',
	// 		// ];
	// 	}
	// 	if (changes['langResult']) {
	// 		console.log(this.langResult);
	// 		// this.colum,nsToDisplayWithExpand = [
	// 		// 	...changes['displayedColumns'].currentValue,
	// 		// 	'action',
	// 		// ];
	// 	}
	// 	if (changes['expertResults']) {
	// 		console.log(this.expertResult);
	// 		// this.columnsToDisplayWithExpand = [
	// 		// 	...changes['displayedColumns'].currentValue,
	// 		// 	'action',
	// 		// ];
	// 	}
	// }

	ngOnInit() {
		// console.log('soft', this.softResult);
		// console.log('lang', this.langResult);
		// console.log('expr', this.expertResult);

		this.softResult$.subscribe((data) => {
			this.softResult = data;
			this.updateTable();
		});
		this.langResult$.subscribe((data) => {
			this.langResult = data;
			this.updateTable();
		});
		this.expertResult$.subscribe((data) => {
			this.expertResult = data;
			this.updateTable();
		});
	}

	updateTable() {
		let totalScoreSoft = 0;
		let totalScoreLang = 0;
		let totalScoreTech = 0;
		if (this.softResult) {
			totalScoreSoft = this.softResult!.reduce(
				(acc, item) => acc + item.score,
				0,
			);
		}
		if (this.langResult) {
			totalScoreLang = this.langResult!.reduce(
				(acc, item) => acc + item.score,
				0,
			);
		}
		if (this.expertResult) {
			totalScoreTech = this.expertResult!.reduce(
				(acc, item) => acc + item.score,
				0,
			);
		}

		this.dataSource = [
			{
				category: this.categoryQuestion[1].categoryQuestionName!,
				score: totalScoreSoft,
				formula: totalScoreSoft * this.categoryQuestion[1].weight!,
			},
			{
				category: this.categoryQuestion[0].categoryQuestionName!,
				score: totalScoreLang,
				formula: totalScoreLang * this.categoryQuestion[0].weight!,
			},
			{
				category: this.categoryQuestion[2].categoryQuestionName!,
				score: totalScoreTech,
				formula: totalScoreTech * this.categoryQuestion[2].weight!,
			},
			{
				category: 'Final Score',
				score: totalScoreSoft + totalScoreLang + totalScoreTech,
				formula:
					totalScoreSoft * 0.2 +
					totalScoreLang * 0.3 +
					totalScoreTech * 0.5,
			},
		];
	}

	renderKatex(equation: string): string {
		return katex.renderToString(equation, {
			throwOnError: false,
		});
	}
}
