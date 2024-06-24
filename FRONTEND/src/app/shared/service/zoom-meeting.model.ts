export class ZoomMeeting {
	topic?: string;
	default_password?: boolean;
	pre_schedule?: boolean;
	schedule_for?: string;
	template_id?: string;
	type?: 1 | 2 | 3 | 8;
	start_time?: string;
	duration?: number;
	timezone?: string;
	agenda?: string;
	password?: string;
	settings?: Settings;
	recurrence?: Recurrence;
	tracking_fields?: TrackingField[];
}

export class TrackingField {
	field?: string;
	value?: string;
}

class Settings {
	host_video?: boolean;
	participant_video?: boolean;
	join_before_host?: boolean;
	mute_upon_entry?: boolean;
	watermark?: boolean;
	use_pmi?: boolean;
	approval_type?: 0 | 1 | 2;
	audio?: 'both' | 'telephony' | 'voip';
	auto_recording?: 'local' | 'cloud' | 'none';
	alternative_hosts?: string;
}

class Recurrence {
	type?: 1 | 2 | 3;
	repeat_interval?: number;
	weekly_days?: string;
	end_times?: number;
}
