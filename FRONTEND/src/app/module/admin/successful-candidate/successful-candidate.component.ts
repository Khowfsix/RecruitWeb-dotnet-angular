import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { SuccessfulCandidateService } from '../../../data/successful-candidate/successful-candidate.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { SuccessfulCandidate } from '../../../data/successful-candidate/successful-candidate.model';

@Component({
	selector: 'app-successful-candidate',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './successful-candidate.component.html',
	styleUrl: './successful-candidate.component.css'
})
export class SuccessfulCandidateComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"successfulCadidateId",
		"positionId",
		"candidateId",
		"dateSuccess",
	];
	public displayColumn: string[] = [
		"Successful-Candidate Id",
		"Position Id",
		"Candidate Id",
		"Date Success",
	];
	public listSuccessfulCandidates = new BehaviorSubject<SuccessfulCandidate[]>([]);

	constructor(
		public _successfulCandidateService: SuccessfulCandidateService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._successfulCandidateService.getAllSuccessfulCandidates().subscribe(
			successfulCandidates => {
				this.listSuccessfulCandidates.next(successfulCandidates);
			},
			error => console.error(error)
		);
	}
}
