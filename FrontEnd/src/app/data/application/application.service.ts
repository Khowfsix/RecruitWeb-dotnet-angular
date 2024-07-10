/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { Application, ApplicationAddModel } from './application.model';

@Injectable({
	providedIn: 'root'
})
export class ApplicationService {

	constructor(private api: API) { }

	getAll(): Observable<Application[]> {
		return this.api.GET('/api/Application');
	}

	deleteApplication(id?: string): Observable<boolean> {
		console.log(`start`);
		return this.api.DELETE('/api/Application/' + id);
	}

	createApplication(newApplication: ApplicationAddModel): Observable<Application> {
		return this.api.POST('/api/Application/', newApplication);
	}

	updateStatusApplication(applicationId: string, companyStatus?: number, candidateStatus?: number): Observable<any> {
		let url = '/api/Application/UpdateStatusApplication/' + applicationId + '?';
		if (companyStatus) {
			url += 'Company_Status=' + companyStatus;
		}
		if (candidateStatus) {
			url += 'Candidate_Status=' + candidateStatus;
		}
		return this.api.PUT(url);
	}

	getAllByPositionId(positionId?: string, search?: string, sortString?: string,
		notInBlackList?: boolean, candidateStatus?: number, companyStatus?: number, fromDate?: Date, toDate?: Date): Observable<Application[]> {
		let url = '/api/Application?positionId=' + positionId;
		if (search)
			url = url + '&search=' + search;
		if (sortString)
			url = url + '&sortString=' + sortString;
		if (notInBlackList)
			url = url + '&notInBlackList=' + notInBlackList;
		if (candidateStatus)
			url = url + '&candidateStatus=' + candidateStatus;
		if (companyStatus)
			url = url + '&companyStatus=' + companyStatus;
		if (fromDate)
			url = url + '&fromDate=' + fromDate;
		if (toDate)
			url = url + '&toDate=' + toDate;
		return this.api.GET(url);
	}

	postNewApplication(data: ApplicationAddModel) {
		return this.api.POST('/api/Application', data);
	}


	getApplicationsOfCandidate(candidateId: string) {
		return this.api.GET('api/Application/GetApplicationsOfCandidate/' + candidateId);
	}
}
