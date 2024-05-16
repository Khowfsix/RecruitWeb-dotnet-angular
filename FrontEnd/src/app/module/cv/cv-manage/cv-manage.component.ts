import { Component } from '@angular/core';
import { UploadCvComponent } from './upload-cv/upload-cv.component';
import { MatDividerModule } from '@angular/material/divider';
import { CvService } from '../../../data/cv/cv.service';
import { AuthService } from '../../../core/services/auth.service';
import { MatCardModule } from '@angular/material/card';
import { CV } from '../../../data/cv/cv.model';

@Component({
	selector: 'app-cv-manage',
	standalone: true,
	imports: [
		UploadCvComponent,
		MatDividerModule,
		MatCardModule
	],
	templateUrl: './cv-manage.component.html',
	styleUrl: './cv-manage.component.css'
})
export class CvManageComponent {
	public listCvsOfCandidate: CV[] = [];
	private _candidateId: string | undefined = null!;

	constructor(
		private _cvService: CvService,
		private _authService: AuthService
	) {
		this.handleRefresh();
	}

	handleRefresh() {
		this._candidateId = this._authService.getCandidateId_OfUser();
		this._cvService.getListCvsOfCandidate(this._candidateId as string).subscribe((cvs) => {
			console.log(cvs);
			if (cvs != 'Not found' && typeof cvs !== 'string') {
				this.listCvsOfCandidate = cvs;
			}
		})
	}
}

import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Pipe({
	name: 'safeUrl'
})
export class SafeUrlPipe implements PipeTransform {
	constructor(private sanitizer: DomSanitizer) { }

	transform(url: string) {
		return this.sanitizer.bypassSecurityTrustResourceUrl(url);
	}
}
