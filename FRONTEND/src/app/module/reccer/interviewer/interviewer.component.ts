/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { InterviewerService } from '../../../data/interviewer/interviewer.service';
import { RecruiterService } from '../../../data/recruiter/recruiter.service';
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
import { CustomDateTimeService } from '../../../shared/utils/custom-datetime.service';
import { MatDialog } from '@angular/material/dialog';
import { InterviewHistoryComponent } from './interview-history/interview-history.component';
import { InterviewService } from '../../../data/interview/interview.service';
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
		private dialog: MatDialog,
		private viewContainerRef: ViewContainerRef,
		private formBuilder: FormBuilder,
		private customDateService: CustomDateTimeService,
		private interviewerService: InterviewerService,
		private interviewService: InterviewService,
		private authService: AuthService,
		private recruiterService: RecruiterService,
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

	public recruiter?: Recruiter;
	public fetchedInterviewers?: Interviewer[];
	private filterSubject = new Subject<any>();

	private fetchInterviewers(companyId: string | undefined, interviewFilterModel?: any) {
		if (companyId) {
			this.interviewerService.getAll(companyId, interviewFilterModel, interviewFilterModel ? interviewFilterModel.sortString : undefined)
				.subscribe((data) => {
					this.fetchedInterviewers = data
					console.log('this.fetchedInterviewers', this.fetchedInterviewers)
				});
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
		const currentUserId = this.authService.getLocalCurrentUser().id;
		// console.log('authService', this.authService.getLocalCurrentUser().id)
		if (currentUserId) {
			this.recruiterService.getRecruiterByUserId(currentUserId)
				.subscribe((recruiter) => {
					this.recruiter = recruiter;
					console.log('recruiter', recruiter)
					this.fetchInterviewers(recruiter.companyId);
				})
		}


		this.filterForm.valueChanges
			.pipe(startWith(null))
			.subscribe(() => {
				const formValue = this.filterForm.value;
				this.filterSubject.next(formValue);
			})

		this.filterSubject.pipe(debounceTime(300)).subscribe((formValue) => {
			// console.log('filterForm value: ', (formValue));
			// console.log('filterForm value: ', this.formatFilterModel(formValue));
			// console.log('this.recruiter?.recruiterId: ', this.recruiter?.recruiterId);
			formValue.fromDate = this.customDateService.sameValueToUTC(formValue.fromDate, true);
			formValue.toDate = this.customDateService.sameValueToUTC(formValue.toDate, true);
			this.fetchInterviewers(this.recruiter?.recruiterId, formValue);
		});

	}
}
