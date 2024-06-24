/* eslint-disable prefer-const */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ZoomMeeting } from './zoom-meeting.model';
import { CookieService } from 'ngx-cookie-service';

export let userId = 'FPebXiYDR6ugZpJ6abzH4w';
export let refresh_token = 'eyJzdiI6IjAwMDAwMSIsImFsZyI6IkhTNTEyIiwidiI6IjIuMCIsImtpZCI6ImNkZTFhMDJhLTZhYzktNGEwZi05ZmQ3LWZjMGQwOTQ0YWE3OCJ9.eyJ2ZXIiOjksImF1aWQiOiJkMGRkOTA5OThjY2E2NTQ1N2ExZjE4MzJkM2E1YWZiMyIsImNvZGUiOiJNZGVsWGVDTTQ1UXJEUW5uYUJVUjEyak11SVZJdXBBWHciLCJpc3MiOiJ6bTpjaWQ6RjF1dWJtUHZUd2lCVmlhNXpMNEh6dyIsImdubyI6MCwidHlwZSI6MSwidGlkIjowLCJhdWQiOiJodHRwczovL29hdXRoLnpvb20udXMiLCJ1aWQiOiJGUGViWGlZRFI2dWdacEo2YWJ6SDR3IiwibmJmIjoxNzE4OTc4MTIzLCJleHAiOjE3MjY3NTQxMjMsImlhdCI6MTcxODk3ODEyMywiYWlkIjoiR01CUmhzOWRTWnl0S1M0MTdrV0xzZyJ9.-_qLMD9DKj_QaM4mPIriQ1dG8esiGfvOLIfcSOgp8GWGFWebb6jXvTpLxFTuNpoReRDRceWgQv9M2RqezvNv9g';
// export let access_token = 'eyJzdiI6IjAwMDAwMSIsImFsZyI6IkhTNTEyIiwidiI6IjIuMCIsImtpZCI6IjcyMTkzMzY1LTQ2YjAtNDA3ZS1hN2I3LWE0YjZmYmUyZjUzZCJ9.eyJ2ZXIiOjksImF1aWQiOiJkMGRkOTA5OThjY2E2NTQ1N2ExZjE4MzJkM2E1YWZiMyIsImNvZGUiOiJNZGVsWGVDTTQ1UXJEUW5uYUJVUjEyak11SVZJdXBBWHciLCJpc3MiOiJ6bTpjaWQ6RjF1dWJtUHZUd2lCVmlhNXpMNEh6dyIsImdubyI6MCwidHlwZSI6MCwidGlkIjo4LCJhdWQiOiJodHRwczovL29hdXRoLnpvb20udXMiLCJ1aWQiOiJGUGViWGlZRFI2dWdacEo2YWJ6SDR3IiwibmJmIjoxNzE5MTM1NTIwLCJleHAiOjE3MTkxMzkxMjAsImlhdCI6MTcxOTEzNTUyMCwiYWlkIjoiR01CUmhzOWRTWnl0S1M0MTdrV0xzZyJ9.9uE5U2No7uYP4UEY-p93rTyaLnf3TVQBevD7G1Dc4aLEO9ePuIWuHUfA26JOn4cRxbyAZudaxvkitG--_9gL0w';
export let authorization_token = 'RjF1dWJtUHZUd2lCVmlhNXpMNEh6dzpoRHlnOU5DbWtSVjFHYzJTNWNWbWJQdTVBVTF5ZmoweA==';
@Injectable({
	providedIn: 'root'
})
export class ZoomService {
	constructor(private http: HttpClient, private cookieService: CookieService) { }

	private zoom_api_proxy_url = '/zoom-proxy-server';
	private refreshtoken_zoom_api_proxy = '/refreshtoken-zoom-proxy-server';

	updateAccessToken(accessToken: string, expTime: number): boolean {
		this.cookieService.set('zoom_access_token', accessToken, expTime, '/');
		return true;
	}

	public updateRefreshToken(new_refresh_token: string) {
		refresh_token = new_refresh_token;
	}

	public callApiRefreshToken(): Observable<any[] | any> {
		return this.http.post<any[] | any>(
			this.refreshtoken_zoom_api_proxy,
			{
				grant_type: 'refresh_token',
				refresh_token: refresh_token,
			},
			{
				headers: {
					'Content-Type': 'application/x-www-form-urlencoded',
					'Authorization': 'Basic ' + authorization_token,
				}
			}
		);
	}

	public callApiCreateScheduledMeeting(meetingModel: ZoomMeeting): Observable<any[] | any> {
		return this.http.post<any[] | any>(
			`${this.zoom_api_proxy_url}/users/${userId}/meetings`,
			meetingModel,
			{
				headers: {
					'Content-Type': 'application/json',
					'Authorization': 'Bearer ' + this.cookieService.get('zoom_access_token'),
				}
			}
		);
	}
}
