import { Candidate } from "../candidate/candidate.model";
import { Event } from "../event/event.model";

export class CandidateJoinEvent {
	candidateJoinEventId?: number;
	candidateid?: number;
	eventId?: number;
	dateJoin?: Date;
	event?: Event;
	candidate?: Candidate;
}
