import { Component } from '@angular/core';
import { ActionType, GenericTableComponent } from "../generic/generic-table.component";
import { CandidateService } from '../../../data/candidate/candidate.service';
import { Candidate } from '../../../data/candidate/candidate.model';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-candidate',
	standalone: true,
	templateUrl: './candidate.component.html',
	styleUrl: './candidate.component.css',
	imports: [GenericTableComponent]
})
export class CandidateComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"candidateId",
		"userId",
		"aboutMe",
	];
	public displayColumn: string[] = [
		"Candidate Id",
		"User Id",
		"About Me",
	];
	public listCandidates = new BehaviorSubject<Candidate[]>([]);

	constructor(
		public _candidateService: CandidateService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._candidateService.getAllCandidates().subscribe(
			candidates => {
				this.listCandidates.next(candidates.filter(sk => sk.isDeleted == false));
			},
			error => console.error(error)
		);
	}
}
