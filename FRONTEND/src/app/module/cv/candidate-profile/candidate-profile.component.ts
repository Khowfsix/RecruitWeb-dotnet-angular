import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { NgbProgressbarModule, NgbScrollSpyModule } from '@ng-bootstrap/ng-bootstrap';
import { PersonalDetailComponent } from './personal-detail/personal-detail.component';
import { CandidateEducationComponent } from './candidate-education/candidate-education.component';
import { WorkExperienceComponent } from './work-experience/work-experience.component';
import { CandidateSkillsComponent } from './candidate-skills/candidate-skills.component';
import { PersonalProjectComponent } from './personal-project/personal-project.component';
import { CandidateCertificateComponent } from './candidate-certificate/candidate-certificate.component';
import { CandidateAwardsComponent } from './candidate-awards/candidate-awards.component';
import { Candidate } from '../../../data/candidate/candidate.model';

@Component({
	selector: 'app-candidate-profile',
	standalone: true,
	imports: [
		MatDividerModule,
		MatButtonModule,
		NgbProgressbarModule,
		NgbScrollSpyModule,

		PersonalDetailComponent,
		CandidateEducationComponent,
		WorkExperienceComponent,
		CandidateSkillsComponent,
		PersonalProjectComponent,
		CandidateCertificateComponent,
		CandidateAwardsComponent
	],
	templateUrl: './candidate-profile.component.html',
	styleUrl: './candidate-profile.component.css'
})
export class CandidateProfileComponent {
	@Input() candidate: Candidate = new Candidate();

	constructor() {
		console.log(this.candidate.user?.userName);
	}
}
