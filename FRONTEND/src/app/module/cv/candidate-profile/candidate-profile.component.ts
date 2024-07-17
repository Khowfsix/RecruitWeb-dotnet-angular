import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import {
	NgbProgressbarModule,
	NgbScrollSpyModule,
} from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from '../../../core/services/auth.service';
import { WebUser } from '../../../data/authentication/web-user.model';
import { Candidate } from '../../../data/candidate/candidate.model';
import { CandidateService } from '../../../data/candidate/candidate.service';
import { CandidateAwardsComponent } from './candidate-awards/candidate-awards.component';
import { CandidateCertificateComponent } from './candidate-certificate/candidate-certificate.component';
import { CandidateEducationComponent } from './candidate-education/candidate-education.component';
import { CandidateSkillsComponent } from './candidate-skills/candidate-skills.component';
import { PersonalDetailComponent } from './personal-detail/personal-detail.component';
import { PersonalProjectComponent } from './personal-project/personal-project.component';
import { WorkExperienceComponent } from './work-experience/work-experience.component';

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
		CandidateAwardsComponent,
	],
	templateUrl: './candidate-profile.component.html',
	styleUrl: './candidate-profile.component.css',
})
export class CandidateProfileComponent {
	candidateId?: string;
	candidate?: Candidate;
	user?: WebUser;

	constructor(
		private _candidateService: CandidateService,
		private _authService: AuthService,
	) {
		this.candidateId = this._authService.getCandidateId_OfUser() as string;
		this.user = this._authService.getLocalCurrentUser();
		this.refreshPage();
	}

	refreshPage() {
		this._candidateService
			.getById(this.candidateId as string)
			.subscribe((candidate) => {
				this.candidate = candidate;
			});
	}
}
