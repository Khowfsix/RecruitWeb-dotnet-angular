import { Question } from "../question/question.model";

export class Round {
	roundId?: string;
	interviewId?: string;
	questionId?: string;
	question?: Question;
	score?: number;
}
