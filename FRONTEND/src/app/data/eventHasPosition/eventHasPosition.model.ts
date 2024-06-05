import { Position } from "../position/position.model";

export class EventHasPosition {
	eventHasPositionId?: string;
	eventId?: string;
	positionId?: string;
	position?: Position;
}
