/* eslint-disable @typescript-eslint/no-explicit-any */
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { Component, Inject, Input } from '@angular/core';
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
import { Validators } from '@angular/forms';
import { PositionService } from '../../../data/position/position.service';
import { RecruiterService } from '../../../data/recruiter/recruiter.service';
import { Recruiter } from '../../../data/recruiter/recruiter.model';
import { AsyncPipe } from '@angular/common';
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { Language } from '../../../data/language/language.model';
import { LanguageService } from '../../../data/language/language.service';
import { CategoryPosition } from '../../../data/categoryPosition/category-position.model';
import { CategoryPositionService } from '../../../data/categoryPosition/category-position.service';
import { AutocompleteComponent } from '../../../shared/component/inputs/autocomplete/autocomplete.component';
import { combineLatest } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Position } from '../../../data/position/position.model';
import { MatIcon } from '@angular/material/icon';
import { FileService } from '../../../data/file/file-service.service';
import { AddRequirementsFormComponent } from '../add-requirements-form/add-requirements-form.component';
import { RequirementsService } from '../../../data/requirements/requirements.service';
import { Requirements } from '../../../data/requirements/requirements.model';
import { CustomDateTimeService } from '../../../shared/service/custom-datetime.service';
import { MY_DAY_FORMATS } from '../../../core/constants/app.env';
import { AuthService } from '../../../core/services/auth.service';

@Component({
	selector: 'app-add-form',
	standalone: true,
	providers: [
		{ provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
		{ provide: MAT_DATE_FORMATS, useValue: MY_DAY_FORMATS },
	],
	imports: [
		MatProgressSpinnerModule,
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
		AddRequirementsFormComponent
	],
	templateUrl: './add-form.component.html',
	styleUrl: './add-form.component.css',
})
export class AddFormComponent {
	constructor(
		@Inject(MAT_DIALOG_DATA) public data: any,
		public dialogRef: MatDialogRef<AddFormComponent>,
		private formBuilder: FormBuilder,
		private FileService: FileService,
		private toastr: ToastrService,
		private languageService: LanguageService,
		private categoryPositionService: CategoryPositionService,
		private recruiterService: RecruiterService,
		private positionService: PositionService,
		private customDateService: CustomDateTimeService,
		private RequirementService: RequirementsService,
		private authService: AuthService,
	) { }

	@Input()
	public isEditForm: boolean = this.data ? this.data.isEditForm ?? false : false;
	public isEdit: boolean = false;
	@Input()
	private fetchObject: Position = this.data ? this.data.fetchObject ?? null : null;


	private currentRecruiter?: Recruiter;

	public observableLanguages = this.languageService.getAllLanguagues();
	public fetchLanguages: Language[] = [];

	public observableCategoryPositions =
		this.categoryPositionService.getAllCategoryPositions();
	public fetchCategoryPositions: CategoryPosition[] = [];

	public getRecruiterInfor() {
		this.currentRecruiter = this.authService.getLocalCurrentUser().recruiters?.pop();
		// console.log('AAAAA', this.currentRecruiter)
	}

	private fetchAllLanguages() {
		this.languageService.getAllLanguagues().subscribe({
			next: (data) => {
				this.fetchLanguages = data;
			},
			error: (e) => console.error(e),
		});
	}

	private fetchAllCategoryPositions() {
		this.observableCategoryPositions.subscribe((data) => {
			this.fetchCategoryPositions = data;
		});
	}

	private setupValidators() {
		this.addForm
			.get('categoryPositionId')
			?.setValue(this.isEditForm ? this.fetchObject.categoryPositionId : null);
		this.addForm
			.get('languageId')
			?.setValidators([
				Validators.required,
				this.isInAllowedValues(
					this.fetchLanguages.map((x) => x.languageId),
				),
			]);
		this.addForm
			.get('categoryPositionId')
			?.setValidators([
				Validators.required,
				this.isInAllowedValues(
					this.fetchCategoryPositions.map(
						(x) => x.categoryPositionId,
					),
				),
			]);

		this.addForm.get('languageId')?.updateValueAndValidity();
		this.addForm.get('categoryPositionId')?.updateValueAndValidity();
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
			[Validators.required, Validators.min(1), Validators.max(999999)]
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
				Validators.max(999),
			],
		],
		startDate: [this.isEditForm ? this.fetchObject.startDate : null, [Validators.required]],
		endDate: [this.isEditForm ? this.fetchObject.endDate : null, [Validators.required]],
		languageId: [this.isEditForm ? this.fetchObject.language?.languageId : '', [Validators.required]],
		categoryPositionId: [this.isEditForm ? this.fetchObject.categoryPositionId : null, [Validators.required]],
		requirements: [
			this.isEditForm ? this.fetchObject.requirements?.filter(e => e.isDeleted === false) : [],
			[
				Validators.required,
			],
		],
	});

	private isInAllowedValues(allowedValues: any[]): ValidatorFn {
		return (control: AbstractControl): ValidationErrors | null => {
			const value = control.value;

			if (!value) {
				return null;
			}

			return allowedValues.includes(value)
				? null
				: { invalid: 'invalid value' };
		};
	}

	ngOnInit(): void {
		// console.log('fetchObject', this.fetchObject);
		if (this.isEditForm) {
			this.addForm.disable();
			this.fetchObject.requirements = this.fetchObject.requirements?.filter(e => e.isDeleted === false);
		}
		this.getRecruiterInfor();
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
		if (file) {
			const newFileName = this.generateNewFileName(file.name);
			const renamedFile = new File([file], newFileName, { type: file.type });

			this.addForm.get('imageName')?.setValue(file.name)
			this.addForm.get('imageFile')?.setValue(renamedFile)
		}
	}

	private generateNewFileName(originalFileName: string): string {
		const randomString = Math.random().toString(36).substring(2, 8);
		return `${originalFileName}_${randomString}`;
	}

	public savePosition(): void {
		let formValue = this.addForm.value;

		const file: File = this.addForm.get('imageFile')?.value;
		if (file) {
			const formData = new FormData();
			formData.append('formFile', file, file.name);

			this.FileService.uploadFile(formData).subscribe({
				next: (response: any) => {
					formValue.imageURL = response.url;
					// delete formValue.languageName;
					// delete formValue.categoryPositionName;
					delete formValue.imageName;
					delete formValue.imageFile;

					formValue = {
						...formValue,
						startDate: this.customDateService.sameValueToUTC(formValue.startDate, true),
						endDate: this.customDateService.sameValueToUTC(formValue.endDate, true),
						recruiterId: this.currentRecruiter?.recruiterId,
						companyId: this.currentRecruiter?.companyId,
						// languageId: this.fetchLanguages?.find(
						// 	(x) =>
						// 		x.languageName === this.addForm?.get('languageName')?.value,
						// )?.languageId,
						// categoryPositionId: this.fetchCategoryPositions?.find(
						// 	(x) =>
						// 		x.categoryPositionName ===
						// 		this.addForm?.get('categoryPositionName')?.value,
						// )?.categoryPositionId,
					};
					this.positionService.create(formValue).subscribe({
						next: (resp: any) => {
							const requirements: Requirements[] = this.addForm.get('requirements')?.value;
							requirements.forEach((req) => {
								req.positionId = resp.positionId;
								this.callApiSaveRequirement(req);
							});
							this.dialogRef.close();
							this.toastr.success('Position Added...', 'Successfully!', {
								timeOut: 3000,
							});
						},
						error: () => {
							this.toastr.error('Something wrong...', 'Save Position Error!!!', {
								timeOut: 3000,
							});
						},
						complete: () => {
						},
					});
				},
				error: () => {
					this.toastr.error('File upload failed.', 'Error!', {
						timeOut: 3000,
					});
					return;
				},
			});
		}
	}

	private callApiSaveRequirement(requirement: any) {
		this.RequirementService.save(requirement).subscribe({
			next: () => { },
			error: () => {
				this.toastr.error('Something wrong...', 'Save Requirement Error!!!', {
					timeOut: 3000,
				});
			},
			complete: () => { },
		});
	}

	private callApiDeleteRequirement(requirementId: any) {
		this.RequirementService.delete(requirementId).subscribe({
			next: () => { },
			error: () => {
				this.toastr.error('Something wrong...', 'Delete Requirement Error!!!', {
					timeOut: 3000,
				});
			},
			complete: () => { },
		});
	}

	private callApiUpdatePosition(formValue: any) {
		// delete formValue.languageName;
		// delete formValue.categoryPositionName;
		delete formValue.companyId;
		delete formValue.recruiterId;
		delete formValue.imageName;
		delete formValue.imageFile;

		formValue = {
			...formValue,
			startDate: this.customDateService.sameValueToUTC(formValue.startDate, true),
			endDate: this.customDateService.sameValueToUTC(formValue.endDate, true),
			// languageId: this.fetchLanguages?.find(
			// 	(x) =>
			// 		x.languageName === this.addForm?.get('languageName')?.value,
			// )?.languageId,
			// categoryPositionId: this.fetchCategoryPositions?.find(
			// 	(x) =>
			// 		x.categoryPositionName ===
			// 		this.addForm?.get('categoryPositionName')?.value,
			// )?.categoryPositionId,
		};

		this.positionService.update(this.fetchObject.positionId ?? '', formValue).subscribe({
			next: (resp: any) => {
				if (resp === false) {
					this.toastr.error('Something wrong...', 'Error!!!', {
						timeOut: 3000,
					});
					return;
				} else {
					this.fetchObject.requirements?.forEach(e => {
						this.callApiDeleteRequirement(e.requirementId);
					});
					formValue.requirements.forEach((e: any) => {
						e.positionId = this.fetchObject.positionId;
						this.callApiSaveRequirement(e)
					});
					this.toastr.success('Position Updated...', 'Successfully!', {
						timeOut: 2000,
					});
					this.dialogRef.close();
				}
			},
			error: () => {
				this.toastr.error('Something wrong...', 'Error!!!', {
					timeOut: 3000,
				});
			},
			complete: () => {

			},
		});
	}

	public editPosition() {
		const formValue = this.addForm.value;

		if (this.fetchObject.imageURL !== formValue.imageName) {
			const file: File = this.addForm.get('imageFile')?.value;
			if (file) {
				const formData = new FormData();
				formData.append('newImage', file, file.name);
				formData.append('oldImageUrl', this.fetchObject.imageURL ?? '');

				this.FileService.updateFile(formData).subscribe({
					next: (response: any) => {
						formValue.imageURL = response.url;
						this.callApiUpdatePosition(formValue);
						return;
					},
					error: () => {
						this.toastr.error('File upload failed.', 'Error!', {
							timeOut: 3000,
						});
						return;
					},
				});
			}
		}
		else {
			this.callApiUpdatePosition(formValue);
		}

	}
}
