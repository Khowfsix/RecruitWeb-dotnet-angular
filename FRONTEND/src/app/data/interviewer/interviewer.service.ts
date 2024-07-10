/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { Interviewer, InterviewerAddModel, InterviewerFilterModel } from './interviewer.model';

@Injectable({
	providedIn: 'root'
})
export class InterviewerService {

	constructor(private api: API) { }

	private buildQueryParams(interviewerFilterModel: InterviewerFilterModel): string {
		let params = '';

		if (interviewerFilterModel.search) {
			params += `&search=${encodeURIComponent(interviewerFilterModel.search)}`;
		}
		if (interviewerFilterModel.isFreeTime) {
			params += `&isFreeTime=${encodeURIComponent(interviewerFilterModel.isFreeTime)}`;
		}
		if (interviewerFilterModel.isBusyTime) {
			params += `&isBusyTime=${encodeURIComponent(interviewerFilterModel.isBusyTime)}`;
		}
		if (interviewerFilterModel.fromDate) {
			params += `&fromDate=${interviewerFilterModel.fromDate}`;
		}
		if (interviewerFilterModel.toDate) {
			params += `&toDate=${interviewerFilterModel.toDate}`;
		}
		if (interviewerFilterModel.fromTime) {
			params += `&fromTime=${interviewerFilterModel.fromTime}`;
		}
		if (interviewerFilterModel.toTime) {
			params += `&toTime=${interviewerFilterModel.toTime}`;
		}
		return params;
	}

	getAll(companyId?: string, interviewFilterModel?: any, sortString?: string): Observable<Interviewer[]> {
		let url = '/api/Interviewer';
		if (companyId) {
			url += '?companyId=' + companyId;
			if (sortString) {
				url += '&sortString=' + sortString;
			}
			if (interviewFilterModel)
				url += this.buildQueryParams(interviewFilterModel);
		}
		return this.api.GET(url);
	}

	public createInterviewer(addModel: InterviewerAddModel, options?: any) {
		return this.api.POST('/api/Interviewer', addModel, options);
	}
	public delete(id?: string) {
		return this.api.DELETE('/api/Interviewer/' + id);
	}
}
