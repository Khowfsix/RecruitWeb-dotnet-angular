import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { InterviewService } from '../../../data/interview/interview.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { Interview } from '../../../data/interview/interview.model';

@Component({
	selector: 'app-interview',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './interview.component.html',
	styleUrl: './interview.component.css'
})
export class InterviewComponent {
	public actions: ActionType[] = ['read'];
	public listProps: string[] = [
		"interviewId",
		"interviewerId",
		"recruiterId",
		"applicationId",
		"priority",
		"meetingDate",
		"addressOrStartURL",
		"interviewType",
	];
	public displayColumn: string[] = [
		"Interview Id",
		"Interviewer Id",
		"Recruiter Id",
		"Application Id",
		"Priority",
		"Meeting Date",
		"Address-Start URL",
		"Interview Type",
	];

	public detailDisplayedColumns: string[] = [
		"Detail Location-Join URL",
		"Start Time",
		"End Time",
		"Company Status",
		"Candidate Status",
		"Notes",
	]
	public detailListProps: string[] = [
		"detailLocationOrJoinURL",
		"startTime",
		"endTime",
		"company_Status",
		"candidate_Status",
		"notes",
	]
	public listInterviews = new BehaviorSubject<Interview[]>([]);

	constructor(
		public _interviewService: InterviewService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._interviewService.getAll().subscribe(
			interviews => {
				this.listInterviews.next(interviews.filter(e => !e.isDeleted));
			},
			error => console.error(error)
		);
	}
}
