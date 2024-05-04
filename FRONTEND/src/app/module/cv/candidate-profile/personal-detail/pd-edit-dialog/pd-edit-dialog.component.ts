import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatStepperModule } from '@angular/material/stepper';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { PersonalDetailComponent } from '../personal-detail.component';

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
	templateUrl: './pd-edit-dialog.component.html',
	styleUrl: './pd-edit-dialog.component.css'
})
export class PDEditDialogComponent implements OnInit, OnDestroy {

	fullname = new FormControl('', [Validators.required]);
	title = new FormControl('', [Validators.required]);
	email = new FormControl('', [Validators.required, Validators.email]);
	phoneNumber = new FormControl('', [Validators.required, Validators.pattern('[0-9]{10}')]);
	dateOfBirth = new FormControl('', [Validators.required]);
	gender = new FormControl('', [Validators.required]);
	city = new FormControl('', [Validators.required]);
	address = new FormControl('', [Validators.required]);
	personalLink = new FormControl('', [Validators.required]);

	constructor(
		public dialogRef: MatDialogRef<PersonalDetailComponent>,
		private changeDetectorRef: ChangeDetectorRef
	) { }

	ngOnInit(): void {
		this.changeDetectorRef.detectChanges();
	}

	ngOnDestroy(): void { }

	updateErrorMessage() { }

	onCancelClick(): void {
		this.dialogRef.close();
	}

	onSaveClick(): void {
	}
}
