/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { API } from '../api.service';
import { Observable } from 'rxjs';
import { Company } from './company.model';

@Injectable({
	providedIn: 'root',
})
export class CompanyService {
	constructor(private api: API) { }

	getAll(): Observable<Company[]> {
		return this.api.GET('/api/Company');
	}

	UpdateStatus(companyId?: string, isActived?: boolean, isDeleted?: boolean) {
		const url = `/api/Company/UpdateStatus/${companyId}?isActived=${isActived}&isDeleted=${isDeleted}`
		return this.api.PUT(url);
	}

	deleteCompany(id?: string): Observable<boolean> {
		return this.api.DELETE('/api/Company/' + id);
	}
	createCompany(newCompany: any): Observable<Company> {
		return this.api.POST('/api/Company/', newCompany);
	}
}
