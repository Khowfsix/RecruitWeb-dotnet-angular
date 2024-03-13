import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Language } from './language.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class LanguageService {

	constructor(private api: API) { }

	getAllLanguagues(): Observable<Language[]> {
		return this.api.GET('/api/Language');
	}
}
