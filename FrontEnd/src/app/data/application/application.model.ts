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

export class ApplicationAddModel {
	cvid?: string;
	positionId?: string
}


export class ApplyDialogDataInput {
	position?: Position;
	candidateId?: string;
}
