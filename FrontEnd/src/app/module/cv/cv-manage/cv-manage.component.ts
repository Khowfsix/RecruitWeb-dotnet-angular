import { Component } from '@angular/core';
import { UploadCvComponent } from './upload-cv/upload-cv.component';
import { MatDividerModule } from '@angular/material/divider';
import { FileService } from '../../../data/file/file-service.service';
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
		private _fileService: FileService,
		private _cvService: CvService,
		private _authService: AuthService
	) {
		this._candidateId = _authService.getCandidateId_OfUser();
		_cvService.getListCvsOfCandidate(this._candidateId as string).subscribe((cvs) => {
			this.listCvsOfCandidate = cvs;
		})

		console.log(this.listCvsOfCandidate);
	}

	uploadNewCv() {

	}
}
