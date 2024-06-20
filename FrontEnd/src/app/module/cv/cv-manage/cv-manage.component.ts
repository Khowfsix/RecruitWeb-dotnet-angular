/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { PdfJsViewerModule } from 'ng2-pdfjs-viewer';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from '../../../core/services/auth.service';
import { CV } from '../../../data/cv/cv.model';
import { CvService } from '../../../data/cv/cv.service';
import { UploadCvComponent } from './upload-cv/upload-cv.component';

@Component({
	selector: 'app-cv-manage',
	standalone: true,
	imports: [
		UploadCvComponent,

		PdfJsViewerModule,

		MatDividerModule,
		MatCardModule,
		MatButtonModule,

		CommonModule,
	],
	templateUrl: './cv-manage.component.html',
	styleUrl: './cv-manage.component.css'
})
export class CvManageComponent {
	public listCvsOfCandidate?: CV[];
	private listCvsBehavior?: BehaviorSubject<CV[]> = new BehaviorSubject<CV[]>([]);
	private _candidateId?: string;

	constructor(
		private _cvService: CvService,
		private _authService: AuthService,
		private _toastService: ToastrService
	) {
		this._candidateId = this._authService.getCandidateId_OfUser();
		this.handleRefresh();
	}

	reload() {
		location.reload();
	}

	handleRefresh() {
		this._cvService.getListCvsOfCandidate(this._candidateId as string).subscribe((cvs) => {
			if (cvs != 'Not found' && typeof cvs !== 'string') {
				this.listCvsBehavior?.next(cvs);
				this.listCvsBehavior?.asObservable().subscribe(data => this.listCvsOfCandidate = data);
			}
		})
	}


	onClickView(cvLink: string | undefined) {
		window.open(cvLink, '_blank');
	}

	onClickDelete(cv: CV) {
		this._cvService.deleteCv(cv.cvid!).subscribe({
			next: () => {
				this._toastService.success(`CV ${cv.cvName} deleted successfully`, 'Success', { timeOut: 3000, progressBar: true });
				this.handleRefresh();
			},
			error: (err) => {
				console.error('Failed to delete CV', err);
				this._toastService.error('Failed to delete CV', 'Error', { timeOut: 3000, progressBar: true });
			}
		});
	}
}

// import { Pipe, PipeTransform } from '@angular/core';
// import { DomSanitizer } from '@angular/platform-browser';
// import { CommonModule } from '@angular/common';
// import { ToastrService } from 'ngx-toastr';

// @Pipe({
// 	name: 'safeUrl'
// })
// export class SafeUrlPipe implements PipeTransform {
// 	constructor(private sanitizer: DomSanitizer) { }

// 	transform(url: string) {
// 		return this.sanitizer.bypassSecurityTrustResourceUrl(url);
// 	}
// }
