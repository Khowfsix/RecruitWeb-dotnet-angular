import { Component } from '@angular/core';
import { MatTabsModule } from '@angular/material/tabs';
import { CandidateProfileComponent } from './candidate-profile/candidate-profile.component';
import { CvManageComponent } from './cv-manage/cv-manage.component';
import { UploadCvComponent } from './cv-manage/upload-cv/upload-cv.component';
import { JobPreferenceComponent } from './job-preference/job-preference.component';
import { RouterModule } from '@angular/router';
import { Candidate } from '../../data/candidate/candidate.model';
import { AuthService } from '../../core/services/auth.service';
import { CandidateService } from '../../data/candidate/candidate.service';

@Component({
	selector: 'app-cv',
	standalone: true,
	imports: [
		MatTabsModule,
		CandidateProfileComponent,
		CvManageComponent,
		UploadCvComponent,
		JobPreferenceComponent,

		RouterModule
	],
	templateUrl: './cv.component.html',
	styleUrl: './cv.component.css'
})
export class CvComponent {
	public mySelf: Candidate = new Candidate();

	constructor(
		private _authService: AuthService,
		private _candidateService: CandidateService
	) {
		const candidateId = _authService.getCandidateId_OfUser() as string;
		console.log(candidateId);
		_candidateService.getById(candidateId).subscribe(
			(candidate) => {
				this.mySelf = candidate;
			}
		);
	}
}
