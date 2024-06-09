import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { MatButtonModule } from '@angular/material/button';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';
import { ToastrService } from 'ngx-toastr';
import { MY_DAY_FORMATS } from '../../../../../core/constants/app.env';
import { PersonalDetail } from '../../../../../data/candidate/personalDetail';
import { FileService } from '../../../../../data/file/file-service.service';
import { LessToDay } from '../../../../../shared/validators/date.validator';
import { PersonalDetailComponent } from '../personal-detail.component';

@Component({
	selector: 'app-pd-edit-dialog',
	standalone: true,
	imports: [
		FormsModule,
		ReactiveFormsModule,
		CommonModule,

		MatDialogModule,
		MatDividerModule,

		MatInputModule,

		MatDatepickerModule,
		MatNativeDateModule,
		MatSelectModule,
		MatButtonModule,
		MatStepperModule
	],
	providers: [
		// { provide: MAT_DATE_LOCALE, useValue: 'en-GB' },
		{ provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
		{ provide: MAT_DATE_FORMATS, useValue: MY_DAY_FORMATS },
	],
	templateUrl: './pd-edit-dialog.component.html',
	styleUrl: './pd-edit-dialog.component.css'
})
export class PDEditDialogComponent implements OnInit, OnDestroy {
	personalDetailForm: FormGroup = new FormGroup({});
	detailUpdate?: PersonalDetail;
	avatarImage?: File;
	imgSrc?: string;

	fullname = new FormControl(this.data.user?.fullName, [Validators.required]);
	title = new FormControl(this.data.user?.title, [Validators.required]);
	// email = new FormControl(this.data.user?.email, [Validators.required, Validators.email]);
	phoneNumber = new FormControl(this.data.user?.phoneNumber, [Validators.required, Validators.pattern('[0-9]{10}')]);
	dob = new FormControl(this.data.user?.dateOfBirth, [Validators.required, LessToDay]);
	gender = new FormControl(this.data.user?.gender, [Validators.required]);
	address = new FormControl(this.data.user?.address, [Validators.required]);
	personalLink = new FormControl(this.data.user?.personalLink, []);

	constructor(
		public dialogRef: MatDialogRef<PersonalDetailComponent>,
		private changeDetectorRef: ChangeDetectorRef,
		private formBuilder: FormBuilder,
		private toastService: ToastrService,
		private fileService: FileService,

		@Inject(MAT_DIALOG_DATA) public data: any,
	) {
		this.personalDetailForm = this.formBuilder.group({
			fullname: this.fullname,
			title: this.title,
			// email: this.email,
			phoneNumber: this.phoneNumber,
			dob: this.dob,
			gender: this.gender,
			address: this.address,
			personalLink: this.personalLink
		});

		this.imgSrc = data.user?.imageURL;
	}

	ngOnInit(): void {
		this.changeDetectorRef.detectChanges();
	}

	ngOnDestroy(): void { }

	updateErrorMessage() { }

	onCancelClick(): void {
		this.dialogRef.close();
	}

	onSaveClick(): void {
		this.detailUpdate = this.personalDetailForm.value;
		if (this.avatarImage) {
			const formData: FormData = new FormData();
			console.log(this.avatarImage.type);
			formData.append('formFile', this.avatarImage);
			this.fileService.uploadFile(formData).subscribe(
				(res) => {
					this.detailUpdate = {
						...this.detailUpdate,
						imgUrl: res.url,
					};
					this.dialogRef.close(this.detailUpdate!);
				},
				(error) => {
					console.error('Error uploading image:', error);
					// Use the old URL and display an error message to the user
					this.detailUpdate = {
						...this.detailUpdate,
						imgUrl: this.data.user?.imageURL,
					};
					this.dialogRef.close(this.detailUpdate!);
				}
			);
		} else {
			console.log('no new');
			this.detailUpdate = {
				...this.detailUpdate,
				imgUrl: this.data.user?.imageURL
			}
			this.dialogRef.close(this.detailUpdate!);
		}
	}

	onAvatarChange(event: Event) {
		const input = event.target as HTMLInputElement;
		if (input.files && input.files.length) {
			const file = input.files[0];
			// check is this image
			if (!file.type.startsWith('image/')) {
				// Handle the error here
				console.log('Invalid file type');
				this.toastService.error('Only image files are allowed', 'Invalid file type', { timeOut: 3000, progressBar: true });
				return;
			} else if (file.size > 5 * 1024 * 1024) {
				this.toastService.error('File size should be less than 5MB', 'File too large', {
					timeOut: 3000,
					progressBar: true
				});
				return;
			}

			this.imgSrc = URL.createObjectURL(file);
			this.avatarImage = file;
		}
	}
}
