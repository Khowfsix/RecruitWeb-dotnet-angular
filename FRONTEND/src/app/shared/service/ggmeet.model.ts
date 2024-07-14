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
		};
	};
}

export class EventAddModel {
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
		createRequest: {
			requestId?: string;
			conferenceSolutionKey: {
				type?: string;
			};
			status: {
				statusCode?: string;
			};
			// settings?: {
			// 	joinBeforeHost?: boolean;
			// };
		};
	};
}
