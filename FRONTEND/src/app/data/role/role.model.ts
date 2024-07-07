export class Role {
	id?: string;
	name?: string;
	normalizedName?: string;
	concurrencyStamp?: string;
}

export class RoleAddModel {
	name?: string;
}

export class RoleUpdateModel {
	name?: string;
}
