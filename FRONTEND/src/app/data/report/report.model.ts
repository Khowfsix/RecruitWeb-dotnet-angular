export class Report {
	reportId?: string;
	reportName?: string;
	userId?: string;
	reportType?: number;
	fileURL?: string;
	isDeleted?: boolean;
}

export class ReportAddModel {
	reportName?: string;
	userId?: string;
	reportType?: number;
	fileURL?: string;
}
export class ReportUpdateModel {
	reportName?: string;
	userId?: string;
	reportType?: number;
	fileURL?: string;
}


export class InterviewReport {
	interviewId?: string;
	candidateId?: string;
	candidateName?: string;
	interviewerId?: string;
	interviewerName?: string;
	applyDate?: Date;
	interviewDate?: Date;
	status?: string;
	score?: number;
}

export class ApplicationReport {
	applicationId?: string;
	fullName?: string;
	dateOfBirth?: Date;
	address?: string;
	experience?: string;
	cvName?: string;
	introduction?: string;
	education?: string;
	positionName?: string;
	description?: string;
	salary?: number;
	companyName?: string;
	languageName?: string;
	createdTime?: Date;
	candidate_Status?: number;
	company_Status?: number;
	priority?: string;
	isDeleted?: boolean;
}
