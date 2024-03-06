import { Component, Inject, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import {
	FormBuilder,
	FormControl,
	FormGroup,
	FormsModule,
} from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { provideNativeDateAdapter } from '@angular/material/core';
import { MAT_DATE_FORMATS } from '@angular/material/core';
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
import { Observable, combineLatest } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

export const MY_FORMATS = {
	parse: {
		dateInput: 'LL',
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
		provideNativeDateAdapter(),
		// { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
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
	],
	templateUrl: './add-form.component.html',
	styleUrl: './add-form.component.css',
})
export class AddFormComponent {
	private toastr = inject(ToastrService);

	private currentRecruiter?: Recruiter;

	private languageService = inject(LanguageService);
	public observableLanguages = this.languageService.getAllLanguagues();
	public fetchLanguages: Language[] = [];

	private categoryPositionService = inject(CategoryPositionService);
	public observableCategoryPositions =
		this.categoryPositionService.getAllCategoryPositions();
	public fetchCategoryPositions: CategoryPosition[] = [];

	constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}

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

	ngOnInit(): void {
		// console.log('currentUserId', this.data.currentUserId);
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

	private setupValidators() {
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
		positionName: ['', [Validators.required]],
		description: ['', [Validators.required]],
		salary: [null, [Validators.required, Validators.min(1)]],
		maxHiringQty: [
			null,
			[
				Validators.required,
				Validators.min(1),
				Validators.pattern('^[0-9]*$'),
			],
		],
		startDate: [null, [Validators.required]],
		endDate: [null, [Validators.required]],
		languageName: ['', [Validators.required]],
		categoryPositionName: ['', [Validators.required]],
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

	// private isInAllowedValues(allowedValues: string[]) {
	//   return (control: FormControl) => {
	//     const value = control.value;
	//     return allowedValues.includes(value) ? null : { notAllowedLanguage: true };
	//   };
	// }

	public aaa() {
		this.dialogRef.close();
		this.toastr.success('Position added...', 'Successfully!', {
			timeOut: 2000,
		});
	}

	public savePosition() {
		var formValue = this.addForm.value;

		delete formValue.languageName;
		delete formValue.categoryPositionName;

		formValue = {
			...formValue,
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
}
