/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable prefer-const */
import { AfterViewInit, Component, ViewContainerRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject, Observable } from 'rxjs';
import { ReportService } from '../../../data/report/report.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { ApplicationReport, InterviewReport, Report } from '../../../data/report/report.model';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, MatOptionModule } from '@angular/material/core';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { MY_DAY_FORMATS } from '../../../core/constants/app.env';
import { Report_ReportType } from '../../../shared/enums/EReport.model';
import { MatSelectModule } from '@angular/material/select';
import { CustomDateTimeService } from '../../../shared/service/custom-datetime.service';
import { MatButtonModule } from '@angular/material/button';
import { ExportService } from '../../../data/export/export.service';
import { MatDialog } from '@angular/material/dialog';
import { AddFormComponent } from './add-form/add-form.component';
import { AuthService } from '../../../core/services/auth.service';

@Component({
	selector: 'app-report',
	standalone: true,
	providers: [
		{ provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
		{ provide: MAT_DATE_FORMATS, useValue: MY_DAY_FORMATS },
	],
	imports: [
		MatButtonModule,
		MatSelectModule,
		MatOptionModule,
		MatIconModule,
		MatFormFieldModule,
		MatDatepickerModule,
		ReactiveFormsModule,
		GenericTableComponent,
	],
	templateUrl: './report.component.html',
	styleUrl: './report.component.css'
})
export class ReportComponent implements AfterViewInit {
	constructor(
		private viewContainerRef: ViewContainerRef,
		private dialog: MatDialog,

		public _toastService: ToastrService,
		private _formBuilder: FormBuilder,

		private _authService: AuthService,
		public _exportService: ExportService,
		public _reportService: ReportService,
		private _customDateService: CustomDateTimeService,
	) {
		this.refreshData();
		this.showApplicationReport();
	}
	public reportType: typeof Report_ReportType = Report_ReportType;

	public formGroup: FormGroup = this._formBuilder.group({
		reportType: [this.reportType.APPLICATION, [Validators.required]],
		fromDate: [null, []],
		toDate: [null, []],
	});

	public edit = (row: Report): void => {
		const editFormDialog = this.dialog.open(AddFormComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				foundReport: row,
				isEditForm: true,
			},
			width: '500px',
			height: '500px',
			enterAnimationDuration: '100ms',
			exitAnimationDuration: '0ms',
		});

		editFormDialog.afterClosed().subscribe(() => {
			this.refreshData();
		});
	}

	ngAfterViewInit(): void {
		this.formGroup.valueChanges.subscribe((value) => {
			switch (value.reportType) {
				case this.reportType.APPLICATION: {
					this.showApplicationReport();
					break;
				}
				case this.reportType.INTERVIEW: {
					this.showInterviewReport();
					break;
				}
				default: {
					this.viewReportListProps = [];
					this.viewReportDisplayedColumns = [];
					break;
				}
			}

		})
	}

	public viewReportActions: ActionType[] = ["read"];
	public viewReportListProps: string[] = [];
	public viewReportDisplayedColumns: string[] = [];
	public viewReportDetailDisplayedColumns: string[] = [];
	public viewReportDetailListProps: string[] = [];
	public viewReportDataInput = new BehaviorSubject<InterviewReport[] | ApplicationReport[]>([]);

	private openAddFormDialog(exportFile: File) {
		const addFormDialog = this.dialog.open(AddFormComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				reportType: this.formGroup.value.reportType,
				exportFile: exportFile,
			},
			width: '500px',
			height: '500px',
			enterAnimationDuration: '100ms',
			exitAnimationDuration: '0ms',
		});

		addFormDialog.afterClosed().subscribe(() => {
			this.refreshData();
		});
	}

	public saveReport() {
		let formValue = this.formGroup.value;
		formValue.fromDate = this._customDateService.sameValueToUTC(formValue.fromDate, true);
		formValue.toDate = this._customDateService.sameValueToUTC(formValue.toDate, true);
		switch (formValue.reportType) {
			case this.reportType.APPLICATION: {
				this._exportService.ExportApplicationReport(formValue.fromDate, formValue.toDate).subscribe(resp => {
					this.openAddFormDialog(resp.body);
				})
				break;
			}
			case this.reportType.INTERVIEW: {
				this._exportService.ExportInterviewReport(formValue.fromDate, formValue.toDate).subscribe(resp => {
					this.openAddFormDialog(resp.body);
				})
				break;
			}
			default: {
				break;
			}
		}
	}

	private callApiSaveFile(api: Observable<any>) {
		api.subscribe((response: any) => {
			const url = window.URL.createObjectURL(response.body);

			const contentDisposition = response.headers.get('Content-Disposition');
			let fileName = 'exported-file.xlsx';
			if (contentDisposition) {
				const matches = /filename="([^"]*)"/.exec(contentDisposition);
				if (matches != null && matches[1]) {
					fileName = matches[1];
				}
			}

			const a = document.createElement('a');
			a.href = url;
			a.download = fileName;

			document.body.appendChild(a);
			a.click();

			document.body.removeChild(a);

			window.URL.revokeObjectURL(url);
		});
	}

	public exportReport() {
		let formValue = this.formGroup.value;
		formValue.fromDate = this._customDateService.sameValueToUTC(formValue.fromDate, true);
		formValue.toDate = this._customDateService.sameValueToUTC(formValue.toDate, true);
		switch (formValue.reportType) {
			case this.reportType.APPLICATION: {
				this.callApiSaveFile(this._exportService.ExportApplicationReport(formValue.fromDate, formValue.toDate));
				break;
			}
			case this.reportType.INTERVIEW: {
				this.callApiSaveFile(this._exportService.ExportInterviewReport(formValue.fromDate, formValue.toDate));

				break;
			}
			default: {
				break;
			}
		}

	}

	private showInterviewReport() {
		this.viewReportListProps = [
			"candidateName",
			"interviewerName",
			"applyDate",
			"interviewDate",
			"status",
		]
		this.viewReportDisplayedColumns = [
			"Candidate Name",
			"Interviewer Name",
			"Apply Date",
			"Interview Date",
			"Status",
		]
		this.viewReportDetailListProps = [
			"interviewId",
			"candidateId",
			"interviewerId",
			"score",
		];
		this.viewReportDetailDisplayedColumns = [
			"Interview Id",
			"Candidate Id",
			"Interviewer Id",
			"Score",
		];


		let formValue = this.formGroup.value;
		formValue.fromDate = this._customDateService.sameValueToUTC(formValue.fromDate, true);
		formValue.toDate = this._customDateService.sameValueToUTC(formValue.toDate, true);
		this._reportService.InterviewReport(formValue.fromDate, formValue.toDate).subscribe(
			reports => {
				this.viewReportDataInput.next(reports);
			},
			error => console.error(error)
		);
	}

	private showApplicationReport() {
		this.viewReportListProps = [
			"applicationId",
			"fullName",
			"cvName",
			"education",
			"positionName",
			"companyName",
		]
		this.viewReportDisplayedColumns = [
			"Application Id",
			"Full Name",
			"Cv Name",
			"Education",
			"Position Name",
			"Company Name",
		]
		this.viewReportDetailListProps = [
			"experience",
			"dateOfBirth",
			"address",
			"introduction",
			"description",
			"salary",
			"createdTime",
			"candidate_Status",
			"company_Status",
			"languageName",
			"priority",
		];
		this.viewReportDetailDisplayedColumns = [
			"Experience",
			"Date Of Birth",
			"Address",
			"Introduction",
			"Description",
			"Salary",
			"Created Time",
			"Candidate Status",
			"Company Status",
			"Language Name",
			"Priority",
		];


		let formValue = this.formGroup.value;
		formValue.fromDate = this._customDateService.sameValueToUTC(formValue.fromDate, true);
		formValue.toDate = this._customDateService.sameValueToUTC(formValue.toDate, true);

		this._reportService.ApplicationReport(formValue.fromDate, formValue.toDate).subscribe(
			reports => {
				this.viewReportDataInput.next(reports.filter(e => !e.isDeleted));
			},
			error => console.error(error)
		);
	}

	public actions: ActionType[] = ["read", "update", "delete"];
	public listProps: string[] = [
		"reportId",
		"reportName",
		"userId",
		"reportType",
	];
	public displayColumn: string[] = [
		"Report Id",
		"Report Name",
		"User Id",
		"Report Type",
	];
	public detailListProps: string[] = [
		'fileURL'
	];
	public detailDisplayedColumns: string[] = [
		'File URL'
	];
	public listReports = new BehaviorSubject<Report[]>([]);

	refreshData() {
		this._reportService.getAllReports().subscribe(
			reports => {
				this.listReports.next(reports.filter(e => !e.isDeleted));
			},
			error => console.error(error)
		);
	}

	delete = (report: Report): void => {
		if (report.userId !== this._authService.getLocalCurrentUser().id) {
			this._toastService.error("Delete failed - not your report", "Delete report failed", {
				timeOut: 3000,
				positionClass: 'toast-top-center',
				toastClass: ' my-custom-toast ngx-toastr',
				progressBar: true
			});
			return;
		}

		this._reportService.deleteReport(report.reportId).subscribe(
			(response) => {
				console.log(response);
				this.refreshData();

				this._toastService.success("Delete success", "Delete report success", {
					timeOut: 3000,
					positionClass: 'toast-top-center',
					toastClass: ' my-custom-toast ngx-toastr',
					progressBar: true
				});
			}
		)
	}
}
