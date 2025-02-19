import { CV } from '../cv/cv.model';
import { Interview } from '../interview/interview.model';
import { Position } from '../position/position.model';

export class Application {
	applicationId?: string;
	cv?: CV;
	position?: Position;
	createdTime?: Date;
	company_Status?: number;
	candidate_Status?: number;
	priority?: number;
	interviews?: Interview[];
	isDeleted?: boolean;
}

export class ApplicationAddModel {
	cvid?: string;
	positionId?: string;
	introduce?: string;
	priority?: number;
}

export class ApplyDialogDataInput {
	position?: Position;
	candidateId?: string;
	priority?: number;
}
