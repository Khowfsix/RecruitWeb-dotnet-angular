/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { InterviewerService } from '../../../data/interviewer/interviewer.service';
import { AuthService } from '../../../core/services/auth.service';
import { Interviewer } from '../../../data/interviewer/interviewer.model';
import { Recruiter } from '../../../data/recruiter/recruiter.model';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, MatOptionModule } from '@angular/material/core';
import { MatInput } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSlideToggle } from '@angular/material/slide-toggle';
import { Subject, debounceTime, startWith } from 'rxjs';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MomentDateAdapter, } from '@angular/material-moment-adapter';
import { CustomDateTimeService } from '../../../shared/service/custom-datetime.service';
import { MatDialog } from '@angular/material/dialog';
import { InterviewHistoryComponent } from './interview-history/interview-history.component';
import { InterviewService } from '../../../data/interview/interview.service';
import { AddFormComponent as InterviewerAddFormComponent } from '../interviewer/add-form/add-form.component';
import { AddFormComponent as InterviewAddFormComponent } from '../interview/add-form/add-form.component';

import { GGMeetService } from '../../../shared/service/ggmeet.service';
import { DeleteDialogComponent } from '../../../shared/component/dialog/delete-dialog/delete-dialog.component';
export const MY_FORMATS = {
	parse: {
		dateInput: 'DD/MM/YYYY',
	},
	display: {
		dateInput: 'DD/MM/YYYY',
		monthYearLabel: 'YYYY',
		dateA11yLabel: 'LL',
		monthYearA11yLabel: 'YYYY',
	},
};
@Component({
	selector: 'app-interviewer',
	standalone: true,
	providers: [
		{ provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
		{ provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
	],
	imports: [
		MatDatepickerModule,
		MatSlideToggle,
		MatCheckboxModule,
		MatSelectModule,
		MatInput,
		MatOptionModule,
		MatLabel,
		MatFormField,
		ReactiveFormsModule,
		MatTooltipModule,
		MatButtonModule,
		MatIconModule,
		CommonModule,
	],
	templateUrl: './interviewer.component.html',
	styleUrl: './interviewer.component.css'
})
export class InterviewerComponent implements OnInit {
	constructor(
		private ggmeetService: GGMeetService,
		private dialog: MatDialog,
		private viewContainerRef: ViewContainerRef,
		private formBuilder: FormBuilder,
		private customDateService: CustomDateTimeService,
		private interviewerService: InterviewerService,
		private interviewService: InterviewService,
		private authService: AuthService,
	) { }

	public filterForm: FormGroup = this.formBuilder.group({
		search: ['', []],
		sortString: ['FullName_ASC', []],
		isFreeTime: [false, []],
		isBusyTime: [false, []],
		fromTime: ['', []],
		toTime: ['', []],
		fromDate: [null, []],
		toDate: [null, []],
	});

	public recruiter?: Recruiter = this.authService.getLocalCurrentUser().recruiters?.pop();
	public fetchedInterviewers?: Interviewer[];
	private filterSubject = new Subject<any>();

	public openDeleteFormDialog(interviewer: Interviewer, enterAnimationDuration: string,
		exitAnimationDuration: string) {
		const editFormDialog = this.dialog.open(DeleteDialogComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				objectLabel: 'Interviewer',
				objectName: interviewer.user?.fullName,
				deleteApiServiceObservable: this.interviewerService.delete(interviewer.interviewerId ?? '')
			},
			width: '400px',
			height: '230px',
			enterAnimationDuration,
			exitAnimationDuration,
		});

		editFormDialog.afterClosed().subscribe(() => {
			const formValue = this.filterForm.value;
			formValue.fromDate = this.customDateService.sameValueToUTC(formValue.fromDate, true);
			formValue.toDate = this.customDateService.sameValueToUTC(formValue.toDate, true);
			this.fetchInterviewers(this.recruiter?.companyId, formValue);
		})
	}

	public openAddForm = (): void => {
		const addFormDialog = this.dialog.open(InterviewerAddFormComponent, {
			width: '500px',
			height: '350px',
			viewContainerRef: this.viewContainerRef,
			data: {
				companyId: this.recruiter?.companyId,
			},
			enterAnimationDuration: '100ms',
			exitAnimationDuration: '0ms',
		});

		addFormDialog.afterClosed().subscribe(() => {
			const formValue = this.filterForm.value;
			formValue.fromDate = this.customDateService.sameValueToUTC(formValue.fromDate, true);
			formValue.toDate = this.customDateService.sameValueToUTC(formValue.toDate, true);
			this.fetchInterviewers(this.recruiter?.companyId, formValue);
		})
	}

	private fetchInterviewers(companyId: string | undefined, interviewFilterModel?: any) {
		if (companyId) {
			this.interviewerService.getAll(companyId, interviewFilterModel, interviewFilterModel ? interviewFilterModel.sortString : undefined)
				.subscribe((data) => {
					this.fetchedInterviewers = data
					console.log('this.fetchedInterviewers', this.fetchedInterviewers)
				});
		}
	}

	public openAddInterviewDialog(
		interviewerId: string | undefined,
		enterAnimationDuration: string,
		exitAnimationDuration: string,
	): void {
		if (interviewerId) {
			const dialogRef = this.dialog.open(InterviewAddFormComponent, {
				viewContainerRef: this.viewContainerRef,
				data: {
					recruiter: this.recruiter,
					interviewerId: interviewerId,
				},
				width: '1000px',
				height: '500px',
				enterAnimationDuration,
				exitAnimationDuration,
			});
			dialogRef.afterClosed().subscribe(() => {
				const formValue = this.filterForm.value;
				formValue.fromDate = this.customDateService.sameValueToUTC(formValue.fromDate, true);
				formValue.toDate = this.customDateService.sameValueToUTC(formValue.toDate, true);
				this.fetchInterviewers(this.recruiter?.companyId, formValue);
			})
		}

	}


	public openInterviewsHistoryDialog(
		interviewerId: string | undefined,
		enterAnimationDuration: string,
		exitAnimationDuration: string,
	): void {
		if (interviewerId) {
			this.interviewService.getAllByInterviewerId(interviewerId).subscribe((data) => {
				this.dialog.open(InterviewHistoryComponent, {
					viewContainerRef: this.viewContainerRef,
					data: {
						interviewsData: data,
					},
					width: '700px',
					height: '600px',
					enterAnimationDuration,
					exitAnimationDuration,
				});
			});
		}

	}

	ngOnInit(): void {
		// console.log('authService', this.authService.getLocalCurrentUser().id)
		if (this.recruiter) {
			this.fetchInterviewers(this.recruiter.companyId);
		}


		this.filterForm.valueChanges
			.pipe(startWith(null))
			.subscribe(() => {
				const formValue = this.filterForm.value;
				if (((formValue.fromTime !== null) === (formValue.toTime !== null)
					&& ((formValue.fromDate !== null) === (formValue.toDate !== null)))
				)
					this.filterSubject.next(formValue);
			})

		this.filterSubject.pipe(debounceTime(300)).subscribe((formValue) => {
			formValue.fromDate = this.customDateService.sameValueToUTC(formValue.fromDate, true);
			formValue.toDate = this.customDateService.sameValueToUTC(formValue.toDate, true);
			this.fetchInterviewers(this.recruiter?.companyId, formValue);
		});
	}
}
