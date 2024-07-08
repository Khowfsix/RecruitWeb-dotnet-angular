/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ToastrService } from 'ngx-toastr';
import { InterviewerService } from '../../../../data/interviewer/interviewer.service';

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
export class AddFormComponent {
	constructor(
		@Inject(MAT_DIALOG_DATA) public data: any,
		private dialogRef: MatDialogRef<AddFormComponent>,
		private _interviewerService: InterviewerService,
		private _formBuilder: FormBuilder,
		private _toastr: ToastrService,
	) { }

	public companyId: any = this.data ? this.data.companyId : undefined;

	public addForm: FormGroup = this._formBuilder.group({
		userId: ['', [Validators.required]],
	});

	public callApiSaveInterviewer() {
		this._interviewerService.createInterviewer({ userId: this.addForm.value.userId, companyId: this.companyId }).subscribe({
			next: (resp: any) => {
				if (resp !== null) {
					this.dialogRef.close();
					this._toastr.success('Created Interviewer...', 'Successfully!', {
						toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
					});
				}
				else {
					this._toastr.error('Something wrong...', 'Save Interviewer Error!!!', {
						toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
					});
				}
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Save Interviewer Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}
}
