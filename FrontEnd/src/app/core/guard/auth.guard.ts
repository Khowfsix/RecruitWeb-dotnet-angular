import { Injectable } from '@angular/core';
import {
	CanActivate,
	ActivatedRouteSnapshot,
	RouterStateSnapshot,
	Router,
	UrlTree,
} from '@angular/router';

import { PermissionService } from '../services/permission.service';

@Injectable({
	providedIn: 'root',
})
export class AuthGuard implements CanActivate {
	constructor(
		private permissionService: PermissionService,
		private router: Router,
	) {}

	async canActivate(
		next: ActivatedRouteSnapshot,
		state: RouterStateSnapshot,
	): Promise<boolean | UrlTree> {
		if (!localStorage.getItem('loginData')) {
			return this.router.createUrlTree(['/auth/login'], {
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
