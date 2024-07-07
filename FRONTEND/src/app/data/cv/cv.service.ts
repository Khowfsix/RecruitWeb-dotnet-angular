import { Injectable } from '@angular/core';
import { API } from '../api.service';
import { Observable } from 'rxjs';
import { CV } from './cv.model';
import { CvAddModel } from './cv-add-model.model';

@Injectable({
	providedIn: 'root'
})
export class CvService {

	constructor(
		private api: API
	) { }

	uploadNewCvFile(newCv: CvAddModel): Observable<CV[]> {
		return this.api.POST('/api/Cv', newCv);
	}

	getListCvsOfCandidate(candidateId: string): Observable<string | CV[]> {
		return this.api.GET(`/api/Cv/GetCandidateCvs/${candidateId}`);
	}


	getAllCVs(): Observable<CV[]> {
		return this.api.GET(`/api/Cv`);
	}


	updateCvOfCandidate() {

	}
}
