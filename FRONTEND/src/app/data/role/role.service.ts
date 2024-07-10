import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Role, RoleAddModel, RoleUpdateModel } from './role.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root'
})
export class RoleService {

	constructor(private api: API) { }

	getAllRoles(): Observable<Role[]> {
		return this.api.GET('/api/Role');
	}

	deleteRole(id?: string): Observable<boolean> {
		return this.api.DELETE('/api/Role/' + id);
	}

	createRole(newRole: RoleAddModel): Observable<Role> {
		return this.api.POST('/api/Role/', newRole);
	}
	updateRole(roleId: string, newRole: RoleUpdateModel): Observable<Role> {
		return this.api.PUT('/api/Role/' + roleId, newRole);
	}
}
