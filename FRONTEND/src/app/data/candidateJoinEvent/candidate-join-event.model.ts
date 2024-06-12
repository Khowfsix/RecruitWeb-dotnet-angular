import { Candidate } from "../candidate/candidate.model";
import { Event } from "../event/event.model";

export class CandidateJoinEvent {
	candidateJoinEventId?: string;
	candidateid?: string;
	eventId?: string;
	dateJoin?: Date;
	event?: Event;
	candidate?: Candidate;
}
