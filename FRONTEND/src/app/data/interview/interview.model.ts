import { Application } from "../application/application.model"
import { Interviewer } from "../interviewer/interviewer.model"
import { Recruiter } from "../recruiter/recruiter.model"
import { Round } from "../round/round.module";

export class Interview {
	interviewId?: string;
	interviewerId?: string;
	endTime?: string;
	interviewer?: Interviewer;
	recruiterId?: string;
	recruiter?: Recruiter;
	applicationId?: string;
	application?: Application;
	company_Status?: string;
	candidate_Status?: string;
	notes?: string;
	priority?: string;
	isDeleted?: boolean;
	address?: string;
	detailLocation?: string;
	meetingDate?: Date;
	startTime?: string;
	rounds?: Round[];
}

