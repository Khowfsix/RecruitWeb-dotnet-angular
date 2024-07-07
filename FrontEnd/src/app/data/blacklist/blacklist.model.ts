export class BlackList {
	blackListId?: string;
	candidateId?: string;
	reason?: string;
	dateTime?: Date;
	status?: number;
	isDeleted?: boolean;
}
export class BlackListAddModel {
	candidateId?: string;
	reason?: string;
	dateTime?: Date;
	isDeleted?: boolean;
}
