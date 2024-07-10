/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { UserRoleService } from '../../../../data/userRole/user-role.service';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { UserService } from '../../../../data/user/user.service';
import { AutocompleteComponent } from '../../../../shared/component/inputs/autocomplete/autocomplete.component';
import { RoleService } from '../../../../data/role/role.service';
import { UserRoleAddModel } from '../../../../data/userRole/user-role.model';

@Component({
	selector: 'app-add-form',
	standalone: true,
	imports: [
		AutocompleteComponent,
		ReactiveFormsModule,
		MatButtonModule,
		MatInputModule,
		MatFormFieldModule
	],
	templateUrl: './add-form.component.html',
	styleUrl: './add-form.component.css'
})
export class AddFormComponent {
	constructor(
		// Dialog
		@Inject(MAT_DIALOG_DATA) public data: any,
		private dialogRef: MatDialogRef<AddFormComponent>,

		private _userRoleService: UserRoleService,
		private _userService: UserService,
		private _roleService: RoleService,
		private _formBuilder: FormBuilder,
		private _toastr: ToastrService,
	) { }
	public userData$ = this._userService.getAllUsers();
	public roleData$ = this._roleService.getAllRoles();

	public addForm: FormGroup = this._formBuilder.group({
		userId: ['', [Validators.required]],
		roleId: ['', [Validators.required]],
	});

	public callApiSaveUserRole() {
		console.log('data', this.addForm.value)
		const addModel: UserRoleAddModel = {
			userId: this.addForm.value.userId,
			roleId: this.addForm.value.roleId,
		}
		this._userRoleService.createUserRole(addModel).subscribe({
			next: () => {
				this.dialogRef.close();
				this._toastr.success('Created User Role...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Save User Role Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}
}
