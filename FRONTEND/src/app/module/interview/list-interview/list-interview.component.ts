/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
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
import { InterviewFilterModel } from '../../../data/interview/interview.model';
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
}
