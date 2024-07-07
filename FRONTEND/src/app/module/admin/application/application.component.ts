import { Component } from '@angular/core';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { ApplicationService } from '../../../data/application/application.service';
import { Application } from '../../../data/application/application.model';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-application',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './application.component.html',
	styleUrl: './application.component.css',
})
export class ApplicationComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"applicationId",
		"cvId",
		"positionId",
		"company_Status",
		"candidate_Status",
		"createdTime",
		"priority",
	];
	public displayColumn: string[] = [
		"ID",
		"CvId",
		"PositionId",
		"Company Status",
		"Candidate Status",
		"Created Time",
		"Priority",
	];
	public listApplications = new BehaviorSubject<Application[]>([]);

	constructor(
		public _applicationService: ApplicationService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._applicationService.getAll().subscribe(
			applications => {
				this.listApplications.next(applications.filter(sk => sk.isDeleted == false));
			},
			error => console.error(error)
		);
	}
}
