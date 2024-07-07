import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { ReportService } from '../../../data/report/report.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { Report } from '../../../data/report/report.model';

@Component({
	selector: 'app-report',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './report.component.html',
	styleUrl: './report.component.css'
})
export class ReportComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"reportId",
		"reportName",
		"recruiterId",
	];
	public displayColumn: string[] = [
		"Report Id",
		"Report Name",
		"Recruiter Id",
	];
	public listReports = new BehaviorSubject<Report[]>([]);

	constructor(
		public _reportService: ReportService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._reportService.getAllReports().subscribe(
			reports => {
				this.listReports.next(reports.filter(e => !e.isDeleted));
			},
			error => console.error(error)
		);
	}
}
