import { Skill } from "../skill/skill.model";

export class Requirements {
	requirementId?: string;
	positionId?: string;
	skillId?: string;
	skill?: Skill;
	experience?: string;
	notes?: string;
	isDeleted?: boolean;
}
