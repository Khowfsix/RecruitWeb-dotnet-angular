/* eslint-disable @typescript-eslint/no-explicit-any */
import { CommonModule } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Router, RouterModule } from '@angular/router';
import { Store } from '@ngrx/store';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from '../../../core/services/auth.service';
import { PermissionService } from '../../../core/services/permission.service';
import { Company } from '../../../data/company/company.model';
import { CompanyService } from '../../../data/company/company.service';
import { InterviewService } from '../../../data/interview/interview.service';
import { Position } from '../../../data/position/position.model';
import { PositionService } from '../../../data/position/position.service';

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
		MatIconModule
	],
	templateUrl: './list-interview.component.html',
})
export class ListInterviewComponent {
	displayedColumns: string[] = ['InterviewId', 'CandidateName', 'InterviewerName', 'StartTime', 'Location', 'Note', 'Status', 'Priority', 'actions'];
	dataSource?: MatTableDataSource<any>;

	positions: Position[] = [];
	companies: Company[] = [];

	companyChoose?: Company | null;
	positionChoose?: Position | null;
	statusChoose: string | null = null;
	priorityChoose: string | null = null;

	// user$: Observable<any>;
	role: string | null = null;

	@ViewChild(MatPaginator) paginator?: MatPaginator;

	constructor(
		private interviewService: InterviewService,
		private positionService: PositionService,
		private companyService: CompanyService,

		private _cookieService: CookieService,
		private permissionService: PermissionService,
		private authService: AuthService,

		private router: Router,
		private store: Store<any>
	) {
		// this.user$ = this.store.select(state => state.user);
	}

	ngOnInit() {
		// this.user$.subscribe(user => {
		// 	if (user) {
		this.role = this.permissionService.getRoleOfUser(this._cookieService.get('jwt'))[0];
		this.loadInitialData();
		// 	}
		// });
	}

	loadInitialData() {
		this.positionService.getAllPositions().subscribe(
			resp => this.positions = resp.items
		);

		this.companyService.getAll().subscribe(
			resp => {
				this.companies = resp;
				this.companyChoose = this.companies[0];

				this.interviewService.getInterviewsByCompanyId(this.companyChoose!.companyId!).subscribe(
					interviews => {
						this.dataSource = new MatTableDataSource(interviews);
						this.dataSource.paginator = this.paginator!;
					}
				);
			}
		)
	}

	handleChooseCompany(value: any) {
		this.positionChoose = null;
		this.companyChoose = value;
		this.applyFilters();
		this.loadPositions();
	}

	handleChoosePosition(value: any) {
		this.positionChoose = value;
		this.applyFilters();
	}

	handleChooseStatus(value: string | null) {
		if (value !== 'Finished') {
			this.priorityChoose = null;
		}
		this.statusChoose = value;
		this.applyFilters();
	}

	handleChooseResult(value: string | null) {
		this.priorityChoose = value;
		this.applyFilters();
	}

	applyFilters() {
		// this.user$.subscribe(user => {
		// 	this.interviewService.getInterviewWithFilter(
		// 		this.role,
		// 		user.interviewerId,
		// 		this.departmentChoose?.departmentId,
		// 		this.positionChoose?.PositionId,
		// 		this.statusChoose,
		// 		this.priorityChoose,
		// 		user.token
		// 	).subscribe(
		// 		interviews => {
		// 			this.dataSource.data = interviews;
		// 		}
		// 	);
		// });
	}

	loadPositions() {
		// this.user$.subscribe(user => {
		// 	this.positionService.getPositionListWithFilter(
		// 		this.departmentChoose?.departmentId,
		// 		null,
		// 		user.token
		// 	).subscribe(
		// 		positions => this.positions = positions
		// 	);
		// });
	}

	handleDetailClick(interviewId: string) {
		this.router.navigate(['./', interviewId]);
	}

	handleProfileDetailClick(userId: string) {
		window.open(`../../profile/${userId}`);
	}

	formatDate(date: string): string {
		return new Date(date).toISOString();
	}
}
