import { WebUser } from "../authentication/web-user.model";

export class Candidate {
	candidateId?: string;
	userId?: string;
	isDeleted?: boolean;
	user?: WebUser;
}
