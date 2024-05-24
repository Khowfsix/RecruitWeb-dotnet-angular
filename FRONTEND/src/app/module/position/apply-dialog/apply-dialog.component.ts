import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { ApplyDialogDataInput } from '../../../data/application/application.model';
import { UploadCvComponent } from '../../cv/cv-manage/upload-cv/upload-cv.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CandidateService } from '../../../data/candidate/candidate.service';
import { CvService } from '../../../data/cv/cv.service';
import { Candidate } from '../../../data/candidate/candidate.model';
import { CV } from '../../../data/cv/cv.model';

@Component({
	selector: 'app-apply-dialog',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,

		UploadCvComponent,

		MatDialogModule,
		MatButtonModule,
		MatExpansionModule,
		MatFormFieldModule
	],
	templateUrl: './apply-dialog.component.html',
})
export class ApplyDialogComponent {
	candidate?: Candidate;
	listCv?: CV[];
	option: "default" | "orther" | "upload" = "default";

	listOptions = {
		default: true,
		orther: false,
		upload: false,
	}

	constructor(
		@Inject(MAT_DIALOG_DATA) public data: ApplyDialogDataInput,
		private _candidateService: CandidateService,
		private _cvService: CvService
	) {
		_candidateService.getById(data?.candidateId as string).subscribe(
			(response) => {
				this.candidate = response;
			}
		);

		_cvService.getListCvsOfCandidate(data?.candidateId as string).subscribe(
			(response) => {
				if (typeof response === 'string') {
					this.listCv = [];
				}
				else {
					this.listCv = response;
				}
			}
		);
	}

	uploadOptionCV(option: "default" | "orther" | "upload") {
		if (option === "default") {
			this.listOptions.default = true;
			this.listOptions.orther = false;
			this.listOptions.upload = false;


		} else if (option === "orther") {
			this.listOptions.default = false;
			this.listOptions.orther = true;
			this.listOptions.upload = false;
		} else if (option === "upload") {
			this.listOptions.default = false;
			this.listOptions.orther = false;
			this.listOptions.upload = true;
		}

		console.log(this.listOptions);
	}
}
