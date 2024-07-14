/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { v4 as uuid } from 'uuid';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import {
	MatPaginator,
	MatPaginatorIntl,
	MatPaginatorModule,
} from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Router, RouterModule } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from '../../../core/services/auth.service';
import { PermissionService } from '../../../core/services/permission.service';
import { Company } from '../../../data/company/company.model';
import { CompanyService } from '../../../data/company/company.service';
import {
	Interview,
	InterviewFilterModel,
} from '../../../data/interview/interview.model';
import { InterviewService } from '../../../data/interview/interview.service';
import { Interviewer } from '../../../data/interviewer/interviewer.model';
import { InterviewerService } from '../../../data/interviewer/interviewer.service';
import {
	Position,
	PositionFilterModel,
} from '../../../data/position/position.model';
import { PositionService } from '../../../data/position/position.service';
import {
	Interview_CompanyStatus,
	Interview_Type,
} from '../../../shared/enums/EInterview.model';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { GGMeetService } from '../../../shared/service/ggmeet.service';
import {
	CALENDAR_NAME,
	ID,
	TIMEZONE,
} from '../../../shared/constant/ggmeet.constant';
import { EventAddModel } from '../../../shared/service/ggmeet.model';
import moment from 'moment';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-list-interview',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,
		RouterModule,

		MatCardModule,
		MatButtonModule,
		MatButtonToggleModule,
		MatTableModule,
		MatFormFieldModule,
		MatPaginatorModule,
		MatDatepickerModule,
		MatSelectModule,
		MatIconModule,

		MatSortModule,
	],
	templateUrl: './list-interview.component.html',
})
export class ListInterviewComponent {
	displayedColumns: string[] = [
		'InterviewId',
		'CandidateName',
		'MeetingDate',
		'StartTime',
		'Location',
		'Type',
		'Status',
		'Priority',
		'actions',
	];
	dataSource?: MatTableDataSource<any>;

	positions: Position[] = [];
	companies: Company[] = [];

	// companyChoose?: Company | null;
	positionChoose?: Position | null;
	statusChoose?: Interview_CompanyStatus;
	typeChoose?: Interview_Type;
	// priorityChoose: string | null = null;

	public get getStatusValue() {
		return Interview_CompanyStatus;
	}

	public get getTypeValue() {
		return Interview_Type;
	}

	// user$: Observable<any>;
	role: string | null = null;
	interviewerId?: string;
	interviewer?: Interviewer;

	@ViewChild(MatPaginator) paginator: MatPaginator = new MatPaginator(
		this._intl,
		this._changeDetectorRef,
	);
	@ViewChild(MatSort) sort: MatSort = new MatSort();

	constructor(
		private _intl: MatPaginatorIntl,
		private _changeDetectorRef: ChangeDetectorRef,

		private interviewService: InterviewService,
		private positionService: PositionService,
		private companyService: CompanyService,
		private interviewerService: InterviewerService,

		private _cookieService: CookieService,
		private permissionService: PermissionService,
		private authService: AuthService,
		public _ggmeetService: GGMeetService,

		private _toastService: ToastrService,

		private router: Router,
	) {
		// this.user$ = this.store.select(state => state.user);
	}

	ngOnInit() {
		this.role = this.permissionService.getRoleOfUser(
			this._cookieService.get('jwt'),
		)[0];
		// if (this.role === 'Interviewer') {
		this.interviewerId = this.authService.getInterviewerId_OfUser();
		this.interviewerService
			.getInterviewerById(this.interviewerId!)
			.subscribe((interviewer) => {
				this.interviewer = interviewer;

				this.loadInitialData();
			});
		// }
		// this.companyChoose = this.interviewer?.company;
		// this.loadInitialData();
	}

	loadInitialData() {
		// if (this.role === 'Interviewer') {
		// 	this.companyChoose = this.companies.find(
		// 		(company) =>
		// 			company.companyId === this.interviewer?.companyId,
		// 	);
		// } else {
		// 	this.companyChoose = this.companies[0];
		// }

		this.loadPositions();

		this.interviewService
			.getInterviewsByCompanyId(this.interviewer!.companyId!)
			.subscribe((interviews) => {
				if (interviews) {
					this.dataSource = new MatTableDataSource(interviews);
					this.dataSource.paginator = this.paginator!;
					this.dataSource.sort = this.sort!;
				}
			});
	}

	handleChooseCompany(value: any) {
		this.positionChoose = null;
		// this.companyChoose = value;
		this.loadPositions();
		this.applyFilters();
	}

	handleChoosePosition(value: any) {
		this.positionChoose = value;
		this.applyFilters();
	}

	handleChooseStatus(value: Interview_CompanyStatus | null) {
		// if (value !== Interview_CompanyStatus.PASSED) {
		// 	this.priorityChoose = null;
		// }
		this.statusChoose = value!;
		this.applyFilters();
	}

	handleChooseType(value: Interview_Type | null) {
		this.typeChoose = value!;
		this.applyFilters();
	}

	applyFilters() {
		const filter = new InterviewFilterModel();
		if (this.positionChoose) {
			filter.positionId = this.positionChoose!.positionId;
		}
		if (this.statusChoose) {
			filter.companyStatus = this.statusChoose;
		}

		this.interviewService
			.getInterviewsByCompanyId(this.interviewer!.companyId!, filter)
			.subscribe((interviews) => {
				if (interviews) {
					if (this.role === 'Interviewer') {
						interviews = interviews.filter(
							(interview) =>
								interview.interviewerId === this.interviewerId,
						);
					}
					if (this.typeChoose) {
						interviews = interviews.filter(
							(interview) =>
								interview.interviewType === this.typeChoose,
						);
					}
					console.log(interviews);

					this.dataSource!.data = interviews.filter(
						(data) =>
							data.isDeleted === false &&
							data.interviewerId == this.interviewerId,
					);

					if (this.dataSource!.paginator && this.dataSource) {
						this.dataSource!.paginator.firstPage();
					}

					return;
				}
				this.dataSource!.data = interviews;
			});
	}

	loadPositions() {
		console.log('Loading positions...');
		const filterPosition = new PositionFilterModel();
		filterPosition.stringOfCompanyIds = this.interviewer!.companyId!;
		this.positionService
			.getAllPositions(filterPosition)
			.subscribe((resp) => {
				this.positions = resp.items;
			});
	}

	handleDetailClick(interviewId: string) {
		console.log();
		this.router.navigate(['interview/', interviewId]);
	}

	handleProfileDetailClick(userId: string) {
		window.open(`../../profile/${userId}`);
	}

	formatDate(date: string): string {
		return new Date(date).toISOString();
	}

	createGGmeet(interview: Interview) {
		console.log('interview', interview);
		if (this._ggmeetService.isLoggedIn) {
			console.log(`is loggin`);
			this._ggmeetService.getAllMyCalendars().subscribe((calendars) => {
				const res = calendars as any;
				console.log(res);
				if (res.items.length > 0) {
					const foundID = res.items.find(
						(e: { summary: string }) => e.summary === CALENDAR_NAME,
					)?.id;
					// const zone: string;
					// const summary = `Interview - ${
					// 	interview?.application?.position?.company!.companyName
					// } - ${interview?.application?.position?.positionName}`;

					if (foundID) {
						console.log(`foundID`, foundID);
						this.CallCreateEventApi(foundID, interview);
					} else {
						this._ggmeetService
							.createCalendar(CALENDAR_NAME)
							.subscribe((res: any) => {
								this.CallCreateEventApi(res?.id, interview);
							});
					}
				}
			});
		} else {
			this._ggmeetService.loginWithPopup('/list-interviews');
		}
	}

	private CallCreateEventApi(calendarId?: string, inteview?: Interview) {
		const body: EventAddModel = {
			summary:
				'Interview - ' +
				inteview?.application?.position?.company?.companyName +
				' - ' +
				inteview?.application?.position?.positionName,
			description: inteview?.notes,
			start: {
				dateTime: this.createDatetime(
					inteview?.meetingDate?.toString(),
					inteview?.startTime,
				),
				timeZone: TIMEZONE,
			},
			end: {
				dateTime: this.createDatetime(
					inteview?.meetingDate?.toString(),
					inteview?.endTime,
				),
				timeZone: TIMEZONE,
			},
			conferenceData: {
				createRequest: {
					requestId: uuid(),
					conferenceSolutionKey: {
						type: 'hangoutsMeet',
					},
					status: {
						statusCode: 'success',
					},
				},
			},
		};
		this._ggmeetService
			.createEventAndGGMeet(calendarId!, body!)
			.subscribe((res) => {
				const eventRes = res as any;
				this.interviewService
					.updateAddressInterview(
						inteview!.interviewId,
						eventRes.hangoutLink,
					)
					.subscribe({
						next: () => {
							this._toastService.success(
								'Interview updated...',
								'Successfully!',
								{
									toastClass: ' my-custom-toast ngx-toastr',
									timeOut: 3000,
								},
							);
						},
						error: () => {
							this._toastService.error(
								'Something wrong...',
								'Update interview Error!!!',
								{
									toastClass: ' my-custom-toast ngx-toastr',
									timeOut: 3000,
								},
							);
						},
					});
			});
	}

	private createDatetime(date?: string, time?: string) {
		const convertToMoment = moment(date);
		convertToMoment.second(0);
		convertToMoment.hour(Number(time!.slice(0, 2)));
		convertToMoment.minute(Number(time!.slice(3, 5)));
		return convertToMoment.format('YYYY-MM-DDTHH:mm:ss');
	}
}
