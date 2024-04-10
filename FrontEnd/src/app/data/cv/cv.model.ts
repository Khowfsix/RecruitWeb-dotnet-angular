import { Candidate } from "../candidate/candidate.model";
import { Certificate } from "../certificate/certificate.model";
import { CvHasSkill } from "../cvHasSkill/cv-has-skill.model";
import { Skill } from "../skill/skill.model";

export class CV {
	cvid?: string;
	candidateId?: string;
	candidate?: Candidate;
	experience?: string;
	cvPdf?: string;
	cvName?: string;
	introduction?: string;
	education?: string;
	isDeleted?: boolean;
	skills?: Skill[]
	cvHasSkills?: CvHasSkill[]
	certificates?: Certificate
}
