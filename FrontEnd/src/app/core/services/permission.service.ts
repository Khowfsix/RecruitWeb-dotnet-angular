import { Injectable } from '@angular/core';
import { API } from '../../data/api.service';

@Injectable({
	providedIn: 'root',
})
export class PermissionService {
	constructor(private api: API) {}

	getUserRoles(): Promise<string[]> | null {
		let listRoles: string[] = [];

		this.api.GET('/api/Authentication/Role').subscribe({
			next: (data) => {
				listRoles = data.role;
				console.log(listRoles);
				return new Promise((resolve) => resolve(listRoles));
			},
			error: (error) => {
				console.log(error);
			},
			complete: () => {},
		});
		return null;
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

	isAuthorized(requiredRole: string[]): boolean {
		if (requiredRole.length === 0) {
			return true;
		}

		const currentUserRole = this.getUserRoles();

		if (currentUserRole === null) {
			console.log('User has no role');
			return false;
		}
		return this.hasRole(requiredRole, currentUserRole);
	}
}
