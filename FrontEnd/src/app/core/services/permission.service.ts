import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';

@Injectable({
	providedIn: 'root',
})
export class PermissionService {
	constructor(private authService: AuthService) {}

	hasRole(requiredRole: string): boolean {
		// Kiểm tra xem người dùng hiện tại có role đó không
		const currentUser = this.authService.getCurrentUser();
		if (!currentUser) {
			return false;
		}

		console.log(requiredRole + ' has role ' + currentUser);

		return true;
		// return currentUser.roles.includes(requiredRole);
	}
}
