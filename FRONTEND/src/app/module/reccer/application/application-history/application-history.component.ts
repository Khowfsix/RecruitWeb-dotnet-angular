/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ApplicationHistory } from '../../../../data/applicationHistory/applicationHistory.model';
import { DatePipe } from '@angular/common';
import { MatTabsModule } from '@angular/material/tabs';
import { CandidateJoinEvent } from '../../../../data/candidateJoinEvent/candidate-join-event.model';

@Component({
	selector: 'app-application-history',
	standalone: true,
	imports: [
		DatePipe,
		MatTabsModule
	],
	templateUrl: './application-history.component.html',
	styleUrl: './application-history.component.css'
})
export class ApplicationHistoryComponent implements OnInit {
	constructor(
		@Inject(MAT_DIALOG_DATA) public data: any,
	) { }

	ngOnInit(): void {
		// console.log("applicationHistoryData", this.applicationHistoryData)
		// console.log("candidateJoinEventData", this.candidateJoinEventData)
	}

	public applicationHistoryData: ApplicationHistory[] = this.data ? this.data.applicationHistoryData : [];
	public candidateJoinEventData: CandidateJoinEvent[] = this.data ? this.data.candidateJoinEventData : [];
}
