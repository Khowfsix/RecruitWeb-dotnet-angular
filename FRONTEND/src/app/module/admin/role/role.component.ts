import { Component, ViewContainerRef } from '@angular/core';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { RoleService } from '../../../data/role/role.service';
import { Role } from '../../../data/role/role.model';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { AddFormComponent } from './add-form/add-form.component';

@Component({
	selector: 'app-role',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './role.component.html',
	styleUrl: './role.component.css',
})
export class RoleComponent {
	public actions: ActionType[] = ['create', 'update'];
	public listProps: string[] = [
		"id",
		"name",
		"normalizedName",
		"concurrencyStamp",
	];
	public displayColumn: string[] = [
		"ID",
		"Name",
		"Nomarlized Name",
		"Concurrency Stamp",
	];
	public listRoles = new BehaviorSubject<Role[]>([]);

	constructor(
		private viewContainerRef: ViewContainerRef,
		private dialog: MatDialog,

		public _roleService: RoleService,
		public _toastService: ToastrService,
	) {
		this.refreshData();
	}

	public refreshData() {
		this._roleService.getAllRoles().subscribe(
			roles => {
				this.listRoles.next(roles);
			},
			error => console.error(error)
		);
	}

	public delete = (role: Role): void => {
		this._roleService.deleteRole(role.id).subscribe(
			(response) => {
				console.log(response);
				this.refreshData();

				this._toastService.success("Delete success", "Delete role success", {
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
			// viewContainerRef: this.viewContainerRef,
			// data: {
			// 	recruiter: this.recruiter,
			// 	// interviewersData: interviewersData,
			// },
			width: '500px',
			height: '300px',
			enterAnimationDuration: '100ms',
			exitAnimationDuration: '0ms',
		});

		addFormDialog.afterClosed().subscribe(() => {
			this.refreshData();
		});
	}

	public edit = (row: Role): void => {
		const editFormDialog = this.dialog.open(AddFormComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				foundRole: row,
				isEditForm: true,
			},
			width: '500px',
			height: '300px',
			enterAnimationDuration: '100ms',
			exitAnimationDuration: '0ms',
		});

		editFormDialog.afterClosed().subscribe(() => {
			this.refreshData();
		});
	}
}
