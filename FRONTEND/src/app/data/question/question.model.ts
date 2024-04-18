import { CategoryQuestion } from "../categoryQuestion/categoryQuestion.model";

export class Question {
	questionId?: string;
	questionString?: string;
	categoryQuestionId?: string;
	categoryQuestion?: CategoryQuestion;
}
