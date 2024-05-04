import { Candidate } from "../candidate/candidate.model";
import { Interviewer } from "../interviewer/interviewer.model";
import { Recruiter } from "../recruiter/recruiter.model";

export class WebUser {
	id?: string;
	fullName?: string;
	dateOfBirth?: Date
	imageURL?: string;
	userName?: string;
	email?: string;
	candidates?: Candidate[];
	interviewers?: Interviewer[];
	recruiters?: Recruiter[];
}
