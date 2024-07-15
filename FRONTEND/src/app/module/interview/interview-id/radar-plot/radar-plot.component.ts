/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { PlotlyModule } from 'angular-plotly.js';
import { CalculationService } from '../../../../shared/service/calculate.service';

@Component({
	selector: 'app-radar-plot',
	standalone: true,
	imports: [
		CommonModule,
		PlotlyModule
	],
	templateUrl: './radar-plot.component.html',
})
export class RadarPlotComponent {
	@Input() allResult?: any[];

	data?: any[];
	layout: any;
	config: any;

	constructor(
		private calculatorService: CalculationService
	) { }

	ngOnInit() {
		const rightSoft = this.allResult![0];
		const rightLang = this.allResult![1];
		const rightTech = this.allResult![2];

		console.log("rightSoft: ", rightSoft);
		console.log("rightLang: ", rightLang);
		console.log("rightTech: ", rightTech);

		// const {
		// 	softResult,
		// 	softMath,
		// 	langResult,
		// 	techResult,
		// 	techMath,
		// 	finalResult,
		// 	finalMath
		// } = this.calculatorService.calculateScore(rightSoft, rightLang, rightTech);

		// this.data = [{
		// 	type: 'scatterpolar',
		// 	r: [softResult, langResult, techResult],
		// 	theta: ['Soft Skill', 'Language', 'Technology'],
		// 	fill: 'toself'
		// }];

		// this.layout = {
		// 	polar: {
		// 		radialaxis: {
		// 			visible: true,
		// 			range: [0, 10]
		// 		}
		// 	},
		// 	showlegend: false,
		// 	margin: {
		// 		autoexpand: false,
		// 		pad: 0,
		// 		b: 0,
		// 		l: 20,
		// 		r: 70,
		// 		t: 0
		// 	},
		// 	width: 320,
		// 	height: 320
		// };

		// this.config = {
		// 	displayModeBar: false
		// };
	}
}
