import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Certificate } from './certificate.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class CertificateService {

	constructor(private api: API) { }

	getAllCertificates(): Observable<Certificate[]> {
		return this.api.GET('/api/Certificate');
	}
}
