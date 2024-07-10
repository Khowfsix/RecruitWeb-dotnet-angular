/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatTabsModule } from '@angular/material/tabs';
import { ScoreTableComponent } from '../interview-id/score-table/score-table.component';
import { CateTabComponent } from '../interview-id/question-table/cate-tab/cate-tab.component';
import { QuillModule } from 'ngx-quill';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { InterviewService } from '../../../data/interview/interview.service';
import { AuthService } from '../../../core/services/auth.service';
import { PermissionService } from '../../../core/services/permission.service';
import { QuestionService } from '../../../data/question/question.service';
import { CookieService } from 'ngx-cookie-service';
import { InterviewIdComponent } from '../interview-id/interview-id.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
	selector: 'app-interview-start',
	standalone: true,
	imports: [
		CommonModule,
		MatButtonModule,
		MatCardModule,
		MatDividerModule,
		MatGridListModule,
		MatIconModule,
		MatTabsModule,
		FormsModule,
		QuillModule,

		ScoreTableComponent,
		// QuestionTransferComponent,
		CateTabComponent,
		// TitleDividerComponent,
		InterviewIdComponent,
	],
	templateUrl: './interview-start.component.html',
	styleUrl: './interview-start.component.scss'
})
export class InterviewStartComponent {
	interviewId?: string;
	allQuestion: any;
	user: any;
	role?: string;
	interviewStart: any;
	currentCateTab = 0;
	note = '';
	viewLoading = true;

	leftSoft: any;
	leftLang: any;
	leftTech: any;
	rightSoft: any;
	rightLang: any;
	rightTech: any;

	constructor(
		private router: Router,
		private route: ActivatedRoute,
		private dialog: MatDialog,
		private snackBar: MatSnackBar,
		private interviewService: InterviewService,

		private authService: AuthService,
		private permissionService: PermissionService,
		private cookieService: CookieService,

		private questionService: QuestionService
	) { }

	ngOnInit() {
		this.interviewId = this.route.snapshot.paramMap.get('interviewid')!;
		this.user = this.authService.getCurrentUser();
		this.role = this.permissionService.getRoleOfUser(this.cookieService.get('jwt'))[0];
		this.getQuestionsForStartingInterview();
	}

	ngOnDestroy() {
		// Clean up logic here
	}

	getQuestionsForStartingInterview() {
		// this.questionService.getQuestionsForStartingInterview(this.interviewId, this.user.token).subscribe(
		// 	(result) => {
		// 		this.allQuestion = result;
		// 		this.leftSoft = this.allQuestion.left[0];
		// 		this.leftLang = this.allQuestion.left[1];
		// 		this.leftTech = this.allQuestion.left[2];
		// 		this.rightSoft = this.allQuestion.right[0];
		// 		this.rightLang = this.allQuestion.right[1];
		// 		this.rightTech = this.allQuestion.right[2];
		// 		this.viewLoading = false;
		// 	},
		// 	(error) => {
		// 		console.error('Error fetching questions', error);
		// 		this.viewLoading = false;
		// 	}
		// );
	}

	preprocessing() {
		// Validation logic here
		// If all validations pass:
		this.openAlertDialog();
	}

	openAlertDialog() {
		const dialogRef = this.dialog.open(AlertDialogComponent, {
			data: { message: 'Are you sure you want to end this interview?' }
		});

		dialogRef.afterClosed().subscribe(result => {
			if (result) {
				this.handleSubmit();
			}
		});
	}

	handleSubmit() {
		// const newObj = {
		// 	interviewId: this.interviewId,
		// 	notes: this.note,
		// 	rounds: []
		// };

		// // Logic to populate newObj.rounds

		// this.interviewService.scoreInterview(newObj, this.interviewId, this.user.token).subscribe(
		// 	() => {
		// 		this.snackBar.open('Result saved successfully', 'Close', { duration: 2000 });
		// 		this.router.navigate([`/company/interview/${this.interviewId}`]);
		// 	},
		// 	(error) => {
		// 		console.error('Error saving interview result', error);
		// 		this.snackBar.open('Error saving result', 'Close', { duration: 2000 });
		// 	}
		// );
	}
}
