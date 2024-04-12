import { Position } from "../position/position.model";

export class ApplicationHistory {
	applicationId?: string;
	positionId?: string;
	position?: Position;
	cvId?: string;
	dateTime?: Date;
	candidate_Status?: number;
	priority?: string;
}
