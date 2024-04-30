import { Component } from '@angular/core';
import { MatTabsModule } from '@angular/material/tabs';
import { CandidateProfileComponent } from './candidate-profile/candidate-profile.component';
import { CvManageComponent } from './cv-manage/cv-manage.component';
import { UploadCvComponent } from './cv-manage/upload-cv/upload-cv.component';
import { JobPreferenceComponent } from './job-preference/job-preference.component';
import { RouterModule } from '@angular/router';

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
export class CvComponent { }
