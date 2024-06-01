import { Candidate } from "../candidate/candidate.model";
import { Interviewer } from "../interviewer/interviewer.model";
import { Recruiter } from "../recruiter/recruiter.model";

export class WebUser {
	id?: string;
	fullName?: string;
	title?: string;
	dateOfBirth?: Date
	imageURL?: string;
	userName?: string;
	email?: string;
	gender?: string;
	phoneNumber?: string;
	city?: string;
	address?: string;
	personalLink?: string;
	candidates?: Candidate[];
	interviewers?: Interviewer[];
	recruiters?: Recruiter[];
}
