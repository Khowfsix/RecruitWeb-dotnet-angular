/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { AutocompleteComponent } from "../../../../shared/component/inputs/autocomplete/autocomplete.component";
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatOptionModule } from '@angular/material/core';
import { Interview_CompanyStatus } from '../../../../shared/enums/EInterview.model';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-send-multi-email',
	standalone: true,
	templateUrl: './send-multi-email.component.html',
	styleUrl: './send-multi-email.component.css',
	imports: [
		MatButtonModule,
		MatSelectModule,
		AutocompleteComponent,
		ReactiveFormsModule,
		MatOptionModule,
		MatLabel,
		MatFormField,
	]
})
export class SendMultiEmailComponent implements OnInit {
	constructor(
		@Inject(MAT_DIALOG_DATA) public data: any,
		private formBuilder: FormBuilder,
		public dialogRef: MatDialogRef<SendMultiEmailComponent>,
		private toastr: ToastrService,
	) { }

	ngOnInit(): void {
		console.log('emails', this.emails)
	}

	public interview_CompanyStatus: typeof Interview_CompanyStatus = Interview_CompanyStatus;

	public statusForm: FormGroup = this.formBuilder.group({
		status: ['', [Validators.required]],
	});

	public emails: any[] = this.data ? this.data.emails : [];

	public openEmail() {
		if (this.emails) {
			const a = ['a', 'b']
			console.log('a', a.toString())
			const fieldValue = this.statusForm.value;
			const seletedEmails = this.emails.filter(e => e.company_Status === fieldValue.status).map(e => e.email);
			console.log('seletedEmails.toString()', seletedEmails.toString())
			window.open("https://mail.google.com/mail/?view=cm&fs=1&to=" + seletedEmails.toString(), "_blank");
			this.dialogRef.close()
		}
		else {
			this.toastr.error("Something wrong.......");
			this.dialogRef.close()
		}
	}
}
