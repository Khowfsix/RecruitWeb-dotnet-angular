import { EventEmitter, Injectable, NgZone, Output } from '@angular/core';
import { AuthConfig, OAuthService } from 'angular-oauth2-oidc';
// import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';



@Injectable({
	providedIn: 'root',
})
export class GGMeetService {
	private authConfig: AuthConfig = {
		issuer: 'https://accounts.google.com',
		redirectUri: 'http://localhost:4200/meet/login/callback/',
		clientId: '402442749760-23gqfj74lcb44tt794kskrud80389vgm.apps.googleusercontent.com',
		scope: 'openid profile email https://www.googleapis.com/auth/calendar https://www.googleapis.com/auth/calendar.events https://www.googleapis.com/auth/calendar.events.readonly',
		strictDiscoveryDocumentValidation: false,
		showDebugInformation: true,
		// silentRefreshRedirectUri: window.location.origin + '/silent-refresh.html',
		// useSilentRefresh: true,
		sessionChecksEnabled: true,
		timeoutFactor: 0.75,
	};

	public GGMEET_FRAGMENT_COOKIE_NAME = 'GGMEET_FRAGMENT';
	public GGMEET_ACCESS_TOKEN_COOKIE_NAME = 'GGMEET_ACCESS_TOKEN';
	constructor(
		private oauthService: OAuthService,
		private cookieService: CookieService,
		private router: Router,
		private ngZone: NgZone
	) {
		this.configure();
	}

	@Output() public oauthServiceEmit = new EventEmitter<OAuthService>();
	public dataEmit = new EventEmitter<string>();

	public emitData(newService: string) {
		this.dataEmit.emit(newService);
	}

	public isLoggedIn() {
		return this.oauthService.hasValidAccessToken();
	}

	public async tryLogin(): Promise<boolean> {
		// const fragment = this.cookieService.get(this.GGMEET_FRAGMENT_COOKIE_NAME);
		// if (fragment) {
		// console.log('fragment: 123123 ', fragment);
		await this.oauthService.tryLogin({
			// customHashFragment: fragment,
			disableOAuth2StateCheck: true,
			preventClearHashAfterLogin: false,
			onLoginError: (error) => {
				console.error('Login error', error);
			},
			onTokenReceived: () => {
				console.log('Login success');
			}
		});
		if (this.oauthService.hasValidAccessToken()) {
			console.log('Login Successful');
			console.log('this.ggmeetService.isLoggedIn', this.oauthService.hasValidAccessToken());
			console.log('Access Token:', this.oauthService.getAccessToken());
			return true;
		} else {
			console.log('Login Failed');
			return false;
		}
		// } else {
		// 	console.log('Not found cookie');
		// 	return Promise.resolve(false);
		// }
	}


	public emitOauthService(newService: OAuthService) {
		this.oauthServiceEmit.emit(newService);
	}

	private configure() {
		this.oauthService.configure(this.authConfig);
		// this.oauthService.tokenValidationHandler = new JwksValidationHandler();
		this.oauthService.loadDiscoveryDocumentAndTryLogin();
		this.oauthService.setupAutomaticSilentRefresh();
	}

	public login() {
		this.oauthService.initLoginFlow();
	}

	public logout() {
		this.oauthService.logOut();
	}

	// public get identityClaims() {
	// 	const claims = this.oauthService.getIdentityClaims();
	// 	return claims ? claims : null;
	// }

	// public get accessToken() {
	// 	return this.oauthService.getAccessToken();
	// }
}

// /* eslint-disable prefer-const */
// /* eslint-disable @typescript-eslint/no-unused-vars */
// /* eslint-disable @typescript-eslint/no-explicit-any */
// import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
// import { CookieService } from 'ngx-cookie-service';
// import { AuthConfig, LoginOptions, OAuthService } from 'angular-oauth2-oidc';
// // export let userId = 'FPebXiYDR6ugZpJ6abzH4w';
// // export let refresh_token = 'eyJzdiI6IjAwMDAwMSIsImFsZyI6IkhTNTEyIiwidiI6IjIuMCIsImtpZCI6ImNkZTFhMDJhLTZhYzktNGEwZi05ZmQ3LWZjMGQwOTQ0YWE3OCJ9.eyJ2ZXIiOjksImF1aWQiOiJkMGRkOTA5OThjY2E2NTQ1N2ExZjE4MzJkM2E1YWZiMyIsImNvZGUiOiJNZGVsWGVDTTQ1UXJEUW5uYUJVUjEyak11SVZJdXBBWHciLCJpc3MiOiJ6bTpjaWQ6RjF1dWJtUHZUd2lCVmlhNXpMNEh6dyIsImdubyI6MCwidHlwZSI6MSwidGlkIjowLCJhdWQiOiJodHRwczovL29hdXRoLnpvb20udXMiLCJ1aWQiOiJGUGViWGlZRFI2dWdacEo2YWJ6SDR3IiwibmJmIjoxNzE4OTc4MTIzLCJleHAiOjE3MjY3NTQxMjMsImlhdCI6MTcxODk3ODEyMywiYWlkIjoiR01CUmhzOWRTWnl0S1M0MTdrV0xzZyJ9.-_qLMD9DKj_QaM4mPIriQ1dG8esiGfvOLIfcSOgp8GWGFWebb6jXvTpLxFTuNpoReRDRceWgQv9M2RqezvNv9g';
// // export let access_token = 'eyJzdiI6IjAwMDAwMSIsImFsZyI6IkhTNTEyIiwidiI6IjIuMCIsImtpZCI6IjcyMTkzMzY1LTQ2YjAtNDA3ZS1hN2I3LWE0YjZmYmUyZjUzZCJ9.eyJ2ZXIiOjksImF1aWQiOiJkMGRkOTA5OThjY2E2NTQ1N2ExZjE4MzJkM2E1YWZiMyIsImNvZGUiOiJNZGVsWGVDTTQ1UXJEUW5uYUJVUjEyak11SVZJdXBBWHciLCJpc3MiOiJ6bTpjaWQ6RjF1dWJtUHZUd2lCVmlhNXpMNEh6dyIsImdubyI6MCwidHlwZSI6MCwidGlkIjo4LCJhdWQiOiJodHRwczovL29hdXRoLnpvb20udXMiLCJ1aWQiOiJGUGViWGlZRFI2dWdacEo2YWJ6SDR3IiwibmJmIjoxNzE5MTM1NTIwLCJleHAiOjE3MTkxMzkxMjAsImlhdCI6MTcxOTEzNTUyMCwiYWlkIjoiR01CUmhzOWRTWnl0S1M0MTdrV0xzZyJ9.9uE5U2No7uYP4UEY-p93rTyaLnf3TVQBevD7G1Dc4aLEO9ePuIWuHUfA26JOn4cRxbyAZudaxvkitG--_9gL0w';
// // export let authorization_token = 'RjF1dWJtUHZUd2lCVmlhNXpMNEh6dzpoRHlnOU5DbWtSVjFHYzJTNWNWbWJQdTVBVTF5ZmoweA==';
// @Injectable({
// 	providedIn: 'root',
// })
// export class GGMeetService {
// 	public GGMEET_FRAGMENT_COOKIE_NAME = 'GGMEET_FRAGMENT';

// 	private authConfig: AuthConfig = {
// 		issuer: 'https://accounts.google.com',
// 		strictDiscoveryDocumentValidation: false,
// 		clientId: '402442749760-23gqfj74lcb44tt794kskrud80389vgm.apps.googleusercontent.com',
// 		redirectUri: 'http://localhost:4200/meet/login/callback/',
// 		scope: 'openid profile email https://www.googleapis.com/auth/calendar https://www.googleapis.com/auth/calendar.events https://www.googleapis.com/auth/calendar.events.readonly',
// 		// scope: 'https://www.googleapis.com/auth/calendar https://www.googleapis.com/auth/calendar.events https://www.googleapis.com/auth/calendar.events.readonly',
// 		// responseType: 'code',
// 		// showDebugInformation: true,
// 		// useSilentRefresh: true,
// 		// oidc: true,
// 		// requestAccessToken: true,
// 	};

// 	// private authConfig: AuthConfig = {
// 	// 	issuer: 'https://accounts.google.com',
// 	// 	redirectUri: window.location.origin,
// 	// 	clientId: '402442749760-23gqfj74lcb44tt794kskrud80389vgm.apps.googleusercontent.com',
// 	// 	scope: 'https://www.googleapis.com/auth/calendar https://www.googleapis.com/auth/calendar.events https://www.googleapis.com/auth/calendar.events.readonly',
// 	// 	responseType: 'code',
// 	// 	strictDiscoveryDocumentValidation: false,
// 	// 	showDebugInformation: true,
// 	// 	useSilentRefresh: true,
// 	// 	oidc: true,
// 	// 	requestAccessToken: true,
// 	// };

// 	constructor(
// 		private oauthService: OAuthService,
// 		private cookieService: CookieService,
// 	) {
// 		this.oauthService.configure(this.authConfig);
// 		this.oauthService.setupAutomaticSilentRefresh();
// 		this.oauthService.loadDiscoveryDocumentAndTryLogin();
// 	}

// 	public get name(): string {
// 		const claims = this.oauthService.getIdentityClaims();
// 		if (!claims)
// 			return '';
// 		return claims['name'];
// 	}

// 	public get isLoggedIn(): boolean {
// 		return this.oauthService.hasValidAccessToken();
// 	}

// 	public get accessToken(): string {
// 		return this.oauthService.getAccessToken();
// 	}

// 	public login() {
// 		this.oauthService.initImplicitFlow();
// 	}

// 	public logout() {
// 		this.oauthService.revokeTokenAndLogout();
// 		this.oauthService.logOut();
// 	}

// 	public async tryLogin(): Promise<boolean> {
// 		const fragment = this.cookieService.get(this.GGMEET_FRAGMENT_COOKIE_NAME);
// 		if (fragment) {
// 			console.log('fragment: 123123 ', fragment);
// 			await this.oauthService.tryLogin({
// 				customHashFragment: fragment,
// 				disableOAuth2StateCheck: true,
// 			});
// 			if (this.oauthService.hasValidAccessToken()) {
// 				console.log('Login Successful');
// 				console.log('this.ggmeetService.isLoggedIn', this.oauthService.hasValidAccessToken());
// 				console.log('Access Token:', this.oauthService.getAccessToken());
// 				return true;
// 			} else {
// 				console.log('Login Failed');
// 				return false;
// 			}
// 		} else {
// 			console.log('Not found cookie');
// 			return Promise.resolve(false);
// 		}
// 	}


// 	public getProfile() {
// 		return this.oauthService.getIdentityClaims();
// 	}

// 	public setupAutomaticSilentRefresh() {
// 		this.oauthService.setupAutomaticSilentRefresh();
// 	}
// }
