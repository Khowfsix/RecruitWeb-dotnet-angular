/* eslint-disable @typescript-eslint/no-explicit-any */
import { AfterViewInit, Component, Inject } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ToastrService } from 'ngx-toastr';
import { Skill } from '../../../../data/skill/skill.model';
import { SkillService } from '../../../../data/skill/skill.service';

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

		private _skillService: SkillService,
		private _formBuilder: FormBuilder,
		private _toastr: ToastrService,
	) { }

	ngAfterViewInit(): void {
		if (this.isEditForm)
			this.addForm.disable();
	}

	public foundSkill: Skill = this.data ? this.data.foundSkill : undefined;
	public isEditForm = this.data ? this.data.isEditForm : false;
	public isEditing = false;

	public addForm: FormGroup = this._formBuilder.group({
		skillName: [this.foundSkill ? this.foundSkill.skillName : '', [Validators.required]],
		description: [this.foundSkill ? this.foundSkill.description : '', []],
	});

	public edit() {
		this.isEditing = !this.isEditing;
		if (this.isEditing)
			this.addForm.enable();
		else
			this.addForm.disable();
	}

	public callApiSaveSkill() {
		this._skillService.createSkill({ skillName: this.addForm.value.skillName }).subscribe({
			next: () => {
				this.dialogRef.close();
				this._toastr.success('Created Skill...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Save Skill Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}

	public callApiUpdateSkill() {
		this._skillService.updateSkill(this.foundSkill.skillId!, {
			skillName: this.addForm.value.skillName,
			description: this.addForm.value.description,
		}).subscribe({
			next: () => {
				this.dialogRef.close();
				this._toastr.success('Updated Skill...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Update Skill Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}
}
