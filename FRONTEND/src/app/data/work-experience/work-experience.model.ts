import { Candidate } from "../candidate/candidate.model";

export class WorkExperience {
	workExperienceId?: string;
	jobTitle?: string;
	company?: string;
	from?: Date;
	to?: Date;
	description?: string;
	project?: string;
	candidateId?: string;
	candidate?: Candidate
}
