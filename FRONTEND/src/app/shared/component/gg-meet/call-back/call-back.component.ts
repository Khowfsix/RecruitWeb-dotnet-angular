import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { GGMeetService } from '../../../service/ggmeet.service';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
	selector: 'app-call-back',
	standalone: true,
	imports: [],
	templateUrl: './call-back.component.html',
	styleUrl: './call-back.component.css'
})
export class CallBackComponent implements OnInit {
	constructor(
		private route: ActivatedRoute,
		private cookieService: CookieService,
		private ggmeetService: GGMeetService,
		private oauthService: OAuthService,
	) { }

	public fragment: string | null = null;
	public log() {
		console.log('this.ggmeetService.isLoggedIn()', this.ggmeetService.isLoggedIn())
		// console.log('this.ggmeetService.isLoggedIn', this.oauthService.hasValidAccessToken());
		// console.log('cookieService.get(fragment)', this.cookieService.get(this.ggmeetService.GGMEET_FRAGMENT_COOKIE_NAME));
	}


	ngOnInit(): void {
		// this.access_token = this.route.snapshot.paramMap.get('yourVariable');

		// this.route.paramMap.subscribe(params => {
		// 	this.access_token = params.get('access_token');
		// 	console.log('params.get(access_token)', params.get('access_token'));
		// });

		// this.route.fragment.subscribe(fragment => {
		// 	if (fragment) {
		// 		const params = new URLSearchParams(fragment);
		// 		this.access_token = params.get('access_token');
		// 		console.log('Access Token:', this.access_token);
		// 		this.cookieService.set('GGMEET_ACCESS_TOKEN', this.access_token ?? '', 1, '/')
		// 	}
		// });


		this.route.fragment.subscribe(fragment => {
			if (fragment) {
				this.fragment = fragment;
				console.log(fragment);
				// const params = new URLSearchParams(fragment);
				// const access_token = params.get('access_token');
				// this.cookieService.set(this.ggmeetService.GGMEET_ACCESS_TOKEN_COOKIE_NAME, access_token ?? '', 1, '/')
				// this.cookieService.set(this.ggmeetService.GGMEET_FRAGMENT_COOKIE_NAME, fragment ?? '', 1, '/')
				this.ggmeetService.tryLogin();

				// if (access_token) {
				// 	this.oauthService?.tryLogin({
				// 		customHashFragment: fragment,
				// 		disableOAuth2StateCheck: true,
				// 	}).then(() => {
				// 		if (this.oauthService?.hasValidAccessToken()) {
				// 			this.fragment = fragment;
				// 			// this.ggmeetService.emitOauthService(this.oauthService)
				// 			// this.ggmeetService.emitData("LOGIN SUCESS")
				// 			console.log('Đăng nhập thành công');
				// 			console.log('this.oauthService', this.oauthService);
				// 			// this.oauthService.events.subscribe((e) => {
				// 			// 	if (e.type === 'token_received') {
				// 			// 		sessionStorage.setItem('access_token', this.oauthService.getAccessToken());
				// 			// 	}
				// 			// });
				// 			// this.ggmeetService.setOAuthService(this.oauthService);

				// 			// this.ggmeetService.oauthService$.subscribe(data => {

				// 			// 	console.log('Đăng nhập thành công');
				// 			// 	console.log('this.ggmeetService.isLoggedIn', data.hasValidAccessToken());
				// 			// 	console.log('Access Token:', data.getAccessToken());
				// 			// })
				// 			// console.log('Thông tin người dùng:', this.ggmeetService.getIdentityClaims());
				// 		} else {
				// 			console.log('Đăng nhập không thành công');
				// 		}
				// 	});
				// }


				// this.ggmeetService.tryLogin().then(isLoggedIn => {
				// 	if (isLoggedIn) {
				// 		console.log('CallBackComponent: Login Successful');
				// 	} else {
				// 		console.log('CallBackComponent: Login Failed');
				// 	}
				// 	// Optionally close the window after login attempt
				// 	// window.close();
				// });

			}
		});
	}
}
