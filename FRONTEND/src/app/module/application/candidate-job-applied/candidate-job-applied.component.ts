import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Application } from '../../../data/application/application.model';
import { MatSort } from '@angular/material/sort';
import { ApplicationService } from '../../../data/application/application.service';
import { AuthService } from '../../../core/services/auth.service';
import { MatInputModule } from '@angular/material/input';

@Component({
	selector: 'app-candidate-job-applied',
	standalone: true,
	imports: [
		CommonModule,

		MatFormFieldModule,
		MatTableModule,
		MatChipsModule,
		MatIconModule,
		MatPaginatorModule,
		MatChipsModule,
		MatInputModule
	],
	templateUrl: './candidate-job-applied.component.html',
})
export class CandidateJobAppliedComponent implements OnInit {
	displayedColumns: string[] = ['position', 'company', 'appliedDate', 'status', 'actions'];
	dataSource?: MatTableDataSource<Application>;
	candidateId?: string;
	jobs: Application[] = [];

	@ViewChild(MatPaginator) paginator?: MatPaginator;
	@ViewChild(MatSort) sort?: MatSort;

	constructor(
		private _applicationService: ApplicationService,
		private _authService: AuthService
	) {
		this.candidateId = _authService.getCandidateId_OfUser();
		this._applicationService.getApplicationsOfCandidate(this.candidateId!).subscribe((data) => {
			this.jobs = data;
			this.dataSource = new MatTableDataSource(this.jobs);
		})
	}

	ngOnInit() {
	}

	ngAfterViewInit() {
		this.dataSource!.paginator = this.paginator!;
		this.dataSource!.sort = this.sort!;
	}

	applyFilter(event: Event) {
		const filterValue = (event.target as HTMLInputElement).value;
		this.dataSource!.filter = filterValue.trim().toLowerCase();

		if (this.dataSource!.paginator) {
			this.dataSource!.paginator.firstPage();
		}
	}
}
