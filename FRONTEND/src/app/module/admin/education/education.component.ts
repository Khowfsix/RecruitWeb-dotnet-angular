import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { EducationService } from '../../../data/education/education.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { Education } from '../../../data/education/education.model';

@Component({
	selector: 'app-education',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './education.component.html',
	styleUrl: './education.component.css'
})
export class EducationComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"educationId",
		"school",
		"major",
		"from",
		"to",
		"additionalDetails",
		"candidateId",
	];
	public displayColumn: string[] = [
		"Education Id",
		"School",
		"Major",
		"From",
		"To",
		"Additional Details",
		"Candidate Id",
	];
	public listEducations = new BehaviorSubject<Education[]>([]);

	constructor(
		public _educationService: EducationService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._educationService.getAllEducations().subscribe(
			educations => {
				this.listEducations.next(educations);
			},
			error => console.error(error)
		);
	}
}
