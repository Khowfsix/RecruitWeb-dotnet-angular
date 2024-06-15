/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API } from '../api.service';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class FileService {

	constructor(private api: API) { }

	public uploadFile(formFile: FormData): Observable<any> {
		const boundary = '---------------------------7db2f68a03849578';
		let headers = new HttpHeaders();
		headers = headers.append('Content-Type', `multipart/form-data; boundary=${boundary}`);
		// headers = headers.append('enctype', 'multipart/form-data');
		// The browser will automatically add this header, but the server needs it
		// We can't use formFile.getBoundary() because it's non-standard and not supported in Safari
		// Instead, we'll manually set the Content-Type header to include the boundary

		return this.api.POST('/api/File/UploadFile', formFile, { headers: headers });
	}

	public updateFile(data: FormData): Observable<any> {
		return this.api.PUT('/api/File/UpdateFile', data);
	}

	public deleteFile(url: string): Observable<any> {
		return this.api.DELETE('/api/File/DeleteFile?url=' + url);
	}
}
