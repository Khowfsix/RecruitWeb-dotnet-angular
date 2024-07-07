import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { CvService } from '../../../data/cv/cv.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { CV } from '../../../data/cv/cv.model';

@Component({
	selector: 'app-cv',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './cv.component.html',
	styleUrl: './cv.component.css'
})
export class CVComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"cvid",
		"candidateId",
		"cvPdf",
		"cvName",
		"aboutMe",
		"isDefault"
	];
	public displayColumn: string[] = [
		"CV Id",
		"Candidate Id",
		"CV Pdf",
		"CV Name",
		"About Me",
		"Is Default"
	];
	public listCVs = new BehaviorSubject<CV[]>([]);

	constructor(
		public _cvService: CvService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._cvService.getAllCVs().subscribe(
			cvs => {
				this.listCVs.next(cvs.filter(e => !e.isDeleted));
			},
			error => console.error(error)
		);
	}
}
