/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component } from '@angular/core';
import { InterviewService } from '../../../data/interview/interview.service';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';

@Component({
	selector: 'app-interview-update',
	standalone: true,
	imports: [CommonModule, MatCardModule],
	templateUrl: './interview-update.component.html',
	styleUrl: './interview-update.component.css',
})
export class InterviewUpdateComponent {
	constructor(private interviewService: InterviewService) {}

	ngOnInit() {
		// Initialize component, fetch data if needed
	}

	updateInterview(id: string, data: any) {
		this.interviewService.update(id, data).subscribe(
			(response: any) => {
				console.log('Interview updated successfully', response);
				// Handle success
			},
			(error: any) => {
				console.error('Error updating interview', error);
				// Handle error
			},
		);
	}
}
