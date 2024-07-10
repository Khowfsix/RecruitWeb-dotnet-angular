import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserRole, UserRoleAddModel, UserRoleDeleteModel } from './user-role.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class UserRoleService {

	constructor(private api: API) { }

	getAllUserRoles(): Observable<UserRole[]> {
		return this.api.GET('/api/UserRole');
	}

	deleteUserRole(userRole?: UserRoleDeleteModel): Observable<boolean> {
		return this.api.DELETE('/api/UserRole/', userRole);
	}

	createUserRole(newRole: UserRoleAddModel): Observable<UserRole> {
		return this.api.POST('/api/UserRole/', newRole);
	}
}
