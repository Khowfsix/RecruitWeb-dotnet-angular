import { Position } from "../position/position.model";

export class ApplicationHistory {
	applicationId?: string;
	positionId?: string;
	position?: Position;
	cvId?: string;
	createdTime?: Date;
	candidate_Status?: number;
	priority?: string;
}
