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

export class SkillUpdateModel {
	skillName: string = "";
	description?: string;
}
