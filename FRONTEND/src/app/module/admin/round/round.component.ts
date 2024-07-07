import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { RoundService } from '../../../data/round/round.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { Round } from '../../../data/round/round.module';

@Component({
	selector: 'app-round',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './round.component.html',
	styleUrl: './round.component.css'
})
export class RoundComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"roundId",
		"interviewId",
		"questionId",
		"score",
	];
	public displayColumn: string[] = [
		"Round Id",
		"Interview Id",
		"Question Id",
		"Score",
	];
	public listRounds = new BehaviorSubject<Round[]>([]);

	constructor(
		public _roundService: RoundService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._roundService.getAllRounds().subscribe(
			rounds => {
				this.listRounds.next(rounds);
			},
			error => console.error(error)
		);
	}
}
