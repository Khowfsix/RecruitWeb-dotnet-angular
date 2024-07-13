import { WebUser } from '../authentication/web-user.model';
import { Company } from '../company/company.model';

export class Interviewer {
	interviewerId?: string;
	userId?: string;
	companyId?: string;
	company?: Company;
	user?: WebUser;
	isDeleted?: boolean;
	daysToLastInterview?: number;
}

export class InterviewerAddModel {
	userId?: string;
	companyId?: string;
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
