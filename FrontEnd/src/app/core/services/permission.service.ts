import { Injectable } from '@angular/core';
import { API } from '../../data/api.service';
import { Role } from '../../data/authen/role.model';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
	providedIn: 'root',
})
export class PermissionService {
	constructor(private api: API, private cookieService: CookieService) { }

	getUserRoles(): Promise<string[] | null> {
		return new Promise((resolve) => {
			const roles = this.cookieService.get('role');
			if (roles) {
				resolve(JSON.parse(roles!));
			}

			this.api.GET('/api/Authentication/Role').subscribe({
				next: (data: Role) => {
					sessionStorage.setItem('role', JSON.stringify(data.role));
					resolve(data.role);
				},
				error: (err) => {
					console.log(err);
					resolve(null);
				},
			});

		});
	}

	hasRole(requiredRole: string[], currentUserRole: string[]): boolean {
		// Kiểm tra xem người dùng hiện tại có role đó không
		if (!requiredRole.some((role) => currentUserRole.includes(role))) {
			console.log(`Don't have required role: ${requiredRole}`);
			return false;
		}

		console.log(
			`currentUserRole: ${currentUserRole}, requiredRole: ${requiredRole}`,
		);
		return true;
	}

	async isAuthorized(requiredRole: string[]): Promise<boolean> {
		if (requiredRole.length === 0) {
			return true;
		}

		const currentUserRole = await this.getUserRoles();

		if (currentUserRole === null) {
			console.log('User has no role');
			return false;
		}

		return this.hasRole(requiredRole, currentUserRole);
	}
}
