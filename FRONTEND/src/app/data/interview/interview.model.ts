import { Interview_CandidateStatus, Interview_CompanyStatus, Interview_Type } from "../../shared/enums/EInterview.model";
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
	company_Status?: Interview_CompanyStatus;
	candidate_Status?: Interview_CandidateStatus;
	notes?: string;
	priority?: string;
	isDeleted?: boolean;
	addressOrStartURL?: string;
	detailLocationOrJoinURL?: string;
	meetingDate?: Date;
	startTime?: string;
	interviewType?: Interview_Type;
	rounds?: Round[];
}

export class InterviewFilterModel {
	search?: string;
	sortString?: string;
	candidateStatus?: Interview_CandidateStatus;
	companyStatus?: Interview_CompanyStatus;
	fromTime?: string;
	toTime?: string;
	fromDate?: Date;
	toDate?: Date;
	interviewType?: Interview_Type;
	positionId?: string;
}
