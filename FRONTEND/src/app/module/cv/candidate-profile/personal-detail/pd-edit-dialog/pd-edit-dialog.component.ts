import { ChangeDetectorRef, Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators, FormBuilder } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatStepperModule } from '@angular/material/stepper';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { PersonalDetailComponent } from '../personal-detail.component';
import { Candidate } from '../../../../../data/candidate/candidate.model';
import { PersonalDetail } from '../../../../../data/candidate/personalDetail';
import { LessToDay } from '../../../../../shared/validators/date.validator';

@Component({
	selector: 'app-pd-edit-dialog',
	standalone: true,
	imports: [
		FormsModule,
		ReactiveFormsModule,

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
		// { provide: DateAdapter, useClass: MatNativeDateModule },
		// { provide: MAT_DATE_LOCALE, useValue: 'en-US' },
	],
	templateUrl: './pd-edit-dialog.component.html',
	styleUrl: './pd-edit-dialog.component.css'
})
export class PDEditDialogComponent implements OnInit, OnDestroy {
	personalDetailForm: FormGroup = new FormGroup({});
	detailUpdate?: PersonalDetail;

	fullname = new FormControl(this.data.user?.fullName, [Validators.required]);
	title = new FormControl(this.data.user?.title, [Validators.required]);
	// email = new FormControl(this.data.user?.email, [Validators.required, Validators.email]);
	phoneNumber = new FormControl(this.data.user?.phoneNumber, [Validators.required, Validators.pattern('[0-9]{10}')]);
	dateOfBirth = new FormControl(this.data.user?.dateOfBirth?.getDate, [Validators.required, LessToDay]);
	gender = new FormControl(this.data.user?.gender, [Validators.required]);
	city = new FormControl(this.data.user?.city, [Validators.required]);
	address = new FormControl(this.data.user?.address, [Validators.required]);
	personalLink = new FormControl(this.data.user?.personalLink, []);

	constructor(
		public dialogRef: MatDialogRef<PersonalDetailComponent>,
		private changeDetectorRef: ChangeDetectorRef,
		private formBuilder: FormBuilder,
		@Inject(MAT_DIALOG_DATA) public data: Candidate
	) {
		this.personalDetailForm = this.formBuilder.group({
			fullname: this.fullname,
			title: this.title,
			// email: this.email,
			phoneNumber: this.phoneNumber,
			dateOfBirth: this.dateOfBirth,
			gender: this.gender,
			city: this.city,
			address: this.address,
			personalLink: this.personalLink
		});
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
		this.dialogRef.close(this.detailUpdate!);
	}
}
