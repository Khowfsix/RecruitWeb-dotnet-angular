import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { PersonalProjectService } from '../../../data/personal-project/personal-project.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { PersonalProject } from '../../../data/personal-project/personal-project.model';

@Component({
	selector: 'app-personal-project',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './personal-project.component.html',
	styleUrl: './personal-project.component.css'
})
export class PersonalProjectComponent {
	public actions: ActionType[] = ['read'];
	public listProps: string[] = [
		"personalProjectId",
		"projectName",
		"from",
		"to",
		"projectUrl",
		"candidateId",
	];
	public displayColumn: string[] = [
		"Personal-Project Id",
		"Project Name",
		"From",
		"To",
		"Project Url",
		"Candidate Id",
	];
	public detailListProps: string[] = [
		"shortDescription",
	]
	public detailDisplayedColumns: string[] = [
		"Short Description",
	]
	public listPersonalProjects = new BehaviorSubject<PersonalProject[]>([]);

	constructor(
		public _personalProjectService: PersonalProjectService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._personalProjectService.getAllPersonalProjects().subscribe(
			personalProjects => {
				this.listPersonalProjects.next(personalProjects);
			},
			error => console.error(error)
		);
	}
}
