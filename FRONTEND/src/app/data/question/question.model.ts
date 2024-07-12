/* eslint-disable @typescript-eslint/no-explicit-any */
import { CategoryQuestion } from "../categoryQuestion/categoryQuestion.model";

export class Question {
	questionId?: string;
	questionString?: string;
	categoryQuestionId?: string;
	categoryQuestion?: CategoryQuestion;

	questionSkill?: any[];
	questionsLanguage?: any[];
}
