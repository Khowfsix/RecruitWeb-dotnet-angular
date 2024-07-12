/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class ExportService {

	constructor(private api: API) { }

	public ExportBlacklist(): Observable<any> {
		const url = '/api/Export/ExportBlacklist';
		return this.api.POST(url, {}, { responseType: 'blob', observe: 'response' })
	}

	public ExportCertificate(): Observable<any> {
		const url = '/api/Export/ExportCertificate';
		return this.api.POST(url, {}, { responseType: 'blob', observe: 'response' })
	}

	public ExportSkill(): Observable<any> {
		const url = '/api/Export/ExportSkill';
		return this.api.POST(url, {}, { responseType: 'blob', observe: 'response' })
	}

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
