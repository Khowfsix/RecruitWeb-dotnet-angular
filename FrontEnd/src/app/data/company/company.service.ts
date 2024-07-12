/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { API } from '../api.service';
import { Observable } from 'rxjs';
import { Company, CompanyUpdateModel } from './company.model';

@Injectable({
	providedIn: 'root',
})
export class CompanyService {
	constructor(private api: API) { }

	getAll(): Observable<Company[]> {
		return this.api.GET('/api/Company');
	}

	getById(companyId?: string): Observable<Company> {
		return this.api.GET('/api/Company/' + companyId);
	}

	update(companyId?: string, addModel?: CompanyUpdateModel) {
		const url = `/api/Company/${companyId}`
		return this.api.PUT(url, addModel);
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
