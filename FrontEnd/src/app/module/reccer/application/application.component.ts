/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject, OnInit, ViewContainerRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Application } from '../../../data/application/application.model';
import { ApplicationService } from '../../../data/application/application.service';
import { AsyncPipe, DatePipe } from '@angular/common';
import { CommonModule } from '@angular/common';
import { CandidateService } from '../../../data/candidate/candidate.service';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInput } from '@angular/material/input';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Subject, debounceTime, forkJoin, startWith } from 'rxjs';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { BlackListService } from '../../../data/blacklist/blacklist.service';
import { BlackList } from '../../../data/blacklist/blacklist.model';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatButtonModule } from '@angular/material/button';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, MatRippleModule } from '@angular/material/core';
import { MatMenuModule } from '@angular/material/menu';
import { Candidate } from '../../../data/candidate/candidate.model';
import { Skill } from '../../../data/skill/skill.model';
import { ApplicationHistoryService } from '../../../data/applicationHistory/applicationHistory.service';
import { MAT_DIALOG_DATA, MatDialog, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { ApplicationHistoryComponent } from './application-history/application-history.component';
import { CandidateJoinEventService } from '../../../data/candidateJoinEvent/candidate-join-event.service';
import { Application_CandidateStatus, Application_CompanyStatus } from '../../../shared/constant/enum.model';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { ToastrService } from 'ngx-toastr';
import { CustomDateTimeService } from '../../../shared/utils/custom-datetime.service';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { MatDatepickerModule } from '@angular/material/datepicker';
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
	selector: 'app-application',
	standalone: true,
	providers: [
		{ provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
		{ provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
	],
	imports: [
		MatDatepickerModule,
		MatButtonToggleModule,
		AsyncPipe,
		MatMenuModule,
		MatRippleModule,
		MatIconModule,
		MatButtonModule,
		MatSlideToggleModule,
		MatTooltipModule,
		MatIcon,
		MatCheckboxModule,
		ReactiveFormsModule,
		MatInput,
		MatSelectModule,
		MatLabel,
		MatFormField,
		DatePipe,
		CommonModule,
	],
	templateUrl: './application.component.html',
	styleUrl: './application.component.css'
})
export class ApplicationComponent implements OnInit {
	constructor(
		private route: ActivatedRoute,
		private formBuilder: FormBuilder,
		private dialog: MatDialog,
		private viewContainerRef: ViewContainerRef,
		private candidateJoinEventService: CandidateJoinEventService,
		private applicationService: ApplicationService,
		private candidateService: CandidateService,
		private blackListService: BlackListService,
		private customDateService: CustomDateTimeService,
		private applicationHistoryServivce: ApplicationHistoryService,
	) { }

	public application_CandidateStatus: typeof Application_CandidateStatus = Application_CandidateStatus;
	public application_CompanyStatus: typeof Application_CompanyStatus = Application_CompanyStatus;
	public paramPositionId!: string;
	public fetchedApplications?: Application[];
	public fetchedBlackLists?: BlackList[];
	public fetchedCandidates?: Candidate[];
	public fetchedSkills?: Skill[];
	public sortString?: string;

	public filterForm: FormGroup = this.formBuilder.group({
		sortString: ['CreatedTime_DESC', []],
		// candidateStatus: ['', []],
		companyStatus: ['', []],
		search: ['', []],
		notInBlackList: [false, []],
		fromDate: [
			null,
			[]
		],
		toDate: [
			null,
			[]
		],
	});

	public openViewApplicationHistoryDialog(candidateId: string | undefined, enterAnimationDuration: string,
		exitAnimationDuration: string) {
		if (candidateId) {
			const applicationHistory$ = this.applicationHistoryServivce.getByCandidateId(candidateId);
			const candidateJoinEvent$ = this.candidateJoinEventService.getAllByCandidateId(candidateId);

			forkJoin([applicationHistory$, candidateJoinEvent$]).subscribe(([applicationHistoryData, candidateJoinEventData]) => {
				// console.log("openViewApplicationHistoryDialog - Application History", applicationHistoryData);
				// console.log("openViewApplicationHistoryDialog - Candidate Join Event", candidateJoinEventData);

				this.dialog.open(ApplicationHistoryComponent, {
					viewContainerRef: this.viewContainerRef,
					data: {
						applicationHistoryData: applicationHistoryData,
						candidateJoinEventData: candidateJoinEventData,
					},
					width: '600px',
					height: '600px',
					enterAnimationDuration,
					exitAnimationDuration,
				});
			});
		}
	}

	public isInBlackList(candidateId: string | undefined) {
		return this.fetchedBlackLists?.some(x => x.candidateId === candidateId);
	}

	public handleSortSelect(event: Event) {
		const selectedOption = event.target as HTMLSelectElement;
		const value = selectedOption.value;

		this.sortString = value;
		// this.fetchedAllPositions(this.formatFilterModel(this.filterForm.value));
	}

	private getAllBlackList() {
		this.blackListService.getAll().subscribe((data) => {
			this.fetchedBlackLists = data;
		});
	}

	public openConfirmDialog(
		enterAnimationDuration: string,
		exitAnimationDuration: string,
		application_CompanyStatus: number,
		applicationId?: string,
	): void {
		if (applicationId) {
			const dialogRef = this.dialog.open(DeleteDialog, {
				viewContainerRef: this.viewContainerRef,
				data: {
					applicationId: applicationId,
					application_CompanyStatus: application_CompanyStatus,
				},
				width: '350px',
				enterAnimationDuration,
				exitAnimationDuration,
			});

			dialogRef.afterClosed().subscribe(() => {
				this.getAllApplicationsByPositionId(this.paramPositionId, this.filterForm.value);
			});
		}
	}

	private getAllApplicationsByPositionId(positionId: string, formValue?: any) {
		// console.log('formValue', formValue)
		this.applicationService.getAllByPositionId(positionId, formValue ? formValue.search : '',
			formValue ? formValue.sortString : '',
			formValue ? formValue.notInBlackList : '',
			formValue ? formValue.candidateStatus : '',
			formValue ? formValue.companyStatus : '',
			formValue ? formValue.fromDate : '',
			formValue ? formValue.toDate : '',
		).subscribe((data) => {
			this.fetchedApplications = data;
			this.fetchedApplications.forEach(application => {
				if (application.cv?.candidateId) {
					this.candidateService.getById(application.cv?.candidateId).subscribe(candidate => {
						if (application.cv)
							application.cv.candidate = candidate;
					});
				}
			});
		});

		// console.log('fetchedCandidates', this.fetchedCandidates)
		// console.log('fetchedApplications', this.fetchedApplications)
	}

	private filterSubject = new Subject<any>();

	public ngOnInit(): void {
		this.paramPositionId = this.route.snapshot.paramMap.get('positionId') ?? '';
		this.getAllApplicationsByPositionId(this.paramPositionId);
		this.getAllBlackList();

		this.filterForm.valueChanges
			.pipe(startWith(null))
			.subscribe(() => {
				const formValue = this.filterForm.value;
				if ((formValue.fromDate !== null) === (formValue.toDate !== null)) {
					this.filterSubject.next(formValue);
				}
			})

		this.filterSubject.pipe(debounceTime(300)).subscribe((formValue) => {
			formValue.fromDate = this.customDateService.sameValueToUTC(formValue.fromDate, true);
			formValue.toDate = this.customDateService.sameValueToUTC(formValue.toDate, true);
			this.getAllApplicationsByPositionId(this.paramPositionId, formValue);
		});
	}
}


@Component({
	selector: 'delete-dialog',
	template: `
		<div class="p-2">
			<h2 mat-dialog-title>Confirmation</h2>
			<mat-dialog-content style="font-weight: 600;">
				Are you sure?
			</mat-dialog-content>
			<mat-dialog-actions class="justify-content-center">
				<button
					mat-button
					mat-dialog-close
					class="mx-4"
					style="background-color: red; color: white; width: 25%; font-size: 16px;">
					Cancel
				</button>
				<button
					class="mx-4"
					(click)="submit()"
					mat-button
					cdkFocusInitial
					style="background-color: green; color: white; width: 25%; font-size: 16px;">
					Ok
				</button>
			</mat-dialog-actions>
		</div>
	`,
	standalone: true,
	imports: [
		MatButtonModule,
		MatDialogActions,
		MatDialogClose,
		MatDialogTitle,
		MatDialogContent,
	],
})
export class DeleteDialog {
	constructor(
		@Inject(MAT_DIALOG_DATA) public data: any,
		public dialogRef: MatDialogRef<DeleteDialog>,
		private applicationService: ApplicationService,
		private toastr: ToastrService,
	) { }


	public submit() {
		if (this.data.applicationId && this.data.application_CompanyStatus)
			this.applicationService.updateStatusApplication(this.data.applicationId, this.data.application_CompanyStatus).subscribe((data) => {
				if (data === true) {
					this.toastr.success("Status Updated!");
				}
				else {
					this.toastr.error("Update status failed!");
				}
				this.dialogRef.close();
			});
	}
}
