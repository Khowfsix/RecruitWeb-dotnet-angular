import { CommonModule } from '@angular/common';
import { Component, Inject, Input } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { ApplicationAddModel, ApplyDialogDataInput } from '../../../data/application/application.model';
import { UploadCvComponent } from '../../cv/cv-manage/upload-cv/upload-cv.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CandidateService } from '../../../data/candidate/candidate.service';
import { CvService } from '../../../data/cv/cv.service';
import { Candidate } from '../../../data/candidate/candidate.model';
import { CV } from '../../../data/cv/cv.model';
import { ApplicationService } from '../../../data/application/application.service';
import { response } from 'express';

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
		MatFormFieldModule,
	],
	templateUrl: './apply-dialog.component.html',
})
export class ApplyDialogComponent {
	@Input() candidateId?: string;

	panelOpenState = false;
	candidate?: Candidate;

	defaultCv?: CV;
	listCv?: CV[];
	optionCv?: "default" | "orther";
	newApplication?: ApplicationAddModel = new ApplicationAddModel();


	applyForm = new FormGroup({
		aboutMe: new FormControl('', [
			Validators.minLength(10)
		]),
	});


	constructor(
		@Inject(MAT_DIALOG_DATA) public data: ApplyDialogDataInput,
		private _candidateService: CandidateService,
		private _cvService: CvService,
		private _applyService: ApplicationService

	) {
		this._candidateService.getById(data?.candidateId as string).subscribe(
			(response) => {
				this.candidate = response;
			}
		);

		this._cvService.getListCvsOfCandidate(data?.candidateId as string).subscribe(
			(response) => {
				if (typeof response === 'string') {
					this.listCv = [];
				}
				else {
					this.listCv = response;
				}
			}
		);

		this._cvService.getDefaultCv(data?.candidateId as string).subscribe(
			(response) => {
				if (typeof response !== 'string') {
					this.defaultCv = response;
					console.log(this.defaultCv);
				}
			}
		)

		this.newApplication = {
			positionId: this.data.position?.positionId,
			cvid: this.defaultCv?.cvid,
		}
	}

	onChangeOptionCv(option: "default" | "orther") {
		this.optionCv = option;
		console.log(this.optionCv);
	}

	onClickApply() {
		this._applyService.postNewApplication(this.newApplication!).subscribe(
			(response) => {
				console.log(response);
			},
			(error) => {
				console.error(error);
			}
		);
	}
}
