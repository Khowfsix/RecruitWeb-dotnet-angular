/* eslint-disable @typescript-eslint/no-explicit-any */
import { AfterViewInit, Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { CategoryPosition, CategoryPositionAddModel } from '../../../../data/categoryPosition/category-position.model';
import { CategoryPositionService } from '../../../../data/categoryPosition/category-position.service';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

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

		private _categorypositionService: CategoryPositionService,
		private _formBuilder: FormBuilder,
		private _toastr: ToastrService,
	) { }

	ngAfterViewInit(): void {
		if (this.isEditForm)
			this.addForm.disable();
	}

	public foundCategoryPosition: CategoryPosition = this.data ? this.data.foundCategoryPosition : undefined;
	public isEditForm = this.data ? this.data.isEditForm : false;
	public isEditing = false;

	public addForm: FormGroup = this._formBuilder.group({
		categoryPositionName: [this.foundCategoryPosition ? this.foundCategoryPosition.categoryPositionName : '', [Validators.required]],
		categoryPositionDescription: [this.foundCategoryPosition ? this.foundCategoryPosition.categoryPositionDescription : '', []],
	});

	public edit() {
		this.isEditing = !this.isEditing;
		if (this.isEditing)
			this.addForm.enable();
		else
			this.addForm.disable();
	}

	public callApiSaveCategoryPosition() {
		const addModel: CategoryPositionAddModel = {
			categoryPositionName: this.addForm.value.categoryPositionName,
			categoryPositionDescription: this.addForm.value.categoryPositionDescription,
		}
		this._categorypositionService.create(addModel).subscribe({
			next: () => {
				this.dialogRef.close();
				this._toastr.success('Created Category Position...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Save Category Position Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}

	public callApiUpdateCategoryPosition() {
		this._categorypositionService.updateCategoryPosition(this.foundCategoryPosition.categoryPositionId!, {
			categoryPositionName: this.addForm.value.categoryPositionName,
			categoryPositionDescription: this.addForm.value.categoryPositionDescription,
		}).subscribe({
			next: () => {
				this.dialogRef.close();
				this._toastr.success('Updated Category Position...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Update Category Position Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}
}
