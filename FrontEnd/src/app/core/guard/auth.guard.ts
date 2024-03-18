import { Injectable } from '@angular/core';
import {
	ActivatedRouteSnapshot,
	CanActivate,
	Router,
	RouterStateSnapshot,
	UrlTree,
} from '@angular/router';

import { JwtPayload, jwtDecode } from 'jwt-decode';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from '../services/auth.service';
import { PermissionService } from '../services/permission.service';

/*
auth flow:
	checking for no user info
		don't have:
			redirect to login page

		has user info:
			- check for don't have access token and refresh token in cookie
				don't have:
					redirect to login page

			new authObject = decode(access token)
			- if access token is expired:
				if refresh token is expired:
					=>
						remove access token, user information and refresh token from cookie
						redirect to login page

				call api refresh token by refresh token in cookie
					=> if success:
						set new access token to cookie => continue
					=> if fail:
						remove access token, user information and refresh token from cookie
						redirect to login page

			- checking "roles" of user get from access token has been decoded
				- if not authorized, redirect to home
				- if authorized, continue
*/

@Injectable({
	providedIn: 'root',
})
export class AuthGuard implements CanActivate {
	constructor(
		private authService: AuthService,
		private permissionService: PermissionService,
		private router: Router,
		private cookieService: CookieService
	) { }

	async canActivate(
		next: ActivatedRouteSnapshot,
		state: RouterStateSnapshot,
	): Promise<boolean | UrlTree> {
		const loginPage = this.router.createUrlTree(['/auth/login'], {
			queryParams: { returnUrl: state.url },
		});

		//checking for no user info
		// don't have:
		// redirect to login page
		if (typeof localStorage !== 'undefined') {
			if (localStorage.getItem('currentUser') === null) {
				return loginPage;
			}
		}

		/*
		- check for don't have access token and refresh token in cookie
				don't have:
					redirect to login page*/
		const accessToken = this.cookieService.get('jwt');
		const refreshToken = this.cookieService.get('refreshToken');
		if (!accessToken ||
			!refreshToken) {
			return loginPage;
		}

		// decode the token to get its payload
		const authenPayload: { username: string, jti: string, roles: string[], exp: string, aud: string }
			= JSON.parse(JSON.stringify(jwtDecode<JwtPayload>(accessToken)));

		// - if access token is expired:
		if (new Date(authenPayload.exp).getTime < Date.now) {
			/*
					if refresh token is expired:
						=> remove access token, user information and refresh token from cookie
						redirect to login page
			*/
			const expirationDate = new Date(this.cookieService.get('expirationDate'));
			if (expirationDate.getTime < Date.now) {
				this.authService.logout();
				return loginPage;
			}

			/*
			call api refresh token by refresh token in cookie
					=> if success:
						set new access token to cookie => continue
					=> if fail:
						remove access token, user information and refresh token from cookie
						redirect to login page
			*/
			const newAccessToken = await this.authService.refreshToken();
			if (!newAccessToken) {
				this.authService.logout();
				return loginPage;
			}
		}

		/*
		- checking "roles" of user get from access token has been decoded
				- if not authorized, redirect to home
				- if authorized, continue
		*/
		const currentUserRole: string[] = authenPayload.roles;
		const requiredRole = next.data['roles'] as string[]; // list roles which is required to access the route
		// console.log('isAuthorized:', isAuthorized);
		const userHasRole = requiredRole.some((role) => currentUserRole.includes(role))

		if (!userHasRole) {
			console.log('User is not authorized, redirecting to home page');
			return this.router.createUrlTree(['/home']);
		}

		return true;
	}
}
