import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { InterviewerService } from '../../../data/interviewer/interviewer.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { Interviewer } from '../../../data/interviewer/interviewer.model';

@Component({
	selector: 'app-interviewer',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './interviewer.component.html',
	styleUrl: './interviewer.component.css'
})
export class InterviewerComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"interviewerId",
		"userId",
		"companyId",
	];
	public displayColumn: string[] = [
		"Interviewer Id",
		"User Id",
		"Company Id",
	];
	public listInterviewers = new BehaviorSubject<Interviewer[]>([]);

	constructor(
		public _interviewerService: InterviewerService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._interviewerService.getAll().subscribe(
			interviewers => {
				this.listInterviewers.next(interviewers.filter(e => !e.isDeleted));
			},
			error => console.error(error)
		);
	}
}
