import { Candidate } from "../candidate/candidate.model";

export class Education {
	educationId?: string;
	school?: string;
	major?: string;
	from?: Date
	to?: Date
	additionalDetails?: string;
	candidateId?: string;
	candidateViewModel?: Candidate;
}
