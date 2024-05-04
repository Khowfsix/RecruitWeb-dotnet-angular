/* eslint-disable @typescript-eslint/no-explicit-any */
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
	providedIn: 'root'
})
export class OpenStreetMapService {
	private apiKey = 'AIzaSyCX0M6yTLS3MYZbexIVTN47g4E2u-y3wcg';
	private searchUrl = 'https://nominatim.openstreetmap.org/search';

	constructor(private http: HttpClient) { }

	public search(search: string, limit?: number, addressdetails?: boolean) {
		let url = `${this.searchUrl}?q=${encodeURIComponent(search)}&format=json`;

		if (limit) {
			url += `&limit=${limit}`;
		}

		if (addressdetails !== undefined) {
			url += `&addressdetails=${addressdetails}`;
		}

		// Add headers to specify CORS mode
		const headers = new HttpHeaders({
			'Content-Type': 'application/json',
			'Access-Control-Allow-Origin': '*'
		});

		// Make the request with CORS mode
		return this.http.get<any>(url, { headers });
	}

}
