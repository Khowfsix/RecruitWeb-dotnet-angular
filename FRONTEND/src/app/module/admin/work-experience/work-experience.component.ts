import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { WorkExperienceService } from '../../../data/work-experience/work-experience.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { WorkExperience } from '../../../data/work-experience/work-experience.model';

@Component({
	selector: 'app-work-experience',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './work-experience.component.html',
	styleUrl: './work-experience.component.css'
})
export class WorkExperienceComponent {
	public actions: ActionType[] = ['read'];
	public listProps: string[] = [
		"workExperienceId",
		"jobTitle",
		"company",
		"from",
		"to",
		"project",
		"candidateId",
	];
	public displayColumn: string[] = [
		"Work-Experience Id",
		"Job Title",
		"Company",
		"From",
		"To",
		"Project",
		"Candidate Id",
	];
	public detailListProps: string[] = [
		"description",
	];
	public detailDisplayedColumns: string[] = [
		"Description",
	];

	public listWorkExperiences = new BehaviorSubject<WorkExperience[]>([]);

	constructor(
		public _workExperienceService: WorkExperienceService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._workExperienceService.getAllWorkExperiences().subscribe(
			workExperiences => {
				this.listWorkExperiences.next(workExperiences);
			},
			error => console.error(error)
		);
	}
}
