import { Injectable } from '@angular/core';
import {
	CanActivate,
	ActivatedRouteSnapshot,
	RouterStateSnapshot,
	Router,
} from '@angular/router';

import { AuthService } from '../services/auth.service';
import { PermissionService } from '../services/permission.service';

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
	) {
		const isAuthen = this.authService.isAuthenticated();

		if (!isAuthen) {
			// redirect user to the login page
			this.router.navigate(['/auth/login'], {
				queryParams: { returnUrl: state.url },
			});
			return false;
		} else {
			const requiredRoles = next.data['roles'] as string[];
			const isAuthor = this.permissionService.isAuthorized(requiredRoles);

			if (!isAuthor) {
				// role not authorised so redirect to home page
				// this.router.navigate(['/']);
				return false;
			}
		}

		// authen and author
		return true;
	}
}
