/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { API } from './../../data/api.service';
import { BehaviorSubject, Observable, first, lastValueFrom } from 'rxjs';
import { Register } from '../../data/authen/register.model';
import { Login } from '../../data/authen/login.model';
import { noTokenURLs } from '../constants/noTokenURLs.constants';
import { CookieService } from 'ngx-cookie-service';
import { WebUser } from '../../data/authentication/web-user.model';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable({
	providedIn: 'root',
})
export class AuthService {
	// clientUserInfo: string | null = window.localStorage.getItem('currentUser') || null;

	constructor(
		private api: API,
		private cookieService: CookieService,
		private router: Router,
		private toast: ToastrService
	) {
		// afterRender(() => {
		// 	console.log(localStorage);
		// 	this.clientUserInfo = localStorage.getItem('currentUser') != '' ? localStorage.getItem('currentUser') : null;
		// });
	}

	private loginStatus = new BehaviorSubject<boolean>(this.checkLoginStatus());

	checkLoginStatus(): boolean {
		if (this.cookieService.get('jwt') != '') {
			return true;
		} return false;
	}

	getLocalCurrentUser(): WebUser {
		const currentUser = localStorage.getItem('currentUser');
		return currentUser ? JSON.parse(currentUser) : null
	}

	getCandidateId_OfUser(): string | undefined {
		const user = this.getLocalCurrentUser();
		if (user?.candidates != undefined) {
			return user.candidates[0].candidateId;
		}
		return undefined;
	}

	getInterviewerId_OfUser(): string | undefined {
		const user = this.getLocalCurrentUser();
		if (user?.interviewers != undefined) {
			return user.interviewers[0].interviewerId;
		}
		return undefined;
	}

	getRecruiterId_OfUser(): string | undefined {
		const user = this.getLocalCurrentUser();
		if (user?.recruiters != undefined) {
			return user.recruiters[0].recruiterId;
		}
		return undefined;
	}

	get isLoggedIn() {
		return this.loginStatus.asObservable();
	}

	register(registerModel: Register): Observable<unknown> {
		return this.api
			.POST('/api/Authentication/Register', registerModel)
			.pipe(first());
	}

	isValidUsername(username: string): Observable<boolean> {
		return this.api.GET(`/api/Authentication/IsValidUserName?username=${username}`);
	}

	isValidEmail(email: string): Observable<boolean> {
		return this.api.GET(`/api/Authentication/IsValidEmail?email=${email}`);
	}

	login(loginModel: Login): Observable<unknown> {
		this.loginStatus.next(true);
		return this.api.POST('/api/Authentication/Login', loginModel);
	}

	logout() {
		try {
			this.api.POST('/api/Authentication/Logout');
			this.cookieService.delete('jwt');
			this.cookieService.delete('refreshToken');
			localStorage.removeItem('currentUser');
			localStorage.removeItem('expirationDate');
			this.loginStatus.next(false);

			this.toast.success("Log out successfully", "Success", {
				timeOut: 3000,
				progressBar: true,
			});
		} catch (error) {
			console.log(error);
			this.toast.error("Log out failed", "Error", {
				timeOut: 3000,
				progressBar: true,
			});
		}
		return this.router.navigate(['/']);
	}

	// todo: get current user
	getCurrentUser(): Observable<WebUser | null> {
		return this.api.GET('/api/Authentication/UserLogin');
	}

	getAuthenticationToken(): string | null {
		if (this.cookieService.get('jwt')) {
			return this.cookieService.get('jwt');
		}

		console.log('User has no token');
		return null;
	}

	isInWhiteListUrl(url: string): boolean {
		return noTokenURLs.some((item) => item.startsWith(url));
	}

	async isAuthenticated(): Promise<boolean> {
		return new Promise((resolve) => {
			const user = this.cookieService.get('currentUser');
			// console.log(this.clientUserInfo !== null);
			resolve(user !== null);
		})
	}

	async refreshToken(): Promise<boolean> {
		/*
			ta đem refresh token
			gọi cho máy chủ trả về json
			new string access token
			cookie lưu lại để xài lần sau

			xem cookie có đang hợp lệ?
			nếu được rồi ta gọi api
			response nếu được hàng 2 - http status code = 200 :v
			lưu token mới, return true nè
		*/
		const refreshToken = this.cookieService.get('refreshToken');
		const accessToken = this.cookieService.get('jwt');
		if (!accessToken && !refreshToken) {
			return false;
		}
		console.log(refreshToken);

		try {
			const response = await lastValueFrom(
				this.api.POST(`/api/Authentication/RefreshToken?token=${encodeURIComponent(refreshToken)}`)
			);
			if (typeof response == 'object') {
				const expTime = new Date().getDate() + 30;
				this.cookieService.set('jwt', response.newAccessToken, expTime, '/');
				console.log('set new jwt');
				return true;
			}
		} catch (error) {
			console.error(error);
		}
		return false;
	}
}
