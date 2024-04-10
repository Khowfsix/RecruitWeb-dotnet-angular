import { Component } from '@angular/core';
import { UploadCvComponent } from '../upload-cv/upload-cv.component';

@Component({
	selector: 'app-cv-manage',
	standalone: true,
	imports: [
		UploadCvComponent,
	],
	templateUrl: './cv-manage.component.html',
	styleUrl: './cv-manage.component.css'
})
export class CvManageComponent {

}
