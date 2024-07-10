import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { RecruiterService } from '../../../data/recruiter/recruiter.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { Recruiter } from '../../../data/recruiter/recruiter.model';

@Component({
	selector: 'app-recruiter',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './recruiter.component.html',
	styleUrl: './recruiter.component.css'
})
export class RecruiterComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"recruiterId",
		"userId",
		"companyId",
	];
	public displayColumn: string[] = [
		"Recruiter Id",
		"User Id",
		"Company Id",
	];
	public listRecruiters = new BehaviorSubject<Recruiter[]>([]);

	constructor(
		public _recruiterService: RecruiterService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._recruiterService.getAll().subscribe(
			recruiters => {
				this.listRecruiters.next(recruiters.filter(e => !e.isDeleted));
			},
			error => console.error(error)
		);
	}
}
