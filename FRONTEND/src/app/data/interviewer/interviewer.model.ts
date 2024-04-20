import { WebUser } from "../authentication/web-user.model"

export class Interviewer {
	interviewerId?: string;
	userId?: string;
	companyId?: string;
	user?: WebUser;
	isDeleted?: boolean;
	daysToLastInterview?: number;
}

export class InterviewerFilterModel {
	search?: string;
	isFreeTime?: boolean;
	isBusyTime?: boolean;
	fromTime?: string;
	toTime?: string;
	fromDate?: Date;
	toDate?: Date;
}

