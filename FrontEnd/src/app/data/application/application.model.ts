import { CV } from "../cv/cv.model";
import { Position } from "../position/position.model";

export class Application {
	applicationId?: string;
	cv?: CV;
	position?: Position;
	createdTime?: Date;
	company_Status?: number;
	candidate_Status?: number;
	priority?: string;
}
