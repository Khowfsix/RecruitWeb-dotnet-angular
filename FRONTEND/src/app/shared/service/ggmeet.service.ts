import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable, NgZone } from '@angular/core';
import { AuthConfig, OAuthService } from 'angular-oauth2-oidc';
import { WINDOW } from './window.token';
// import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';

@Injectable({
	providedIn: 'root',
})
export class GGMeetService {
	private authConfig: AuthConfig = {
		issuer: 'https://accounts.google.com',
		redirectUri: `${this._window && this._window.location ? this._window.location.origin : ''}/meet/login/callback/`,
		clientId: '402442749760-23gqfj74lcb44tt794kskrud80389vgm.apps.googleusercontent.com',
		scope: 'openid profile email https://www.googleapis.com/auth/calendar https://www.googleapis.com/auth/calendar.readonly https://www.googleapis.com/auth/calendar.events https://www.googleapis.com/auth/calendar.events.readonly',
		strictDiscoveryDocumentValidation: false,
		showDebugInformation: true,
		silentRefreshRedirectUri: this._window && this._window.location ? `${this._window.location.origin}/silent-refresh.html` : undefined,
		useSilentRefresh: true,
	};

	// private authConfig: AuthConfig = {
	// 	issuer: 'https://accounts.google.com',
	// 	redirectUri: `${this._window && this._window.location ? this._window.location.origin : ''}/meet/login/callback/`,
	// 	clientId: '402442749760-23gqfj74lcb44tt794kskrud80389vgm.apps.googleusercontent.com',
	// 	scope: 'openid profile email https://www.googleapis.com/auth/calendar https://www.googleapis.com/auth/calendar.readonly https://www.googleapis.com/auth/calendar.events https://www.googleapis.com/auth/calendar.events.readonly',
	// 	strictDiscoveryDocumentValidation: false,
	// 	showDebugInformation: true,
	// 	silentRefreshRedirectUri: this._window.location.origin + '/silent-refresh.html',
	// 	useSilentRefresh: true,
	// 	// sessionChecksEnabled: true,
	// 	// timeoutFactor: 0.75,
	// };

	constructor(
		private oauthService: OAuthService,
		private ngZone: NgZone,
		private http: HttpClient,
		@Inject(WINDOW) private _window: Window
	) {
		this.configure();
	}

	private configure() {
		this.oauthService.configure(this.authConfig);
		// this.oauthService.tokenValidationHandler = new JwksValidationHandler();
		this.oauthService.loadDiscoveryDocumentAndTryLogin();
		this.oauthService.setupAutomaticSilentRefresh();
	}


	public getAllMyCalendars() {
		// DEVELOPMENT
		const url = '/proxy-server/https://www.googleapis.com/calendar/v3/users/me/calendarList'

		// DEPLOYMENT
		// const url = 'https://www.googleapis.com/calendar/v3/users/me/calendarList';
		const headers = new HttpHeaders({
			'Authorization': 'Bearer ' + this.oauthService.getAccessToken(),
			'Content-Type': 'application/json'
		});
		return this.http.get(url, { headers });
	}

	// public creatEventIncludeMeeting() {
	// 	const url = `https://www.googleapis.com/calendar/v3/calendars/20110696@student.hcmute.edu.vn/events?conferenceDataVersion=1`;

	// 	return this.http.get()
	// }

	public async loginWithPopup(callbackURL: string) {
		const width = 500;
		const height = 600;
		const left = (this._window.screen.width / 2) - (width / 2);
		const top = (this._window.screen.height / 2) - (height / 2);

		try {
			const loginUrl = `${this._window.origin}/meet/login`;
			// console.log('loginUrl', loginUrl);
			const popup = this._window.open(
				loginUrl,
				'Login with Google',
				`width = ${width}, height = ${height}, top = ${top}, left = ${left} `
			);

			const interval = setInterval(() => {
				try {
					// console.log('interval')
					const receivedData = this.handlePopupMessage(callbackURL);
					if (popup?.closed || receivedData === true) {
						clearInterval(interval);
						// const fragment = this.cookieService.get(GGMEET_FRAGMENT_COOKIE_NAME);
						// const fragment = localStorage.getItem(GGMEET_FRAGMENT_COOKIE_NAME);
						// console.log('popup?.closed')
						// console.log('fragment', fragment)
					}
				} catch (e) {
					console.error(e);
				}
			}, 1000);
		} catch (error) {
			console.error('Error creating login URL', error);
		}
	}

	public login() {
		this.oauthService.initCodeFlow();
	}

	private handlePopupMessage(callbackURL: string) {
		let receivedData = false;
		this._window.addEventListener('message', (event: MessageEvent) => {
			if (event.origin !== this._window.location.origin) {
				return;
			}

			const data = event.data;
			if (data) {
				receivedData = true;
				// console.log('Data received from popup:', data);
				this.ngZone.run(() => {

					history.pushState(null, '', `${callbackURL}#` + data);
					this.oauthService.tryLogin(
						{
							disableOAuth2StateCheck: true,
							disableNonceCheck: true,
						}
					).then(() => {
						// if (this.oauthService.hasValidAccessToken()) {
						// 	console.log('Login successful!');
						// } else {
						// 	console.log('Login failed');
						// }
					})
					// .catch((error) => {
					// 	// console.error('Login failed', error);
					// });
				});
			}


		}, { once: true });
		return receivedData;
	}

	public logout() {
		this.oauthService.logOut();
	}

	public get scope() {
		return this.oauthService.scope;
	}


	public get accessTokenExpiration() {
		return this.oauthService.getAccessTokenExpiration();
	}

	public get isLoggedIn() {
		return this.oauthService.hasValidAccessToken();
	}

	public get identityClaims() {
		return this.oauthService.getIdentityClaims();
	}

	public get accessToken() {
		return this.oauthService.getAccessToken();
	}
}
