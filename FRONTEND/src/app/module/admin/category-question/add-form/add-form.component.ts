/* eslint-disable @typescript-eslint/no-explicit-any */
import { AfterViewInit, Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { CategoryQuestionService } from '../../../../data/categoryQuestion/category-question.service';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CategoryQuestion, CategoryQuestionAddModel } from '../../../../data/categoryQuestion/categoryQuestion.model';

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

		private _categoryquestionService: CategoryQuestionService,
		private _formBuilder: FormBuilder,
		private _toastr: ToastrService,
	) { }

	ngAfterViewInit(): void {
		if (this.isEditForm)
			this.addForm.disable();
	}

	public foundCategoryQuestion: CategoryQuestion = this.data ? this.data.foundCategoryQuestion : undefined;
	public isEditForm = this.data ? this.data.isEditForm : false;
	public isEditing = false;

	public addForm: FormGroup = this._formBuilder.group({
		categoryQuestionName: [this.foundCategoryQuestion ? this.foundCategoryQuestion.categoryQuestionName : '', [Validators.required]],
		weight: [this.foundCategoryQuestion ? this.foundCategoryQuestion.weight : '', [Validators.required]],
	});

	public edit() {
		this.isEditing = !this.isEditing;
		if (this.isEditing)
			this.addForm.enable();
		else
			this.addForm.disable();
	}

	public callApiSaveCategoryQuestion() {
		const addModel: CategoryQuestionAddModel = {
			categoryQuestionName: this.addForm.value.categoryQuestionName,
			weight: this.addForm.value.weight,
		}
		this._categoryquestionService.create(addModel).subscribe({
			next: () => {
				this.dialogRef.close();
				this._toastr.success('Created Category Question...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Save Category Question Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}

	public callApiUpdateCategoryQuestion() {
		this._categoryquestionService.updateCategoryQuestion(this.foundCategoryQuestion.categoryQuestionId!, {
			categoryQuestionName: this.addForm.value.categoryQuestionName,
			weight: this.addForm.value.weight,
		}).subscribe({
			next: () => {
				this.dialogRef.close();
				this._toastr.success('Updated Category Question...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Update Category Question Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}
}
