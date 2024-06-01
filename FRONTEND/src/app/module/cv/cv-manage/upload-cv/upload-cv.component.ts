import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FileService } from '../../../../data/file/file-service.service';
import { ToastrService } from 'ngx-toastr';
import { CvAddModel } from '../../../../data/cv/cv-add-model.model';
import { AuthService } from '../../../../core/services/auth.service';
import { CvService } from '../../../../data/cv/cv.service';
import { MAT_DIALOG_DATA, MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
	selector: 'app-upload-cv',
	standalone: true,
	imports: [
		MatFormFieldModule,
		MatButtonModule,
		MatFormFieldModule,
		CommonModule
	],
	templateUrl: './upload-cv.component.html',
	styleUrl: './upload-cv.component.css'
})
export class UploadCvComponent {
	selectedFile?: File;

	@Output() cvUploaded: EventEmitter<void> = new EventEmitter<void>();

	constructor(
		private _fileService: FileService,
		private _cvService: CvService,
		private _toastService: ToastrService,
		private _authService: AuthService,
		public dialog: MatDialog
	) { }

	choosenFile(file: File): void {
		if (file.type !== 'application/pdf') {
			// Handle the error here
			console.log('Invalid file type');
			this._toastService.error('Only PDF files are allowed', 'Invalid file type', { timeOut: 3000, progressBar: true });
			return;
		}
		this.selectedFile = file;
	}

	onFileSelected(event: Event) {
		const input = event.target as HTMLInputElement;
		if (input.files && input.files.length) {
			const file = input.files[0];
			this.choosenFile(file);
		}
	}

	onDrop(event: DragEvent) {
		event.preventDefault();
		if (event.dataTransfer && event.dataTransfer.files) {
			const file = event.dataTransfer.files[0];
			this.choosenFile(file);
		}
	}

	onDragOver(event: Event) {
		event.preventDefault();
		event.stopPropagation();
		// You can add some visual feedback for dragging over
	}

	onDragLeave(event: Event) {
		event.preventDefault();
		event.stopPropagation();
		// You can remove the visual feedback
	}

	onClickUpload() {
		if (!this.selectedFile) {
			this._toastService.error('Please select a file before uploading', 'No file selected', {
				timeOut: 3000,
				progressBar: true
			});
			return;
		}
		// check if the file is smaller than 5MB
		else if (this.selectedFile.size > 5 * 1024 * 1024) {
			this._toastService.error('File size should be less than 5MB', 'File too large', {
				timeOut: 3000,
				progressBar: true
			});
		}

		this.openCvNameDialog();
	}

	openCvNameDialog() {
		if (!this.selectedFile) {
			this._toastService.error('Please select a file before uploading', 'No file selected', {
				timeOut: 3000,
				progressBar: true
			})
			return;
		}
		const dialogRef = this.dialog.open(CvNameDialogComponent, {
			data: {
				cvName: '',
				aboutMe: '',
				isDefault: false
			}
		});

		dialogRef.afterClosed().subscribe(result => {
			if (result) {
				this.callApiUploadCv(this.selectedFile!, result.cvName, result.aboutMe, result.isDefault);
			}
		});
	}

	callApiUploadCv(file: File, cvName: string, aboutMe: string, isDefault: boolean) {
		try {
			const formData: FormData = new FormData();
			formData.append('formFile', file, file.name);
			this._fileService.uploadFile(formData).subscribe(
				(res) => {
					const data: CvAddModel = {
						CandidateId: this._authService.getCandidateId_OfUser() as string,
						CvPdf: res.url,
						CvName: cvName,
						AboutMe: aboutMe,
						IsDefault: isDefault,
						IsDeleted: false
					};

					this._cvService.uploadNewCvFile(data).subscribe(
						() => {
							this._toastService.success('CV uploaded successfully', 'Success', { timeOut: 3000, progressBar: true });
						},
						(error) => {
							console.error('Failed to upload CV', error);
							this._toastService.error('Failed to upload CV', 'Error', { timeOut: 3000, progressBar: true });
						}
					)

					this.cvUploaded.emit();
				},
				(error) => {
					console.error('Failed to upload CV', error);
					this._toastService.error('Failed to upload CV', 'Error', { timeOut: 3000, progressBar: true });
				}
			)
		} catch (error) {
			console.error(error);
		}
	}
}

export interface CvDialogData {
	cvName: string;
	aboutMe: string;
	isDefault: boolean;
}

@Component({
	selector: 'app-cv-name-dialog',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,
		MatDialogModule,
		MatFormFieldModule,
		MatInputModule,
		MatButtonModule,
		MatCheckboxModule
	],
	templateUrl: './upload-cv-dialog.component.html',
})
export class CvNameDialogComponent {
	constructor(
		public dialogRef: MatDialogRef<CvNameDialogComponent>,
		@Inject(MAT_DIALOG_DATA) public data: CvDialogData
	) { }

	onNoClick(): void {
		this.dialogRef.close();
	}
}
