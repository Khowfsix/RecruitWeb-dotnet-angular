import { Candidate } from "../candidate/candidate.model";

export class PersonalProject {
	personalProjectId?: string;
	projectName?: string;
	from?: Date;
	to?: Date;
	shortDescription?: string;
	projectUrl?: string;
	candidateId?: string;
	candidate?: Candidate
}
