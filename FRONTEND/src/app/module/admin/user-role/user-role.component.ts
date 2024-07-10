import { Component } from '@angular/core';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { UserRoleService } from '../../../data/userRole/user-role.service';
import { UserRole } from '../../../data/userRole/user-role.model';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { AddFormComponent } from './add-form/add-form.component';

@Component({
	selector: 'app-user-role',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './user-role.component.html',
	styleUrl: './user-role.component.css'
})
export class UserRoleComponent {
	public actions: ActionType[] = ['create'];
	public listProps: string[] = [
		"userId",
		"roleId",
	];
	public displayColumn: string[] = [
		"UserId",
		"RoleId",
	];
	public listUserRoles = new BehaviorSubject<UserRole[]>([]);

	constructor(
		private dialog: MatDialog,

		public _userRoleService: UserRoleService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._userRoleService.getAllUserRoles().subscribe(
			userRoles => {
				this.listUserRoles.next(userRoles);
			},
			error => console.error(error)
		);
	}

	delete = (userRole: UserRole): void => {
		this._userRoleService.deleteUserRole(userRole).subscribe(
			(response) => {
				console.log(response);
				this.refreshData();

				this._toastService.success("Delete success", "Delete userRole success", {
					timeOut: 3000,
					positionClass: 'toast-top-center',
					toastClass: ' my-custom-toast ngx-toastr',
					progressBar: true
				});
			}
		)
	}

	public create = (): void => {
		const addFormDialog = this.dialog.open(AddFormComponent, {
			width: '500px',
			height: '500px',
			enterAnimationDuration: '100ms',
			exitAnimationDuration: '0ms',
		});

		addFormDialog.afterClosed().subscribe(() => {
			this.refreshData();
		});
	}
}
