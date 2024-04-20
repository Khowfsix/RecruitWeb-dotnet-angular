import { Application } from "../application/application.model";
import { Candidate } from "../candidate/candidate.model";
import { CvHasSkill } from "../cvHasSkill/cv-has-skill.model";
import { Skill } from "../skill/skill.model";

export class CV {
	cvid?: string;
	candidateId?: string;
	candidate?: Candidate;
	cvPdf?: string;
	cvName?: string;
	aboutMe?: string;
	isDeleted?: boolean;
	isDefault?: boolean;
	applications?: Application[];
	skills?: Skill[];
	cvHasSkills?: CvHasSkill[];
}
