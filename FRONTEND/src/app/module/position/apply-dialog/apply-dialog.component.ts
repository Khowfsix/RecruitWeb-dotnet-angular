import { CommonModule } from '@angular/common';
import { Component, Inject, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { PdfJsViewerModule } from 'ng2-pdfjs-viewer';
import { ApplicationAddModel, ApplyDialogDataInput } from '../../../data/application/application.model';
import { ApplicationService } from '../../../data/application/application.service';
import { Candidate } from '../../../data/candidate/candidate.model';
import { CandidateService } from '../../../data/candidate/candidate.service';
import { CV } from '../../../data/cv/cv.model';
import { CvService } from '../../../data/cv/cv.service';
// import { PdfViewerModule } from 'ng2-pdf-viewer';

@Component({
	selector: 'app-apply-dialog',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,

		// PdfViewerModule,

		MatDialogModule,
		MatButtonModule,
		MatExpansionModule,
		MatFormFieldModule,
		MatInputModule,
		MatRadioModule,

		PdfJsViewerModule
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
	selected_CvId?: string;

	newApplication?: ApplicationAddModel = new ApplicationAddModel();
	applyForm: FormGroup = new FormGroup({});


	constructor(
		@Inject(MAT_DIALOG_DATA) public data: ApplyDialogDataInput,
		private _candidateService: CandidateService,
		private _cvService: CvService,
		private _applyService: ApplicationService,
		private formBuilder: FormBuilder,

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
					this.listCv = response.filter(cv => !cv.isDefault);
				}
			}
		);

		this._cvService.getDefaultCv(data?.candidateId as string).subscribe(
			(response) => {
				if (typeof response !== 'string') {
					this.defaultCv = response;
				}
			}
		)

		this.newApplication = {
			positionId: this.data.position?.positionId,
			cvid: this.defaultCv?.cvid,
			introduce: ""
		}

		this.applyForm = this.formBuilder.group({
			aboutMe: new FormControl('', [
				Validators.minLength(10)
			]),
			selectedCv: new FormControl()
		});

		this.optionCv = 'default';
	}

	onChangeOptionCv(option: "default" | "orther") {
		this.optionCv = option;
	}

	onClickApply() {
		this.newApplication = {
			...this.newApplication,
			introduce: this.applyForm.value.aboutMe,
			cvid: this.optionCv === "default" ? this.defaultCv?.cvid : this.applyForm.value.selectedCv
		}
		console.log(this.newApplication);
		this.callApiAplly();
	}

	callApiAplly() {
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
