import { Injectable } from '@angular/core';
import { API } from '../api.service';
import { Observable } from 'rxjs';
import { Company } from './company.model';

@Injectable({
	providedIn: 'root',
})
export class CompanyService {
	constructor(private api: API) {}

	getAll(): Observable<Company[]> {
		return this.api.GET('/api/Company');
	}
}
