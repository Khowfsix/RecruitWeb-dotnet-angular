import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { InterviewService } from '../../../data/interview/interview.service';
import { Interview } from '../../../data/interview/interview.model';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { CommonModule } from '@angular/common';

@Component({
	selector: 'app-list-interview',
	standalone: true,
	imports: [
		CommonModule,
		MatCardModule,
		MatButtonModule,
		MatButtonToggleModule,
		MatTableModule,
		MatFormFieldModule,
		MatPaginatorModule,
	],
	templateUrl: './list-interview.component.html',
})
export class ListInterviewComponent {
	@Input() interviewerId?: string;

	listInterviews: Interview[] = [];
	displayedColumns: string[] = ['id', 'position', 'date', 'status', 'action'];
	dataSource = new MatTableDataSource(this.listInterviews);


	constructor(
		private interviewService: InterviewService
	) {
		this.interviewService.getAllByInterviewerId(this.interviewerId as string).subscribe(res => {
			this.listInterviews = res;
		});
		this.dataSource = new MatTableDataSource(this.listInterviews);
	}

	joinInterview(interview: Interview) {
		console.log(interview);
	}

	editInterview(interview: Interview) {
		console.log(interview);
	}




	applyFilter(event: Event) {
		const filterValue = (event.target as HTMLInputElement).value;
		this.dataSource.filter = filterValue.trim().toLowerCase();
		this.dataSource.filterPredicate = (data: Interview, filter: string) => {
			return data.application?.position?.positionName?.toLowerCase().includes(filter) ||
				data.company_Status?.toString().toLowerCase().includes(filter) as boolean;
		};
	}

}
