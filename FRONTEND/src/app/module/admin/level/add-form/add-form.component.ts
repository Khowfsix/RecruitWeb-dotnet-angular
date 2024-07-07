/* eslint-disable @typescript-eslint/no-explicit-any */
import { AfterViewInit, Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input'
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { LevelService } from '../../../../data/level/level.service';
import { Level } from '../../../../data/level/level.model';

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

		private _levelService: LevelService,
		private _formBuilder: FormBuilder,
		private _toastr: ToastrService,
	) { }

	ngAfterViewInit(): void {
		if (this.isEditForm)
			this.addForm.disable();
	}

	public foundLevel: Level = this.data ? this.data.foundLevel : undefined;
	public isEditForm = this.data ? this.data.isEditForm : false;
	public isEditing = false;

	public addForm: FormGroup = this._formBuilder.group({
		levelName: [this.foundLevel ? this.foundLevel.levelName : '', [Validators.required]],
	});

	public edit() {
		this.isEditing = !this.isEditing;
		if (this.isEditing)
			this.addForm.enable();
		else
			this.addForm.disable();
	}

	public callApiSaveLevel() {
		this._levelService.createLevel({ levelName: this.addForm.value.levelName }).subscribe({
			next: () => {
				this.dialogRef.close();
				this._toastr.success('Created Level...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Save Level Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}

	public callApiUpdateLevel() {
		this._levelService.updateLevel(this.foundLevel.levelId!, {
			levelName: this.addForm.value.levelName,
			isDeleted: this.foundLevel.isDeleted
		}).subscribe({
			next: () => {
				this.dialogRef.close();
				this._toastr.success('Updated Level...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Update Level Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}
}
