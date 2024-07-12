/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTabsModule } from '@angular/material/tabs';
import { ActivatedRoute, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { QuillModule } from 'ngx-quill';
import { AuthService } from '../../../core/services/auth.service';
import { PermissionService } from '../../../core/services/permission.service';
import { InterviewService } from '../../../data/interview/interview.service';
import { QuestionService } from '../../../data/question/question.service';
import { AlertDialogService } from '../../../shared/component/alert-dialog/alert-dialog.component';
import { InterviewIdComponent } from '../interview-id/interview-id.component';
import { CateTabComponent } from '../interview-id/question-table/cate-tab/cate-tab.component';
import { ScoreTableComponent } from '../interview-id/score-table/score-table.component';
import { QuestionTransferComponent } from './question-transfer/question-transfer.component';
import { TitleDividerComponent } from '../../../shared/component/title-divider/title-divider.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { TwoTableComponent } from '../../../shared/components/two-table/two-table.component';

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
		QuestionTransferComponent,
		CateTabComponent,
		TitleDividerComponent,
		InterviewIdComponent,
		MatFormFieldModule,

		TwoTableComponent,
	],
	templateUrl: './interview-start.component.html',
	styleUrl: './interview-start.component.scss',
})
export class InterviewStartComponent {
	interviewId?: string;
	allQuestion: any = [];

	user: any;
	role?: string;
	interviewStart: any;
	currentCateTab = 0;
	notes = '';
	viewLoading = true;

	//left questions
	leftSoft: any;
	leftLang: any;
	leftTech: any;
	//right questions
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
		private dialogService: AlertDialogService,

		private questionService: QuestionService,
	) {}

	ngOnInit() {
		this.interviewId = this.route.snapshot.paramMap.get('interviewId')!;
		this.user = this.authService.getLocalCurrentUser();

		const roleFromJWT = this.permissionService.getRoleOfUser(
			this.cookieService.get('jwt'),
		);
		if (typeof roleFromJWT === 'string') {
			this.role = roleFromJWT;
		} else {
			this.role = roleFromJWT[0];
		}

		this.getQuestionsForStartingInterview();
	}

	ngOnDestroy() {
		// Clean up logic here
	}

	getQuestionsForStartingInterview() {
		this.questionService
			.getQuestionsForStartingInterview(this.interviewId!)
			.subscribe(
				(result) => {
					console.log(result);
					this.allQuestion = result;
					// this.leftSoft = this.allQuestion.left[0];
					// this.leftLang = this.allQuestion.left[1];
					// this.leftTech = this.allQuestion.left[2];
					// this.rightSoft = this.allQuestion.right[0];
					// this.rightLang = this.allQuestion.right[1];
					// this.rightTech = this.allQuestion.right[2];

					this.leftSoft = this.allQuestion.interviewQuestions[0];
					this.leftLang = this.allQuestion.interviewQuestions[1];
					this.leftTech = this.allQuestion.interviewQuestions[2];
					this.rightSoft = [];
					this.rightLang = [];
					this.rightTech = [];
				},
				// (error: any) => {
				// 	console.error('Error fetching questions', error);
				// 	this.viewLoading = false;
				// },
			);
	}

	preprocessing() {
		// Validation logic here
		// If all validations pass:
		this.openAlertDialog();
	}

	openAlertDialog() {
		this.dialogService
			.openDialog('Are you sure you want to end this interview?')
			.subscribe((result) => {
				if (result) {
					this.handleSubmit();
				}
			});
	}

	handleSubmit() {
		const newObj = {
			interviewId: this.interviewId,
			notes: this.notes,
			rounds: [],
		};

		// Logic to populate newObj.rounds

		this.interviewService
			.scoreInterview(this.interviewId!, newObj)
			.subscribe(
				() => {
					this.snackBar.open('Result saved successfully', 'Close', {
						duration: 2000,
					});
					this.router.navigate([`/interview/${this.interviewId}`]);
				},
				(error: any) => {
					console.error('Error saving interview result', error);
					this.snackBar.open('Error saving result', 'Close', {
						duration: 2000,
					});
				},
			);
	}
}
