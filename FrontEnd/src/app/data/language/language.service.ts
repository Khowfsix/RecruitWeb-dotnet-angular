import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Language, LanguageAddModel, LanguageUpdateModel } from './language.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class LanguageService {

	constructor(private api: API) { }

	getAllLanguagues(): Observable<Language[]> {
		return this.api.GET('/api/Language');
	}

	deleteLanguage(id?: string): Observable<boolean> {
		return this.api.DELETE('/api/Language/' + id);
	}

	createLanguage(newLanguage: LanguageAddModel): Observable<Language> {
		return this.api.POST('/api/Language/', newLanguage);
	}
	updateLanguage(LanguageId: string, newLanguage: LanguageUpdateModel): Observable<Language> {
		return this.api.PUT('/api/Language/' + LanguageId, newLanguage);
	}
}
