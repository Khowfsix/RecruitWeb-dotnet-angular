/* eslint-disable @typescript-eslint/no-explicit-any */
import { AfterViewInit, Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input'
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ReportService } from '../../../../data/report/report.service';
import { Report } from '../../../../data/report/report.model';
import { Report_ReportType } from '../../../../shared/enums/EReport.model';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { ExportService } from '../../../../data/export/export.service';
import { FileService } from '../../../../data/file/file-service.service';
import { AuthService } from '../../../../core/services/auth.service';
import { MatIconModule } from '@angular/material/icon';

@Component({
	selector: 'app-add-form',
	standalone: true,
	imports: [
		MatIconModule,
		MatSelectModule,
		MatOptionModule,
		ReactiveFormsModule,
		MatButtonModule,
		MatInputModule,
		MatFormFieldModule
	],
	templateUrl: './add-form.component.html',
	styleUrl: './add-form.component.css'
})
export class AddFormComponent implements AfterViewInit {
	constructor(
		// Dialog
		@Inject(MAT_DIALOG_DATA) public data: any,
		private dialogRef: MatDialogRef<AddFormComponent>,

		private _authService: AuthService,
		private _fileService: FileService,
		private _exportService: ExportService,
		private _reportService: ReportService,
		private _formBuilder: FormBuilder,
		private _toastr: ToastrService,
	) { }

	ngAfterViewInit(): void {
		if (this.isEditForm)
			this.addForm.disable();
		else {
			this.addForm.get('reportType')?.disable();
			this.addForm.get('fileName')?.disable();
		}
	}

	public reportType: typeof Report_ReportType = Report_ReportType;
	public foundReport: Report = this.data ? this.data.foundReport : undefined;
	public exportFile: File = this.data ? this.data.exportFile : undefined;
	public isEditForm = this.data ? this.data.isEditForm : false;
	public isEditing = false;

	public addForm: FormGroup = this._formBuilder.group({
		reportName: [this.isEditForm ? this.foundReport.reportName : '', [Validators.required]],
		reportType: [this.isEditForm ? this.foundReport.reportType : this.data.reportType, [Validators.required]],
		fileName: [
			this.isEditForm ? this.foundReport.fileURL : null,
			[Validators.required]
		],
		file: [
			this.isEditForm ? this.foundReport.fileURL : null,
			[Validators.required]
		],
	});

	private generateNewFileName(originalFileName: string): string {
		const randomString = Math.random().toString(36).substring(2, 8);
		return `${originalFileName}_${randomString}`;
	}

	public onFileSelected(event: any) {
		const file = event.target?.files?.[0];
		if (file) {
			const newFileName = this.generateNewFileName(file.name);
			const renamedFile = new File([file], newFileName, { type: file.type });

			this.addForm.get('fileName')?.setValue(file.name)
			this.addForm.get('file')?.setValue(renamedFile)
		}
	}

	public edit() {
		this.isEditing = !this.isEditing;
		if (this.isEditing)
			this.addForm.enable();
		else
			this.addForm.disable();
	}

	public saveReport() {
		console.log('aaaaaaaaaa')
		const formData = new FormData();
		formData.append('formFile', this.exportFile, this.exportFile.name);
		this._fileService.uploadFile(formData).subscribe(resp => {
			this.callApiSaveReport(resp.url);
		});
	}

	public callApiSaveReport(fileURL: string) {
		this._reportService.createReport(
			{
				reportName: this.addForm.value.reportName,
				userId: this._authService.getLocalCurrentUser().id,
				reportType: this.data.reportType,
				fileURL: fileURL
			}
		).subscribe({
			next: () => {
				this.dialogRef.close();
				this._toastr.success('Created Report...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Save Report Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}

	public updateReport() {
		if (this.foundReport.userId !== this._authService.getLocalCurrentUser().id) {
			this._toastr.error("Update failed - not your report", "Update report failed", {
				timeOut: 3000,
				positionClass: 'toast-top-center',
				toastClass: ' my-custom-toast ngx-toastr',
				progressBar: true
			});
			return;
		}

		const formValue = this.addForm.value;

		if (this.foundReport.fileURL !== formValue.fileName) {
			const file: File = this.addForm.get('file')?.value;
			if (file) {
				const formData = new FormData();
				formData.append('newImage', file, file.name);
				formData.append('oldImageUrl', this.foundReport.fileURL ?? '');

				this._fileService.updateFile(formData).subscribe({
					next: (response: any) => {
						this.callApiUpdateReport(response.url);
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
			this.callApiUpdateReport(this.foundReport.fileURL);
		}

	}

	public callApiUpdateReport(fileURL?: string) {
		this._reportService.updateReport(this.foundReport.reportId!, {
			reportName: this.addForm.value.reportName,
			userId: this._authService.getLocalCurrentUser().id,
			reportType: this.addForm.value.reportType,
			fileURL: fileURL
		}).subscribe({
			next: () => {
				this.dialogRef.close();
				this._toastr.success('Updated Report...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this._toastr.error('Something wrong...', 'Update Report Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		})
	}
}
