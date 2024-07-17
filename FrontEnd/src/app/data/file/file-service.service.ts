/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root',
})
export class FileService {
	constructor(private api: API) {}

	public uploadFile(formFile: FormData): Observable<any> {
		// let headers = new HttpHeaders();
		// const boundary = Math.random().toString().replace(/\./g, '-'); // Generate random boundary
		// headers = headers.append('Content-Type', `multipart/form-data; boundary=${boundary}`);
		// return this.api.POST('/api/File/UploadFile', formFile, { headers: headers });
		return this.api.POST('/api/File/UploadFile', formFile);
	}

	public updateFile(data: FormData): Observable<any> {
		return this.api.PUT('/api/File/UpdateFile', data);
	}

	public deleteFile(url?: string): Observable<any> {
		return this.api.DELETE('/api/File/DeleteFile?url=' + url);
	}
}
