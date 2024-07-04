/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Interview } from '../../../../data/interview/interview.model';
import { CommonModule, DatePipe } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Interview_Type } from '../../../../shared/enums/EInterview.model';

@Component({
	selector: 'app-interview-history',
	standalone: true,
	imports: [
		DatePipe,
		CommonModule,
		RouterModule,
	],
	templateUrl: './interview-history.component.html',
	styleUrl: './interview-history.component.css'
})
export class InterviewHistoryComponent {
	constructor(
		@Inject(MAT_DIALOG_DATA) public data: any,
	) { }
	public interview_Type: typeof Interview_Type = Interview_Type;

	public interviewsData: Interview[] = this.data ? this.data.interviewsData : [];
}
