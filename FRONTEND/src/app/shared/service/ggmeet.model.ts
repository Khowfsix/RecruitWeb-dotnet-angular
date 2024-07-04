export class GGMeeting {
	summary?: string;
	location?: string;
	description?: string;
	start?: {
		dateTime?: string;
		timeZone?: string;
	};
	end?: {
		dateTime?: string;
		timeZone?: string;
	};
	conferenceData?: {
		createRequest?: {
			requestId?: string;
		}
	}
}
