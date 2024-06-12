/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { Interview, InterviewFilterModel } from './interview.model';

@Injectable({
	providedIn: 'root'
})
export class InterviewService {

	constructor(private api: API) { }

	public updateStatus(interviewId: string, company_Status?: number, candidate_Status?: number) {
		let url = `/api/Interview/UpdateStatusInterview/${interviewId}?`;
		if (company_Status)
			url += `Company_Status=${company_Status}&`;
		if (candidate_Status)
			url += `Candidate_Status=${candidate_Status}&`;
		return this.api.PUT(url);
	}

	public update(interviewId: string, data: any) {
		return this.api.PUT('/api/Interview/' + interviewId, data);
	}

	public save(data: any, options?: any) {
		return this.api.POST('/api/Interview', data, options);
	}

	getInterviewsByCompanyId(companyId: string, interviewFilterModel?: any, sortString?: string): Observable<Interview[]> {
		let url = '/api/Interview/GetInterviewsByCompany/' + companyId + '?';
		if (sortString) {
			url += 'sortString=' + sortString;
		}
		if (interviewFilterModel) {
			url += this.buildQueryParams(interviewFilterModel);
		}
		return this.api.GET(url);
	}

	private buildQueryParams(interviewFilterModel: InterviewFilterModel): string {
		let params = '';
		if (interviewFilterModel.positionId) {
			params += `&positionId=${interviewFilterModel.positionId}`;
		}
		if (interviewFilterModel.search) {
			params += `&search=${interviewFilterModel.search}`;
		}
		if (interviewFilterModel.candidateStatus) {
			params += `&candidateStatus=${interviewFilterModel.candidateStatus}`;
		}
		if (interviewFilterModel.companyStatus) {
			params += `&companyStatus=${interviewFilterModel.companyStatus}`;
		}
		if (interviewFilterModel.fromDate) {
			params += `&fromDate=${interviewFilterModel.fromDate}`;
		}
		if (interviewFilterModel.toDate) {
			params += `&toDate=${interviewFilterModel.toDate}`;
		}
		if (interviewFilterModel.fromTime) {
			params += `&fromTime=${interviewFilterModel.fromTime}`;
		}
		if (interviewFilterModel.toTime) {
			params += `&toTime=${interviewFilterModel.toTime}`;
		}
		return params;
	}

	getAllByInterviewerId(interviewerId: string): Observable<Interview[]> {
		const url = '/api/Interview/GetInterviewsByInterviewer/' + interviewerId;
		return this.api.GET(url);
	}
}
