import { Skill } from "../skill/skill.model";

export class CandidateHasSkill {
	candidateHasSkillId?: number;
	candidateid?: number;
	skillId?: number;
	skill?: Skill
	level?: string;
}
