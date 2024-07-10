import { Injectable } from '@angular/core';
import { API } from '../api.service';
import { Observable } from 'rxjs';
import { Company, CompanyAddModel } from './company.model';

@Injectable({
	providedIn: 'root',
})
export class CompanyService {
	constructor(private api: API) { }

	getAll(): Observable<Company[]> {
		return this.api.GET('/api/Company');
	}

	deleteCompany(id?: string): Observable<boolean> {
		return this.api.DELETE('/api/Company/' + id);
	}
	createCompany(newCompany: CompanyAddModel): Observable<Company> {
		return this.api.POST('/api/Company/', newCompany);
	}
}
