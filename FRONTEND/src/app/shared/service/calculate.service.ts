/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';

@Injectable({
	providedIn: 'root'
})
export class CalculationService {

	calculateScore(rightSoft: any, rightLang: any, rightTech: any) {
		const softScoreArray: number[] = [];
		let softSumString = '';
		let softResult = 0;
		let softMath = '';

		const langScoreArray: number[] = [];
		let langSumString = '';
		let langResult = 0;
		let langMath = '';

		const techScoreArray: number[] = [];
		let techSumString = '';
		let techResult = 0;
		let techMath = '';

		if (rightSoft) {
			rightSoft.questions.forEach((ques: any) => {
				if (typeof (ques.score) === "number") {
					softScoreArray.push(parseFloat(ques.score.toString()));
				}
			});
			softScoreArray.forEach((sco, index) => {
				const rightParen = '}';
				const num = softScoreArray.length.toString();
				const divider = '}{';
				const leftParen = '\\frac{';
				softResult = parseFloat((softScoreArray.reduce((a, b) => a + b, 0) / softScoreArray.length).toFixed(2));
				softSumString += sco.toString();
				if (index < softScoreArray.length - 1) {
					softSumString += "+";
				}
				softMath = leftParen + softSumString + divider + num + rightParen;
			});
		}

		if (rightLang) {
			rightLang.languages.forEach((language: any) => {
				language.questions.forEach((ques: any) => {
					if (typeof (ques.score) === "number") {
						langScoreArray.push(parseFloat(ques.score.toString()));
					}
				});
			});
			langScoreArray.forEach((sco, index) => {
				const rightParen = '}';
				const num = langScoreArray.length.toString();
				const divider = '}{';
				const leftParen = '\\frac{';
				langResult = parseFloat((langScoreArray.reduce((a, b) => a + b, 0) / langScoreArray.length).toFixed(2));
				langSumString += sco.toString();
				if (index < langScoreArray.length - 1) {
					langSumString += "+";
				}
				langMath = leftParen + langSumString + divider + num + rightParen;
			});
		}

		if (rightTech) {
			rightTech.skills.forEach((skill: any) => {
				skill.questions.forEach((ques: any) => {
					if (typeof (ques.score) === "number") {
						techScoreArray.push(parseFloat(ques.score.toString()));
					}
				});
			});
			techScoreArray.forEach((sco, index) => {
				const rightParen = '}';
				const num = techScoreArray.length.toString();
				const divider = '}{';
				const leftParen = '\\frac{';
				techResult = parseFloat((techScoreArray.reduce((a, b) => a + b, 0) / techScoreArray.length).toFixed(2));
				techSumString += sco.toString();
				if (index < techScoreArray.length - 1) {
					techSumString += "+";
				}
				techMath = leftParen + techSumString + divider + num + rightParen;
			});
		}

		const finalResult = parseFloat((softResult * 0.2 + langResult * 0.3 + techResult * 0.5).toFixed(2));
		const finalMath = `0.2\\times${softResult}+0.3\\times${langResult}+0.5\\times${techResult}`;

		return {
			softResult,
			softMath,
			langResult,
			langMath,
			techResult,
			techMath,
			finalResult,
			finalMath
		};
	}
}
