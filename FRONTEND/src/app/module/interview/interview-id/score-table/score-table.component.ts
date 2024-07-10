/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Input } from '@angular/core';
import { CalculationService } from '../../../../shared/service/calculate.service';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import katex from 'katex';

@Component({
	selector: 'app-score-table',
	standalone: true,
	imports: [
		CommonModule,

		MatTableModule,
	],
	templateUrl: './score-table.component.html',
	styleUrl: './score-table.component.css'
})
export class ScoreTableComponent {
	@Input() allResult?: any[];

	displayedColumns: string[] = ['category', 'score', 'formula'];
	dataSource?: any[];

	constructor(private calculationService: CalculationService) { }

	ngOnInit() {
		const rightSoft = this.allResult![0];
		const rightLang = this.allResult![1];
		const rightTech = this.allResult![2];

		const {
			softResult,
			softMath,
			langResult,
			langMath,
			techResult,
			techMath,
			finalResult,
			finalMath
		} = this.calculationService.calculateScore(rightSoft, rightLang, rightTech);

		this.dataSource = [
			{ category: 'Soft Skill', score: softResult, formula: softMath },
			{ category: 'Language Skill', score: langResult, formula: langMath },
			{ category: 'Technology Skill', score: techResult, formula: techMath },
			{ category: 'Final Score', score: finalResult, formula: finalMath }
		];
	}

	renderKatex(equation: string): string {
		return katex.renderToString(equation, {
			throwOnError: false
		});
	}
}
