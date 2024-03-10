import { Injectable } from '@angular/core';
import {
	CanActivate,
	ActivatedRouteSnapshot,
	RouterStateSnapshot,
	Router,
	UrlTree,
} from '@angular/router';

import { PermissionService } from '../services/permission.service';
import { AuthService } from '../services/auth.service';
import { JwtPayload, jwtDecode } from 'jwt-decode';
import { CookieService } from 'ngx-cookie-service';

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
		// if (await this.authService.isAuthenticated() !== true) {
		if (typeof localStorage !== 'undefined') {
			if (localStorage.getItem('currentUser') === null) {
				return this.router.navigate(['/auth/login'], {
					queryParams: { returnUrl: state.url },
				});
			}
		}

		// Kiểm tra role hiện tại có khớp với list role yêu cầu không
		const requiredRole = next.data['roles'] as string[];
		// const isAuthorized = await this.permissionService.isAuthorized(
		// 	requiredRole,
		// ); // assuming isAuthorized is an async function

		// decode the token to get its payload
		const token = this.cookieService.get('jwt');
		if (token !== '') {
			const jsonPayload = JSON.stringify(jwtDecode<JwtPayload>(token));
			const currentUserRole: string[] = JSON.parse(jsonPayload)["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

			// console.log('isAuthorized:', isAuthorized);
			const userHasRole = requiredRole.some((role) => currentUserRole.includes(role))

			if (!userHasRole) {
				console.log('User is not authorized, redirecting to home page');
				return this.router.createUrlTree(['/home']);
			}
		}
		return true;
	}
}
