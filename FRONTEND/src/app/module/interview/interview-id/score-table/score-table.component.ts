/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Input } from '@angular/core';
import { CalculationService } from '../../../../shared/service/calculate.service';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import katex from 'katex';
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
	@Input() softResult?: newQues[];
	@Input() langResult?: newQues[];
	@Input() expertResult?: newQues[];

	displayedColumns: string[] = ['category', 'score'];
	dataSource?: any[];

	constructor(private calculationService: CalculationService) {}

	ngOnInit() {
		// const rightSoft = this.allResult![0];
		// const rightLang = this.allResult![1];
		// const rightTech = this.allResult![2];

		// const {
		// 	softResult,
		// 	softMath,
		// 	langResult,
		// 	langMath,
		// 	techResult,
		// 	techMath,
		// 	finalResult,
		// 	finalMath,
		// } = this.calculationService.calculateScore(
		// 	rightSoft,
		// 	rightLang,
		// 	rightTech,
		// );

		console.log(this.softResult, this.langResult, this.expertResult);

		const sum =
			this.softResult!.length +
			this.langResult!.length +
			this.expertResult!.length;

		const totalScoreSoft = this.softResult!.reduce(
			(acc, item) => acc + item.score,
			0,
		);
		const totalScoreLang = this.langResult!.reduce(
			(acc, item) => acc + item.score,
			0,
		);
		const totalScoreTech = this.expertResult!.reduce(
			(acc, item) => acc + item.score,
			0,
		);

		this.dataSource = [
			{
				category: 'Soft Skill',
				score: totalScoreSoft,
				formula: (totalScoreSoft * 0.2) / sum,
			},
			{
				category: 'Language Skill',
				score: totalScoreLang,
				formula: (totalScoreLang * 0.3) / sum,
			},
			{
				category: 'Technology Skill',
				score: totalScoreTech,
				formula: (totalScoreTech * 0.5) / sum,
			},
			{
				category: 'Final Score',
				score: totalScoreSoft + totalScoreLang + totalScoreTech,
				formula:
					(totalScoreSoft * 0.2 +
						totalScoreLang * 0.3 +
						totalScoreTech * 0.5) /
					sum,
			},
		];
	}

	renderKatex(equation: string): string {
		return katex.renderToString(equation, {
			throwOnError: false,
		});
	}
}
