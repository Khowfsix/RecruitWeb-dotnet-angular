/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../../../data/company/company.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { AuthService } from '../../../core/services/auth.service';
import { Company } from '../../../data/company/company.model';
import { MatIconModule } from '@angular/material/icon';
import { FileService } from '../../../data/file/file-service.service';

@Component({
	selector: 'app-company',
	standalone: true,
	imports: [
		MatIconModule,
		MatButtonModule,
		ReactiveFormsModule,
		MatInputModule,
		MatFormFieldModule,
	],
	templateUrl: './company.component.html',
	styleUrl: './company.component.css',
})
export class CompanyComponent implements OnInit {
	company?: Company;

	public onFileSelected(event: any) {
		const file = event.target?.files?.[0];
		if (file) {
			const newFileName = this.generateNewFileName(file.name);
			const renamedFile = new File([file], newFileName, { type: file.type });

			this.companyFormGroup.get('logoName')?.setValue(file.name)
			this.companyFormGroup.get('logoFile')?.setValue(renamedFile)
		}
	}

	private generateNewFileName(originalFileName: string): string {
		const randomString = Math.random().toString(36).substring(2, 8);
		return `${originalFileName}_${randomString}`;
	}

	constructor(

		private formBuilder: FormBuilder,

		private _fileService: FileService,
		private _authService: AuthService,
		private _toastr: ToastrService,
		private _companyService: CompanyService
	) { }


	public updateCompany() {
		const formValue = this.companyFormGroup.value;

		if (this.company?.logo !== formValue.logoName) {
			const file: File = this.companyFormGroup.get('logoFile')?.value;
			if (file && this.company?.logo) {
				const formData = new FormData();
				formData.append('newImage', file, file.name);
				formData.append('oldImageUrl', this.company?.logo ?? '');

				this._fileService.updateFile(formData).subscribe({
					next: (response: any) => {
						formValue.logo = response.url;
						this.callApiUpdate(formValue);
						return;
					},
					error: () => {
						this._toastr.error('File upload failed.', 'Error!', {
							toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
						});
						return;
					},
				});
			} else if (file && this.company?.logo === null) {
				const formData = new FormData();
				formData.append('formFile', file, file.name);
				this._fileService.uploadFile(formData).subscribe({
					next: (response: any) => {
						formValue.logo = response.url;
						this.callApiUpdate(formValue);
						return;
					},
					error: () => {
						this._toastr.error('File upload failed.', 'Error!', {
							toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
						});
						return;
					},
				});
			} else {
				this._fileService.deleteFile(this.company?.logo).subscribe({
					next: () => {
						this.callApiUpdate(formValue);
						return;
					},
					error: () => {
						this._toastr.error('File upload failed.', 'Error!', {
							toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
						});
						return;
					},
				});
			}
		}
		else {
			formValue.logo = this.company?.logo
			this.callApiUpdate(formValue);
		}
	}


	private callApiUpdate(formValue: any) {
		formValue.isDeleted = false;
		formValue.isActived = true;
		this._companyService.update(this.company?.companyId, formValue).subscribe({
			next: (resp: any) => {
				if (resp === false) {
					this._toastr.error('Something wrong...', 'Error!!!', {
						toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
					});
					return;
				} else {
					this._toastr.success('Company Updated...', 'Successfully!', {
						toastClass: ' my-custom-toast ngx-toastr', timeOut: 2000,
					});
					window.location.reload();
				}
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			complete: () => {

			},
		});
	}


	ngOnInit(): void {
		this._companyService.getById(this._authService.getLocalCurrentUser().recruiters?.pop()?.companyId)
			.subscribe({
				next: (data: any) => {
					if (data !== "Not found") {
						this.company = data
						this.companyFormGroup.patchValue({
							companyName: data.companyName,
							address: data.address,
							email: data.email,
							phone: data.phone,
							website: data.website,
							logoName: data.logo,
							logoFile: data.logo,
						});
					}
				},
			});
	}

	public companyFormGroup: FormGroup = this.formBuilder.group({
		companyName: [this.company ? this.company.companyName : null, [Validators.required]],
		address: [this.company ? this.company.address : null, [Validators.required]],
		email: [this.company ? this.company.email : null, [Validators.required, Validators.email]],
		phone: [this.company ? this.company.phone : null, [Validators.required, Validators.pattern('^[0-9]*$')]],
		website: [this.company ? this.company.website : null, []],
		logoName: [this.company ? this.company.logo : null, []],
		logoFile: [this.company ? this.company.logo : null, []],
	});

}
