import { Recruiter } from "../recruiter/recruiter.model";

export class Event {
	eventId?: string;
	eventName?: string;
	recruiterId?: string;
	recruiter?: Recruiter;
	description?: string;
	imageURL?: string;
	place?: string;
	dateTimeEvent?: Date;
	maxParticipants?: number;
	isDeleted?: boolean;
}
