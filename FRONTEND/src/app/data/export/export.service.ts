/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class ExportService {

	constructor(private api: API) { }

	public ExportInterviewReport(fromDate: Date, toDate: Date): Observable<any> {
		let url = '/api/Export/ExportInterviewReport?';
		if (fromDate)
			url += `fromDate=${fromDate}&`
		if (toDate)
			url += `toDate=${toDate}&`
		return this.api.POST(url, {}, { responseType: 'blob', observe: 'response' })
	}

	public ExportApplicationReport(fromDate: Date, toDate: Date): Observable<any> {
		let url = '/api/Export/ExportApplicationReport?';
		if (fromDate)
			url += `fromDate=${fromDate}&`
		if (toDate)
			url += `toDate=${toDate}&`
		return this.api.POST(url, {}, { responseType: 'blob', observe: 'response' })
	}
}
