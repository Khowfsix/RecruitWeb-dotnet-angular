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
		MatCardModule,

		CommonModule,
	],
	templateUrl: './cv-manage.component.html',
	styleUrl: './cv-manage.component.css'
})
export class CvManageComponent {
	public listCvsOfCandidate?: CV[];
	private _candidateId?: string;

	constructor(
		private _cvService: CvService,
		private _authService: AuthService,
		private _toastService: ToastrService
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


	onClickView(cvLink: any) {
		window.open(cvLink, '_blank');
	}

	onClickDelete(cvId: any) {
		// this._cvService.deleteCv(cvId).subscribe(
		// 	() => {
		// 		this._toastService.success('CV deleted successfully', 'Success', { timeOut: 3000, progressBar: true });
		// 		this.handleRefresh();
		// 	},
		// 	(error) => {
		// 		console.error('Failed to delete CV', error);
		// 		this._toastService.error('Failed to delete CV', 'Error', { timeOut: 3000, progressBar: true });
		// 	}
		// )
	}
}

import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Pipe({
	name: 'safeUrl'
})
export class SafeUrlPipe implements PipeTransform {
	constructor(private sanitizer: DomSanitizer) { }

	transform(url: string) {
		return this.sanitizer.bypassSecurityTrustResourceUrl(url);
	}
}
