import { Candidate } from "../candidate/candidate.model";

export class Award {
	awardId?: string;
	awardName?: string;
	awardOrganization?: string;
	issueDate?: Date;
	description?: string;
	candidateId?: string;
	candidate?: Candidate;
}
