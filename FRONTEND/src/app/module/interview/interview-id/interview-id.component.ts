/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from '../../../core/services/auth.service';
import { PermissionService } from '../../../core/services/permission.service';
import { InterviewService } from '../../../data/interview/interview.service';
import { NoteFieldComponent } from './note-field/note-field.component';
import { QuestionTableComponent } from './question-table/question-table.component';
import { RadarPlotComponent } from './radar-plot/radar-plot.component';
import { ScoreTableComponent } from './score-table/score-table.component';

@Component({
	selector: 'app-pass',
	standalone: true,
	imports: [
		MatChipsModule,
		MatIconModule
	],
	template: `
    <mat-chip-listbox>
		<mat-chip color="accent" selected>
			<mat-icon>done</mat-icon>
			Passed
		</mat-chip>
	</mat-chip-listbox>
	`,
	styles: [`
    mat-chip {
		background-color: #4caf50;
		color: white;
    }`]
})
export class PassComponent { }

@Component({
	selector: 'app-fail',
	standalone: true,
	imports: [MatChipsModule, MatIconModule],
	template: `
		<mat-chip-listbox>
			<mat-chip color="warn" selected>
				<mat-icon>close</mat-icon>
				Failed
			</mat-chip>
		</mat-chip-listbox>
	`,
	styles: [
		`
			mat-chip {
				background-color: #f44336;
				color: white;
			}
		`,
	],
})
export class FailComponent { }

@Component({
	selector: 'app-interview-id',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,

		NoteFieldComponent,
		QuestionTableComponent,
		RadarPlotComponent,
		ScoreTableComponent,
		PassComponent,
		FailComponent,

		MatCardModule,
		MatIconModule,
		MatDividerModule,
		MatGridListModule,
		MatChipsModule,
	],
	templateUrl: './interview-id.component.html',
})
export class InterviewIdComponent {
	interviewId?: string;
	interview: any;
	role?: string;
	user: any;

	constructor(
		private router: Router,
		private route: ActivatedRoute,
		private dialog: MatDialog,
		private interviewService: InterviewService,

		private authService: AuthService,
		private permissionService: PermissionService,
		private cookieService: CookieService
	) { }

	ngOnInit() {
		this.interviewId = this.route.snapshot.paramMap.get('interviewid')!;
		this.user = this.authService.getCurrentUser();
		this.role = this.permissionService.getRoleOfUser(this.cookieService.get('jwt'))[0];
		this.getInterviewResult();
	}

	getInterviewResult() {
		// this.interviewService.getInterviewResult(this.interviewId, this.user.token).subscribe(
		// 	(result) => {
		// 		this.interview = result;
		// 	},
		// 	(error) => {
		// 		console.error('Error fetching interview result', error);
		// 	}
		// );
	}

	handleStart() {
		this.router.navigate([`/company/interview/${this.interviewId}/start`]);
	}

	handleAccept() {
		// this.interviewService.acceptInterview(this.interview.interviewid, this.interview.applicationid, this.interview, this.user.token).subscribe(
		// 	() => {
		// 		// Handle success
		// 		this.getInterviewResult(); // Refresh data
		// 	},
		// 	(error) => {
		// 		console.error('Error accepting interview', error);
		// 	}
		// );
	}

	handleReject() {
		// this.interviewService.rejectInterview(this.interview.interviewid, this.interview.applicationid, this.interview, this.user.token).subscribe(
		// 	() => {
		// 		// Handle success
		// 		this.getInterviewResult(); // Refresh data
		// 	},
		// 	(error) => {
		// 		console.error('Error rejecting interview', error);
		// 	}
		// );
	}

	openAlertDialog(message: string, action: () => void) {
		console.log(message, action);
		// const dialogRef = this.dialog.open(AlertDialogComponent, {
		// 	data: { message: message }
		// });

		// dialogRef.afterClosed().subscribe(result => {
		// 	if (result) {
		// 		action();
		// 	}
		// });
	}
}
