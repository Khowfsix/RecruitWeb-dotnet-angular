import { Component, Inject, Input, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressBarModule } from '@angular/material/progress-bar';
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
import { Subscription, combineLatest } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Position } from '../../../../data/position/position.model';
import { MatIcon } from '@angular/material/icon';
import { isMoment } from 'moment';

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
		MatProgressBarModule,
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
				.find(x => x.categoryPositionId === this.fetchObject.categoryPositionId)?.categoryPositionName : null);
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
		categoryPositionName: [this.isEditForm ? this.fetchCategoryPositions.find(x => x.categoryPositionId === this.fetchObject.categoryPositionId)?.categoryPositionName : null, [Validators.required]],
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

	public uploadProgress: number | null = null;
	public uploadSub: Subscription | null = null;

	public savePosition() {
		let formValue = this.addForm.value;

		delete formValue.languageName;
		delete formValue.categoryPositionName;
		delete formValue.imageName;

		formValue = {
			...formValue,
			startDate: new Date(this.addForm.get('startDate')?.value.format('YYYY-MM-DD')).toISOString(),
			endDate: new Date(this.addForm.get('endDate')?.value.format('YYYY-MM-DD')).toISOString(),
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

		// for (const key in formValue) {
		// 	if (formValue[key] !== null) {
		// 		if (formValue[key] instanceof File) {
		// 			console.log(`[${key}] (File): `, formValue[key]);
		// 		} else {
		// 			console.log(`[${key}]: `, formValue[key]);
		// 		}
		// 	}
		// }


		const formData = new FormData();
		for (const key in formValue) {
			// if (formValue[key] !== null) {
			if (formValue[key] instanceof File) {
				formData.append(key, formValue[key], formValue[key].name);
			} else {
				formData.append(key, formValue[key]);
			}
			// }
		}

		console.log('formData: ', formData)

		this.toastr.info('Please wait till the form is closed!!!');
		this.positionService.create(formData).subscribe({
			next: () => {
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

		// // Xử lý nếu muốn hiển thị thanh loading (tuy nhiên cần phải cấu hình BE server để có thể gửi trạng thái của API)
		// const upload$ = this.positionService.create(formData, {
		// 	reportProgress: true,
		// 	observe: 'events'
		// }).pipe(
		// 	finalize(() => {
		// 		this.dialogRef.close();
		// 		this.toastr.success('Position Added...', 'Successfully!', {
		// 			timeOut: 2000,
		// 		});
		// 		this.reset();
		// 	})
		// );


		// this.uploadSub = upload$.subscribe(event => {
		// 	console.log('this.uploadProgress before', this.uploadProgress);
		// 	console.log("event", event)
		// 	if (event.type === HttpEventType.UploadProgress) {
		// 		// Xử lý khi có tiến trình tải lên
		// 		this.uploadProgress = Math.round(100 * (event.loaded / event.total));
		// 		console.log('Upload Progress:', this.uploadProgress);
		// 	} else if (event.type === HttpEventType.Response) {
		// 		// Xử lý khi có phản hồi từ server
		// 		console.log('Upload Complete:', event.body);
		// 	}
		// })

		// console.log('this.uploadSub', this.uploadSub);
	}

	public editPosition() {
		let formValue = this.addForm.value;

		console.log('Add Form Value: ', this.addForm.value);

		delete formValue.languageName;
		delete formValue.categoryPositionName;
		delete formValue.companyId;
		delete formValue.recruiterId;
		delete formValue.imageName;

		if (this.fetchObject.imageURL === formValue.imageFile) {
			formValue.imageFile = null;
		}

		formValue = {
			...formValue,
			startDate: isMoment(formValue.startDate) ? new Date(formValue.startDate.format('YYYY-MM-DD')).toISOString() : formValue.startDate,
			endDate: isMoment(formValue.endDate) ? new Date(formValue.endDate.format('YYYY-MM-DD')).toISOString() : formValue.endDate,
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

		const formData = new FormData();
		for (const key in formValue) {
			// if (formValue[key] !== null) {
			if (formValue[key] instanceof File) {
				formData.append(key, formValue[key], formValue[key].name);
			} else {
				formData.append(key, formValue[key]);
			}
			// }
		}
		this.toastr.info('Please wait till the form is closed!!!');
		this.positionService.update(this.fetchObject.positionId ?? '', formData).subscribe({
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

	// cancelUpload() {
	// 	this.uploadSub?.unsubscribe();
	// 	this.reset();
	// }

	// reset() {
	// 	this.uploadProgress = null;
	// 	this.uploadSub = null;
	// }
}
