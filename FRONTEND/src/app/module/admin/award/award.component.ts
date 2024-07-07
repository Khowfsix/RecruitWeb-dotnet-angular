import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { AwardService } from '../../../data/award/award.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { Award } from '../../../data/award/award.model';

@Component({
	selector: 'app-award',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './award.component.html',
	styleUrl: './award.component.css'
})
export class AwardComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"awardId",
		"awardName",
		"awardOrganization",
		"issueDate",
		"description",
		"candidateId",
	];
	public displayColumn: string[] = [
		"Award Id",
		"Award Name",
		"Award Organization",
		"Issue Date",
		"Description",
		"Candidate Id",
	];
	public listAwards = new BehaviorSubject<Award[]>([]);

	constructor(
		public _awardService: AwardService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._awardService.getAllAwards().subscribe(
			awards => {
				this.listAwards.next(awards);
			},
			error => console.error(error)
		);
	}
}
