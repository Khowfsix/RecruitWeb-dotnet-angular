export class Skill {
	skillId?: string;
	skillName?: string;
	description?: string;
	isDeleted?: boolean;
}

export class SkillAddModel {
	skillName: string = "";
	description?: string;
}
