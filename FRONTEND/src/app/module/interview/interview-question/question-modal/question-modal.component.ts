/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Input, SimpleChanges } from '@angular/core';
import {
	FormBuilder,
	FormGroup,
	FormsModule,
	ReactiveFormsModule,
	Validators,
} from '@angular/forms';
import { QuestionService } from '../../../../data/question/question.service';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOptionModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
	selector: 'app-question-modal',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,

		MatFormFieldModule,
		MatOptionModule,
		MatInputModule,
		MatButtonModule,
	],
	templateUrl: './question-modal.component.html',
})
export class QuestionModalComponent {
	@Input() modalStatus: boolean = false;
	@Input() value: any;
	@Input() options: any;
	@Input() type: boolean = false;
	@Input() status: any;

	questionForm: FormGroup;
	category: string = 'Technology';
	isFillQuestion: boolean | null = true;
	isFillType: boolean | null = true;
	isFillCategory: boolean | null = true;

	constructor(
		private fb: FormBuilder,
		private questionService: QuestionService,
	) {
		this.questionForm = this.fb.group({
			question: ['', Validators.required],
			skillChoose: [null],
			languageChoose: [null],
		});
	}

	ngOnInit() {
		this.initForm();
	}

	ngOnChanges(changes: SimpleChanges) {
		if (changes['value'] && this.value) {
			this.initForm();
		}
		if (changes['status'] && this.status.status === 'success') {
			this.handleResetForm();
			this.closeModal();
		}
	}

	initForm() {
		this.questionForm.patchValue({
			question: this.value.QuestionName,
			skillChoose:
				this.value.TypeId && this.value.TypeName
					? {
							skillId: this.value.TypeId,
							skillName: this.value.TypeName,
					  }
					: null,
			languageChoose:
				this.value.TypeId && this.value.TypeName
					? {
							languageId: this.value.TypeId,
							languageName: this.value.TypeName,
					  }
					: null,
		});
		this.category = this.value.CategoryName;
	}

	handleResetForm() {
		this.questionForm.reset();
		this.category = 'Technology';
		this.isFillQuestion = null;
		this.isFillType = null;
		this.isFillCategory = null;
	}

	handleCategoryChange(value: string) {
		this.category = value;
		this.questionForm.patchValue({
			skillChoose: null,
			languageChoose: null,
		});
		this.isFillCategory = true;
	}

	handleSubmitClick() {
		if (this.questionForm.invalid) {
			this.isFillQuestion = false;
			return;
		}

		const formValue = this.questionForm.value;
		const updateData: any = {
			QuestionId: this.value.QuestionId,
			QuestionName: formValue.question,
			CategoryName: this.category,
		};

		if (this.category === 'Technology' && formValue.skillChoose) {
			updateData.TypeId = formValue.skillChoose.skillId;
			updateData.TypeName = formValue.skillChoose.skillName;
		} else if (this.category === 'Language' && formValue.languageChoose) {
			updateData.TypeId = formValue.languageChoose.languageId;
			updateData.TypeName = formValue.languageChoose.languageName;
		} else {
			updateData.TypeId = null;
			updateData.TypeName = null;
		}

		// this.questionService.updateQuestion(updateData).subscribe(
		// 	response => {
		// 		// Handle success
		// 		this.closeModal();
		// 	},
		// 	error => {
		// 		// Handle error
		// 	}
		// );
	}

	closeModal() {
		// Emit event to parent to close modal
	}
}
