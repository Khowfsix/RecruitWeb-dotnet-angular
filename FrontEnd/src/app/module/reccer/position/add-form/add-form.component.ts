import { Component, Inject, Input, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import {
	FormBuilder,
	FormGroup,
	FormsModule,
} from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
// import { provideNativeDateAdapter } from '@angular/material/core';
import { Validators } from '@angular/forms';
import { PositionService } from '../../../../data/position/position.service';
import { RecruiterService } from '../../../../data/recruiter/recruiter.service';
import { Recruiter } from '../../../../data/recruiter/recruiter.model';
import { AsyncPipe } from '@angular/common';
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { Language } from '../../../../data/language/language.model';
import { LanguageService } from '../../../../data/language/language.service';
import { CategoryPosition } from '../../../../data/categoryPosition/category-position.model';
import { CategoryPositionService } from '../../../../data/categoryPosition/category-position.service';
import { AutocompleteComponent } from '../../../../shared/component/inputs/autocomplete/autocomplete.component';
import { combineLatest } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Position } from '../../../../data/position/position.model';
import { MatIcon } from '@angular/material/icon';

export const MY_FORMATS = {
	parse: {
		dateInput: 'DD/MM/YYYY',
	},
	display: {
		dateInput: 'DD/MM/YYYY',
		monthYearLabel: 'YYYY',
		dateA11yLabel: 'LL',
		monthYearA11yLabel: 'YYYY',
	},
};
@Component({
	selector: 'app-add-form',
	standalone: true,
	providers: [
		// provideNativeDateAdapter(),
		{ provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
		{ provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
	],
	imports: [
		MatButtonModule,
		MatInputModule,
		MatFormFieldModule,
		FormsModule,
		ReactiveFormsModule,
		MatDatepickerModule,
		MatAutocompleteModule,
		AsyncPipe,
		AutocompleteComponent,
		MatIcon,
	],
	templateUrl: './add-form.component.html',
	styleUrl: './add-form.component.css',
})
export class AddFormComponent {
	@Input()
	public isEditForm: boolean = this.data ? this.data.isEditForm ?? false : false;
	public isEdit: boolean = false;
	@Input()
	private fetchObject: Position = this.data ? this.data.fetchObject ?? null : null;

	private toastr = inject(ToastrService);

	private currentRecruiter?: Recruiter;

	private languageService = inject(LanguageService);
	public observableLanguages = this.languageService.getAllLanguagues();
	public fetchLanguages: Language[] = [];

	private categoryPositionService = inject(CategoryPositionService);
	public observableCategoryPositions =
		this.categoryPositionService.getAllCategoryPositions();
	public fetchCategoryPositions: CategoryPosition[] = [];

	constructor(@Inject(MAT_DIALOG_DATA) public data: any) { }

	private recruiterService = inject(RecruiterService);
	private positionService = inject(PositionService);
	public dialogRef = inject(MatDialogRef<AddFormComponent>);
	private formBuilder = inject(FormBuilder);

	public fetchRecruiterInfor(userId: string | undefined) {
		// console.log('fetch userId...........', userId);
		if (userId) {
			this.recruiterService.getRecruiterByUserId(userId).subscribe({
				next: (data) => {
					this.currentRecruiter = data;
					// console.log('Current Recruiter: ...........', data);
				},
				error: (e) => console.error(e),
			});
		}
	}

	private fetchAllLanguages() {
		this.languageService.getAllLanguagues().subscribe({
			next: (data) => {
				this.fetchLanguages = data;
				// console.log('fetchLanguages: ...........', data);
			},
			error: (e) => console.error(e),
		});
	}

	private fetchAllCategoryPositions() {
		this.observableCategoryPositions.subscribe((data) => {
			this.fetchCategoryPositions = data;
			// console.log('fetchCategoryPositions:', this.fetchCategoryPositions);
		});
	}

	private setupValidators() {
		this.addForm
			.get('categoryPositionName')
			?.setValue(this.isEditForm ? this.fetchCategoryPositions
				.find(x => x.categoryPositionId = this.fetchObject.categoryPositionId)?.categoryPositionName : '');
		this.addForm
			.get('languageName')
			?.setValidators([
				Validators.required,
				this.isInAllowedValues(
					this.fetchLanguages.map((x) => x.languageName),
				),
			]);
		this.addForm
			.get('categoryPositionName')
			?.setValidators([
				Validators.required,
				this.isInAllowedValues(
					this.fetchCategoryPositions.map(
						(x) => x.categoryPositionName,
					),
				),
			]);

		this.addForm.get('languageName')?.updateValueAndValidity();
		this.addForm.get('categoryPositionName')?.updateValueAndValidity();
	}

	public addForm: FormGroup = this.formBuilder.group({
		positionName: [
			this.isEditForm ? this.fetchObject.positionName : '',
			[Validators.required]
		],
		description: [
			this.isEditForm ? this.fetchObject.description : '',
			[Validators.required]
		],
		salary: [
			this.isEditForm ? this.fetchObject.salary : null,
			[Validators.required, Validators.min(1), Validators.pattern('^[0-9]*$'),]
		],
		imageName: [
			this.isEditForm ? this.fetchObject.imageURL : null,
			[Validators.required]
		],
		imageFile: [
			this.isEditForm ? this.fetchObject.imageURL : null,
			[Validators.required]
		],
		maxHiringQty: [
			this.isEditForm ? this.fetchObject.maxHiringQty : null,
			[
				Validators.required,
				Validators.min(1),
				Validators.pattern('^[0-9]*$'),
			],
		],
		startDate: [this.isEditForm ? this.fetchObject.startDate : null, [Validators.required]],
		endDate: [this.isEditForm ? this.fetchObject.endDate : null, [Validators.required]],
		languageName: [this.isEditForm ? this.fetchObject.language?.languageName : '', [Validators.required]],
		categoryPositionName: [this.isEditForm ? this.fetchCategoryPositions.find(x => x.categoryPositionId = this.fetchObject.categoryPositionId)?.categoryPositionName : '', [Validators.required]],
	});

	private isInAllowedValues(allowedValues: any[]): ValidatorFn {
		return (control: AbstractControl): ValidationErrors | null => {
			// console.log('allowedValues:', allowedValues)
			const value = control.value;

			// console.log('vallue', value)

			if (!value) {
				return null;
			}

			return allowedValues.includes(value)
				? null
				: { invalid: 'invalid value' };
		};
	}

	ngOnInit(): void {
		// console.log('currentUserId', this.data.currentUserId);
		// console.log('fetchObject', this.fetchObject);
		if (this.isEditForm)
			this.addForm.disable();
		this.fetchRecruiterInfor(this.data.currentUserId);
		this.fetchAllLanguages();
		this.fetchAllCategoryPositions();

		combineLatest([
			this.observableLanguages,
			this.observableCategoryPositions,
		]).subscribe(([languages, categoryPositions]) => {
			this.fetchLanguages = languages;
			this.fetchCategoryPositions = categoryPositions;

			this.setupValidators();
		});
	}

	public onFileSelected(event: any) {
		const file = event.target?.files?.[0];
		this.addForm.patchValue({ imageName: file.name });
		if (file) {
			const newFileName = this.generateNewFileName(file.name);
			const renamedFile = new File([file], newFileName, { type: file.type });
			this.addForm.patchValue({ imageFile: renamedFile });
		}
	}

	private generateNewFileName(originalFileName: string): string {
		const randomString = Math.random().toString(36).substring(2, 8);
		return `${originalFileName}_${randomString}`;
	}

	public savePosition() {
		let formValue = this.addForm.value;

		delete formValue.languageName;
		delete formValue.categoryPositionName;
		delete formValue.imageName;

		formValue = {
			...formValue,
			startDate: new Date(this.addForm.get('startDate')?.value.format('YYYY-MM-DD')),
			endDate: new Date(this.addForm.get('endDate')?.value.format('YYYY-MM-DD')),
			recruiterId: this.currentRecruiter?.recruiterId,
			companyId: this.currentRecruiter?.companyId,
			languageId: this.fetchLanguages?.find(
				(x) =>
					x.languageName === this.addForm?.get('languageName')?.value,
			)?.languageId,
			categoryPositionId: this.fetchCategoryPositions?.find(
				(x) =>
					x.categoryPositionName ===
					this.addForm?.get('categoryPositionName')?.value,
			)?.categoryPositionId,
		};
		console.log('Form Value: ', formValue);

		this.positionService.create(formValue).subscribe({
			next: () => {
				// this.toastr.success('Position added!!', 'Successfully!');
			},
			error: (err: unknown) => {
				console.log(err);
				this.toastr.error('Something wrong...', 'Error!!!');
			},
			complete: () => {
				this.dialogRef.close();
				this.toastr.success('Position Added...', 'Successfully!', {
					timeOut: 2000,
				});
			},
		});
	}

	public editPosition() {
		let formValue = this.addForm.value;

		delete formValue.languageName;
		delete formValue.categoryPositionName;
		delete formValue.companyId;
		delete formValue.recruiterId;

		formValue = {
			...formValue,
			startDate: new Date(this.addForm.get('startDate')?.value.format('YYYY-MM-DD')),
			endDate: new Date(this.addForm.get('endDate')?.value.format('YYYY-MM-DD')),
			recruiterId: this.currentRecruiter?.recruiterId,
			companyId: this.currentRecruiter?.companyId,
			languageId: this.fetchLanguages?.find(
				(x) =>
					x.languageName === this.addForm?.get('languageName')?.value,
			)?.languageId,
			categoryPositionId: this.fetchCategoryPositions?.find(
				(x) =>
					x.categoryPositionName ===
					this.addForm?.get('categoryPositionName')?.value,
			)?.categoryPositionId,
		};
		console.log('Form Value: ', formValue);

		this.positionService.update(this.fetchObject.positionId ?? '', formValue).subscribe({
			next: (resp: any) => {
				if (resp === false) {
					this.toastr.error('Something wrong...', 'Error!!!');
					return;
				} else {
					this.dialogRef.close();
					this.toastr.success('Position Updated...', 'Successfully!', {
						timeOut: 2000,
					});
				}
				// this.toastr.success('Position added!!', 'Successfully!');
			},
			error: (err: unknown) => {
				console.log(err);
				this.toastr.error('Something wrong...', 'Error!!!');
			},
			complete: () => {

			},
		});
	}
}
