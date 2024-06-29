import { Injectable } from '@angular/core';
// import { CookieService } from 'ngx-cookie-service';
import { jwtDecode, JwtPayload } from 'jwt-decode';
import { nameTypeInToken } from '../constants/token.constants';
// import { BehaviorSubject } from 'rxjs';
// import { Role } from '../../data/authen/role.model';

@Injectable({
	providedIn: 'root',
})
export class PermissionService {
	constructor() { }

	// private roles = new BehaviorSubject<string[]>(this.getUserRoles());

	// get getRoles() {
	// 	return this.roles.asObservable();
	// }

	// private getUserRoles(): string[] {
	// 	const jwt = this._cookieService.get('jwt');
	// 	if (jwt) {
	// 		try {
	// 			const authenPayload = JSON.parse(JSON.stringify(jwtDecode<JwtPayload>(jwt as string)));
	// 			const listRoles = authenPayload[nameTypeInToken.roles] as string[];
	// 			console.log(listRoles);
	// 			return listRoles;
	// 		} catch (error) {
	// 			return [];
	// 		}
	// 	} else {
	// 		return [];
	// 	}
	// }

	// private hasRole(requiredRole: string[], currentUserRole: string[]): boolean {
	// 	// Kiểm tra xem người dùng hiện tại có role đó không
	// 	if (!requiredRole.some((role) => currentUserRole.includes(role))) {
	// 		console.log(`Don't have required role: ${requiredRole}`);
	// 		return (false);
	// 	}

	// 	console.log(
	// 		`currentUserRole: ${currentUserRole}, requiredRole: ${requiredRole}`,
	// 	);
	// 	return true;
	// }

	// public isAuthorized(requiredRole: string[]) {
	// 	if (requiredRole.length === 0) {
	// 		return true;
	// 	}

	// 	const currentUserRole = this.getUserRoles();

	// 	if (currentUserRole === null) {
	// 		console.log('User has no role');
	// 		return false;
	// 	}

	// 	return this.hasRole(requiredRole, currentUserRole);
	// }

	getRoleOfUser(jwt: string | null) {
		if (jwt) {
			const authenPayload = JSON.parse(JSON.stringify(jwtDecode<JwtPayload>(jwt as string)));
			const currentUserRole: string[] = authenPayload[nameTypeInToken.roles];
			// console.log(currentUserRole);
			return currentUserRole;
		}
		return [];
	}
}
