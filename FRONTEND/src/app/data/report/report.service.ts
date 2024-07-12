import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { ApplicationReport, InterviewReport, Report, ReportAddModel, ReportUpdateModel } from './report.model';

@Injectable({
	providedIn: 'root'
})
export class ReportService {

	constructor(private api: API) { }
	public deleteReport(ReportId?: string): Observable<boolean> {
		return this.api.DELETE('/api/Report/' + ReportId);
	}

	public updateReport(ReportId: string, newReport: ReportUpdateModel): Observable<Report> {
		return this.api.PUT('/api/Report/' + ReportId, newReport);
	}

	public createReport(newReport: ReportAddModel): Observable<Report> {
		return this.api.POST('/api/Report', newReport);
	}

	public InterviewReport(fromDate: Date, toDate: Date): Observable<InterviewReport[]> {
		let url = '/api/Report/InterviewReport?';
		if (fromDate)
			url += `fromDate=${fromDate}&`
		if (toDate)
			url += `toDate=${toDate}&`
		return this.api.POST(url)
	}

	public ApplicationReport(fromDate: Date, toDate: Date): Observable<ApplicationReport[]> {
		let url = '/api/Report/ApplicationReport?';
		if (fromDate)
			url += `fromDate=${fromDate}&`
		if (toDate)
			url += `toDate=${toDate}&`
		return this.api.POST(url)
	}

	public getAllReports(): Observable<Report[]> {
		return this.api.GET('/api/Report');
	}
}
