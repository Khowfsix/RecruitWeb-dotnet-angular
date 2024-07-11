/* eslint-disable prefer-const */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { AutocompleteComponent } from '../../shared/component/inputs/autocomplete/autocomplete.component';
import { CompanyService } from '../../data/company/company.service';
import { MatButtonModule } from '@angular/material/button';
import { AuthService } from '../../core/services/auth.service';
import { RecruiterService } from '../../data/recruiter/recruiter.service';
import { ToastrService } from 'ngx-toastr';
import { Recruiter } from '../../data/recruiter/recruiter.model';

@Component({
	selector: 'app-recruiter-register',
	standalone: true,
	imports: [
		AutocompleteComponent,

		MatButtonModule,
		ReactiveFormsModule,
		MatInputModule,
		MatFormFieldModule,
		MatSlideToggleModule,
		MatCheckboxModule
	],
	templateUrl: './recruiter-register.component.html',
	styleUrl: './recruiter-register.component.css'
})
export class RecruiterRegisterComponent implements OnInit {

	constructor(
		private formBuilder: FormBuilder,

		private _toastr: ToastrService,
		private _recruiterService: RecruiterService,
		private _authService: AuthService,
		private _companyService: CompanyService,
	) { }

	public alreadyRegister = false;
	public fetchedRecruiter?: Recruiter;

	ngOnInit(): void {
		this._recruiterService.getNotDeletedRecruiterByUserId(this._authService.getLocalCurrentUser().id).subscribe(
			(resp) => {
				if (resp) {
					this.alreadyRegister = true;
					this.fetchedRecruiter = resp;
				}
			})
		this.alreadyHasCompany.valueChanges.subscribe((value) => {
			if (value === false) {
				this.recruiterFormGroup.get('companyId')?.disable();
			}
			else {
				this.recruiterFormGroup.get('companyId')?.enable();
			}
		})
	}

	public observableCompanies = this._companyService.getAll();

	public alreadyHasCompany = new FormControl(true);
	public companyName = new FormControl('');
	public companyFormGroup: FormGroup = this.formBuilder.group({
		companyName: [null, [Validators.required]],
		address: [null, [Validators.required]],
		email: [null, [Validators.required, Validators.email]],
		phone: [null, [Validators.required, Validators.pattern('^[0-9]*$')]],
		website: [null, []],
	});

	public saveCompanyThenRecruiter() {
		let formValue = this.companyFormGroup.value;
		formValue.isActived = false;
		const formData: FormData = new FormData();
		formData.append('companyName', formValue.companyName);
		formData.append('address', formValue.address);
		formData.append('email', formValue.email);
		formData.append('phone', formValue.phone);
		formData.append('website', formValue.website);
		formData.append('isActived', formValue.isActived);
		this._companyService.createCompany(formData).subscribe({
			next: (resp) => {
				this._recruiterService.saveRecruiter({
					userId: this.recruiterFormGroup.value.userId,
					companyId: resp.companyId,
					isActived: false,
					isDeleted: false
				})
					.subscribe({
						next: () => {
							this._toastr.success('Please wait for Admin approval...', 'Successfully!', {
								toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
							});
							window.location.reload();
						},
						error: () => {
							this._toastr.error('Something wrong...', 'Error!!!', {
								toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
							});
						},
					})
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}

	public saveRecruiter() {
		const formValue = this.recruiterFormGroup.value;
		this._recruiterService.saveRecruiter({
			userId: formValue.userId,
			companyId: formValue.companyId,
			isActived: false, isDeleted: false
		})
			.subscribe({
				next: () => {
					this._toastr.success('Please wait for Admin approval...', 'Successfully!', {
						toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
					});
					window.location.reload();
				},
				error: () => {
					this._toastr.error('Something wrong...', 'Error!!!', {
						toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
					});
				},
			})
	}

	public recruiterFormGroup: FormGroup = this.formBuilder.group({
		companyId: [null, [Validators.required]],
		userId: [this._authService.getLocalCurrentUser().id, [Validators.required]],
	});
}
