/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { Interview } from './interview.model';

@Injectable({
	providedIn: 'root'
})
export class InterviewService {

	constructor(private api: API) { }

	// private buildQueryParams(interviewerFilterModel: InterviewFilterModel): string {
	// 	let params = '';

	// 	if (interviewerFilterModel.search) {
	// 		params += `&search=${encodeURIComponent(interviewerFilterModel.search)}`;
	// 	}
	// 	if (interviewerFilterModel.isFreeTime) {
	// 		params += `&isFreeTime=${encodeURIComponent(interviewerFilterModel.isFreeTime)}`;
	// 	}
	// 	if (interviewerFilterModel.isBusyTime) {
	// 		params += `&isBusyTime=${encodeURIComponent(interviewerFilterModel.isBusyTime)}`;
	// 	}
	// 	if (interviewerFilterModel.fromDate) {
	// 		params += `&fromDate=${interviewerFilterModel.fromDate}`;
	// 	}
	// 	if (interviewerFilterModel.toDate) {
	// 		params += `&toDate=${interviewerFilterModel.toDate}`;
	// 	}
	// 	if (interviewerFilterModel.fromTime) {
	// 		params += `&fromTime=${interviewerFilterModel.fromTime}`;
	// 	}
	// 	if (interviewerFilterModel.toTime) {
	// 		params += `&toTime=${interviewerFilterModel.toTime}`;
	// 	}
	// 	return params;
	// }

	getAllByInterviewerId(interviewerId: string): Observable<Interview[]> {
		const url = '/api/Interview/GetInterviewsByInterviewer/' + interviewerId;
		return this.api.GET(url);
	}
}
