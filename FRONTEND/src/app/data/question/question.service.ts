/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { forkJoin, map, Observable, of, switchMap } from 'rxjs';
import { API } from '../api.service';
import { Interview } from '../interview/interview.model';
import { Question } from './question.model';

@Injectable({
	providedIn: 'root',
})
export class QuestionService {
	constructor(private api: API) {}

	public getAll(): Observable<any> {
		const url = '/api/Question';
		return this.api.GET(url);
	}

	public transferQuestion(_newQuestion: NewQuestion): Observable<any> {
		return this.api.POST('/api/Question/transfer', _newQuestion);
	}

	public scoreQuestion(_newQuestion: NewQuestion): Observable<any> {
		return this.api.POST('/api/Question/score', _newQuestion);
	}

	getQuestionsForStartingInterview(interviewId: string): Observable<any> {
		return this.api.GET(`/api/Interview?id=${interviewId}`).pipe(
			switchMap((interview: Interview) => {
				const positionId = interview.application!.position!.positionId;
				// const position = interview.application!.position!;

				return forkJoin({
					interview: of(interview),
					position: this.api.GET(
						`/api/Position/GetPositionById?positionId=${positionId}`,
					),
					softSkills: this.api.GET(
						`/api/Question/GetAllSoftSkillQuestions/SoftSkill`,
					),
					languageQuestions: this.api.GET(
						`/api/Question/GetAllLanguageQuestions/Language`,
					),
					expertise: this.api.GET(
						`/api/Question/GetAllTechnologyQuestions/Technology`,
					),
					questionSkills: this.api.GET(`/api/QuestionSkill`),
					allQuestions: this.api.GET(`/api/Question`),
					categories: this.api.GET(`/api/CategoryQuestion`),
					skills: this.api.GET(`/api/Skill`),
				});
			}),
			map((responses) => {
				// console.log(responses);
				const quesStruc = this.processQuestionStructure(responses);
				console.log(`list of questions`, quesStruc);
				return {
					interviewQuestions: quesStruc,
					interviewStart: responses.interview,
				};
			}),
		);
	}

	private processQuestionStructure(responses: any): any[] {
		const quesStruc: any[] = [];

		// Process Soft Skills
		const softSkillCategory = responses.categories.find(
			(cate: { categoryQuestionName: string }) =>
				cate.categoryQuestionName === 'Soft skill',
		);
		if (softSkillCategory) {
			const softSkillQuestions = responses.allQuestions.filter(
				(q: { categoryQuestionId: any }) =>
					q.categoryQuestionId ===
					softSkillCategory.categoryQuestionId,
			);
			quesStruc.push({
				categoryid: softSkillCategory.categoryQuestionId,
				categoryname: softSkillCategory.categoryQuestionName,
				questions: softSkillQuestions.map(
					(q: { questionId: any; questionString: any }) => ({
						questionid: q.questionId,
						questionstring: q.questionString,
					}),
				),
			});
		}

		// Process Language
		const languageCategory = responses.categories.find(
			(cate: { categoryQuestionName: string }) =>
				cate.categoryQuestionName === 'Language skill',
		);
		if (languageCategory) {
			// console.log(responses);
			const language = responses.position.language!;
			// const prefix = this.getLanguagePrefix(language.languageName);
			const languageQuestions = responses.languageQuestions;
			// const languageQuestions = responses.languageQuestions.filter(
			// 	(q: { questionString: string }) =>
			// 		q.questionString.startsWith(prefix),
			// );
			quesStruc.push({
				categoryid: languageCategory.categoryQuestionId,
				categoryname: languageCategory.categoryQuestionName,
				languages: [
					{
						languageid: language.languageId,
						languagename: language.languageName,
						questions: languageQuestions.map(
							(q: {
								questionId: any;
								questionString: string | [];
							}) => ({
								questionid: q.questionId,
								questionstring: q.questionString.slice(5),
							}),
						),
					},
				],
			});
		}

		// Process Expertise
		const techCategory = responses.categories.find(
			(cate: { categoryQuestionName: string }) =>
				cate.categoryQuestionName === 'Expertise',
		);
		if (techCategory) {
			const techSkills = responses.position.requirements.map(
				(req: { skillId: any }) => {
					const skill = responses.skills.find(
						(s: { skillId: any }) => s.skillId === req.skillId,
					);
					const skillQuestions = responses.questionSkills
						// .filter(
						// 	(qs: { skillId: any }) =>
						// 		qs.skillId === req.skillId,
						// )
						.map((qs: { questionId: any }) =>
							responses.expertise.find(
								(tq: { questionId: any }) =>
									tq.questionId === qs.questionId,
							),
						)
						// .filter((q: any) => q)
						.map((q: { questionId: any; questionString: any }) => ({
							questionid: q.questionId,
							questionstring: q.questionString,
						}));
					return {
						skillid: req.skillId,
						skillname: skill.skillName,
						questions: skillQuestions,
					};
				},
			);
			quesStruc.push({
				categoryid: techCategory.categoryQuestionId,
				categoryname: techCategory.categoryQuestionName,
				skills: techSkills,
			});
		}
		// console.log(quesStruc);

		return quesStruc;
	}

	private getLanguagePrefix(languageName: string): string {
		const prefixMap = {
			English: '$eng$',
			Chinese: '$chi$',
			Italian: '$ita$',
			Spanish: '$spa$',
			French: '$fre$',
			Russian: '$rus$',
			Japanese: '$jap$',
			Korean: '$kor$',
			German: '$ger$',
			Portuguese: '$por$',
			Hindi: '$hin$',
		};
		const languagePrefix =
			prefixMap[languageName as keyof typeof prefixMap];
		return languagePrefix || '';
	}

	public postQuestion(req: QuestionAddModel): Observable<Question> {
		return this.api.POST('/api/Question', req);
	}
}

export interface NewQuestion {
	categoryOrder: number | undefined;
	subOrder: number;
	chosenQuestionId: number;
	newScore?: number;
}

export interface QuestionAddModel {
	questionString: string;
	categoryQuestionId: string;
}
