import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { Report } from './report.model';

@Injectable({
	providedIn: 'root'
})
export class ReportService {

	constructor(private api: API) { }

	getAllReports(): Observable<Report[]> {
		return this.api.GET('/api/Report');
	}
}
