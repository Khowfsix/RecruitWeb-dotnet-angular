/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, MatOptionModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatFormField, MatInput, MatLabel } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggle } from '@angular/material/slide-toggle';
import { MatTooltipModule } from '@angular/material/tooltip';
import { Interview_CandidateStatus, Interview_CompanyStatus } from '../../../shared/constant/enum.model';
import { InterviewService } from '../../../data/interview/interview.service';
import { RecruiterService } from '../../../data/recruiter/recruiter.service';
import { AuthService } from '../../../core/services/auth.service';
import { Recruiter } from '../../../data/recruiter/recruiter.model';
import { Interview } from '../../../data/interview/interview.model';
import { RouterModule } from '@angular/router';
import { Subject, debounceTime, startWith } from 'rxjs';
import { CustomDateTimeService } from '../../../shared/utils/custom-datetime.service';
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
	selector: 'app-interview',
	standalone: true,
	providers: [
		{ provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
		{ provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
	],
	imports: [
		RouterModule,
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
	templateUrl: './interview.component.html',
	styleUrl: './interview.component.css'
})
export class InterviewComponent implements OnInit {

	constructor(
		private dialog: MatDialog,
		private viewContainerRef: ViewContainerRef,
		private formBuilder: FormBuilder,
		private interviewService: InterviewService,
		private recruiterService: RecruiterService,
		private customDateService: CustomDateTimeService,
		private authService: AuthService,
	) { }

	private filterSubject = new Subject<any>();
	public recruiter?: Recruiter;
	public interview_CandidateStatus: typeof Interview_CandidateStatus = Interview_CandidateStatus;
	public interview_CompanyStatus: typeof Interview_CompanyStatus = Interview_CompanyStatus;
	public fetchedInterviews?: Interview[];

	public filterForm: FormGroup = this.formBuilder.group({
		search: ['', []],
		sortString: ['MeetingDate_DESC', []],
		candidateStatus: ['', []],
		companyStatus: ['', []],
		fromTime: ['', []],
		toTime: ['', []],
		fromDate: [null, []],
		toDate: [null, []],
	});

	private fetchInterviews(companyId?: string, interviewFilterModel?: any, sortString?: string) {
		if (companyId) {
			console.log('companyId', companyId)
			console.log('interviewFilterModel', interviewFilterModel)
			console.log('sortString', sortString)
			this.interviewService.getInterviewsByCompanyId(companyId, interviewFilterModel, sortString)
				.subscribe((data) => {
					this.fetchedInterviews = data
					// console.log('this.fetchedInterviews', this.fetchedInterviews)
				});
		}
	}

	ngOnInit(): void {
		const currentUserId = this.authService.getLocalCurrentUser().id;
		if (currentUserId) {
			this.recruiterService.getRecruiterByUserId(currentUserId)
				.subscribe((recruiter) => {
					this.recruiter = recruiter;
					// console.log('recruiter', recruiter)
					this.fetchInterviews(recruiter.companyId);
				})
		}

		this.filterForm.valueChanges
			.pipe(startWith(null))
			.subscribe(() => {
				const formValue = this.filterForm.value;
				if (((formValue.fromTime !== null) === (formValue.toTime !== null)
					&& ((formValue.fromDate !== null) === (formValue.toDate !== null)))
				) {
					this.filterSubject.next(formValue);
				}
			})

		this.filterSubject.pipe(debounceTime(300)).subscribe((formValue) => {
			formValue.fromDate = this.customDateService.sameValueToUTC(formValue.fromDate, true);
			formValue.toDate = this.customDateService.sameValueToUTC(formValue.toDate, true);
			this.fetchInterviews(this.recruiter?.companyId, formValue, formValue.sortString);
		});
	}
}
