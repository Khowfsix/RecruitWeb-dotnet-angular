import { Injectable } from '@angular/core';
import {
	CanActivate,
	ActivatedRouteSnapshot,
	RouterStateSnapshot,
	Router,
	UrlTree,
} from '@angular/router';
import 'localstorage-polyfill';

import { PermissionService } from '../services/permission.service';
import { AuthService } from '../services/auth.service';

@Injectable({
	providedIn: 'root',
})
export class AuthGuard implements CanActivate {
	constructor(
		private authService: AuthService,
		private permissionService: PermissionService,
		private router: Router,
	) {}

	async canActivate(
		next: ActivatedRouteSnapshot,
		state: RouterStateSnapshot,
	): Promise<boolean | UrlTree> {
		const isAuthen = this.authService.isAuthenticated();
		if (isAuthen === false) {
			return this.router.navigate(['/auth/login'], {
				queryParams: { returnUrl: state.url },
			});
		}

		// Kiểm tra role hiện tại có khớp với list role yêu cầu không
		const requiredRole = next.data['roles'] as string[];
		const isAuthorized = await this.permissionService.isAuthorized(
			requiredRole,
		); // assuming isAuthorized is an async function
		console.log('isAuthorized:', isAuthorized);

		if (!isAuthorized) {
			console.log('User is not authorized, redirecting to home page');
			return this.router.createUrlTree(['/home']);
		}

		return true;
	}
}
