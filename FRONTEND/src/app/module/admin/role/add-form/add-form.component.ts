/* eslint-disable @typescript-eslint/no-explicit-any */
import { AfterViewInit, Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RoleService } from '../../../../data/role/role.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Role } from '../../../../data/role/role.model';

@Component({
	selector: 'app-add-form',
	standalone: true,
	imports: [
		ReactiveFormsModule,
		MatButtonModule,
		MatInputModule,
		MatFormFieldModule
	],
	templateUrl: './add-form.component.html',
	styleUrl: './add-form.component.css'
})
export class AddFormComponent implements AfterViewInit {
	constructor(
		// Dialog
		@Inject(MAT_DIALOG_DATA) public data: any,
		private dialogRef: MatDialogRef<AddFormComponent>,

		private _roleService: RoleService,
		private _formBuilder: FormBuilder,
		private _toastr: ToastrService,
	) { }

	ngAfterViewInit(): void {
		if (this.isEditForm)
			this.addForm.disable();
	}

	public foundRole: Role = this.data ? this.data.foundRole : undefined;
	public isEditForm = this.data ? this.data.isEditForm : false;
	public isEditing = false;

	public addForm: FormGroup = this._formBuilder.group({
		name: [this.foundRole ? this.foundRole.name : '', [Validators.required]],
	});

	public edit() {
		this.isEditing = !this.isEditing;
		if (this.isEditing)
			this.addForm.enable();
		else
			this.addForm.disable();
	}

	public callApiSaveRole() {
		this._roleService.createRole({ name: this.addForm.value.name }).subscribe({
			next: () => {
				this.dialogRef.close();
				this._toastr.success('Created Role...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Save Role Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}

	public callApiUpdateRole() {
		this._roleService.updateRole(this.foundRole.id!, { name: this.addForm.value.name }).subscribe({
			next: () => {
				this.dialogRef.close();
				this._toastr.success('Updated Role...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Update Role Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}
}
