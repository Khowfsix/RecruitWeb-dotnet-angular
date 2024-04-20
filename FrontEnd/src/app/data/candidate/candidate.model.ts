import { WebUser } from "../authentication/web-user.model";
import { CandidateHasSkill } from "../candidateHasSkill/candidate-has-skill.model";

export class Candidate {
	candidateId?: string;
	userId?: string;
	aboutMe?: string;
	isDeleted?: boolean;
	user?: WebUser;
	candidateHasSkills?: CandidateHasSkill[];
}
