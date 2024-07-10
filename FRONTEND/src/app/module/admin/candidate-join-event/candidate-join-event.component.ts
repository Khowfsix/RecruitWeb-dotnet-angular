import { Component } from '@angular/core';
import { ActionType, GenericTableComponent } from "../generic/generic-table.component";
import { CandidateJoinEventService } from '../../../data/candidateJoinEvent/candidate-join-event.service';
import { CandidateJoinEvent } from '../../../data/candidateJoinEvent/candidate-join-event.model';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-candidate-join-event',
	standalone: true,
	templateUrl: './candidate-join-event.component.html',
	styleUrl: './candidate-join-event.component.css',
	imports: [GenericTableComponent]
})
export class CandidateJoinEventComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"candidateJoinEventId",
		"candidateId",
		"eventId",
		"dateJoin",
	];
	public displayColumn: string[] = [
		"Candidate-Join-Event Id",
		"Candidate Id",
		"Event Id",
		"Date Join",
	];
	public listCandidateJoinEvents = new BehaviorSubject<CandidateJoinEvent[]>([]);

	constructor(
		public _candidateJoinEventService: CandidateJoinEventService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._candidateJoinEventService.getAll().subscribe(
			candidateJoinEvents => {
				this.listCandidateJoinEvents.next(candidateJoinEvents);
			},
			error => console.error(error)
		);
	}
}
