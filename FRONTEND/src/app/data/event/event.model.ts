import { EventHasPosition } from "../eventHasPosition/eventHasPosition.model";
import { Recruiter } from "../recruiter/recruiter.model";

export class Event {
	eventId?: string;
	eventName?: string;
	recruiterId?: string;
	recruiter?: Recruiter;
	description?: string;
	imageURL?: string;
	applyPriority?: number;
	place?: string;
	startDateTime?: Date;
	endDateTime?: Date;
	maxParticipants?: number;
	isDeleted?: boolean;
	eventHasPositions?: EventHasPosition[];
}

export class EventFilter {
	search?: string;
	fromDate?: Date;
	toDate?: Date;
	fromMaxParticipants?: number;
	toMaxParticipants?: number;
}
