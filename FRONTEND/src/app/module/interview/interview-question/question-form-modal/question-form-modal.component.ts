/* eslint-disable @typescript-eslint/no-explicit-any */
import { LayoutModule } from '@angular/cdk/layout';
import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { map, Observable, startWith } from 'rxjs';

@Component({
	selector: 'app-question-form-modal',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,

		MatIconModule,
		MatRadioModule,
		MatFormFieldModule,
		MatAutocompleteModule,
		MatInputModule,
		MatButtonModule,
		LayoutModule,
		MatDialogModule,
	],
	templateUrl: './question-form-modal.component.html',
	styleUrl: './question-form-modal.component.css'
})
export class QuestionFormModalComponent {
	@Input() addModalStatus: boolean = false;
	@Input() status: { status: string } = { status: '' };
	@Input() options: any = { skill: [], language: [] };
	@Output() handleAddModalClose = new EventEmitter<void>();
	@Output() handleSubmitQuestion = new EventEmitter<any>();

	questionForm: FormGroup;
	isXs: boolean = false;
	filteredSkills?: Observable<any[]>;
	filteredLanguages?: Observable<any[]>;

	constructor(
		private fb: FormBuilder,
		// private breakpointObserver: BreakpointObserver
	) {
		this.questionForm = this.fb.group({
			question: ['', Validators.required],
			category: ['Technology', Validators.required],
			skillChoose: [null],
			languageChoose: [null]
		});
	}

	ngOnInit() {
		// this.breakpointObserver.observe([Breakpoints.XSmall]).subscribe(result => {
		// 	this.isXs = result.matches;
		// });

		this.filteredSkills = this.questionForm.get('skillChoose')!.valueChanges.pipe(
			startWith(''),
			map(value => this._filter(value, this.options.skill, 'skillName'))
		);

		this.filteredLanguages = this.questionForm.get('languageChoose')!.valueChanges.pipe(
			startWith(''),
			map(value => this._filter(value, this.options.language, 'languageName'))
		);

		this.questionForm.get('category')!.valueChanges.subscribe(value => {
			if (value === 'Technology') {
				this.questionForm.get('languageChoose')!.reset();
			} else if (value === 'Language') {
				this.questionForm.get('skillChoose')!.reset();
			} else {
				this.questionForm.get('skillChoose')!.reset();
				this.questionForm.get('languageChoose')!.reset();
			}
		});
	}

	private _filter(value: string, options: any[], field: string): any[] {
		const filterValue = value?.toLowerCase() || '';
		return options.filter(option => option[field].toLowerCase().includes(filterValue));
	}

	handleResetForm() {
		this.questionForm.reset({
			question: '',
			category: 'Technology',
			skillChoose: null,
			languageChoose: null
		});
	}

	handleSubmitClick() {
		if (this.questionForm.valid) {
			const formValue = this.questionForm.value;
			const submitData: any = {
				question: formValue.question,
				category: formValue.category,
				typeId: null,
				typeName: null
			};

			if (formValue.category === 'Technology' && formValue.skillChoose) {
				submitData.typeId = formValue.skillChoose.skillId;
				submitData.typeName = formValue.skillChoose.skillName;
			} else if (formValue.category === 'Language' && formValue.languageChoose) {
				submitData.typeId = formValue.languageChoose.languageId;
				submitData.typeName = formValue.languageChoose.languageName;
			}

			this.handleSubmitQuestion.emit(submitData);
		} else {
			this.questionForm.markAllAsTouched();
		}
	}
}
