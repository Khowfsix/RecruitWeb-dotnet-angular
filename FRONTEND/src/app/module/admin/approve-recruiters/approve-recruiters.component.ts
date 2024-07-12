import { Component } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Recruiter } from '../../../data/recruiter/recruiter.model';
import { RecruiterService } from '../../../data/recruiter/recruiter.service';
import { ToastrService } from 'ngx-toastr';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { Company } from '../../../data/company/company.model';
import { CompanyService } from '../../../data/company/company.service';

@Component({
	selector: 'app-approve-recruiters',
	standalone: true,
	imports: [
		GenericTableComponent
	],
	templateUrl: './approve-recruiters.component.html',
	styleUrl: './approve-recruiters.component.css'
})
export class ApproveRecruitersComponent {

	public listCompanies = new BehaviorSubject<Company[]>([]);
	public actionsCompanies: ActionType[] = ['read', 'accept', 'deny'];
	public listPropsCompanies: string[] = [
		"companyId",
		"companyName",
		"address",
		"email",
		"phone",
		"website",
	];
	public displayColumnCompanies: string[] = [
		"ID",
		"Name",
		"Address",
		"Email",
		"Phone",
		"Website",
	];
	public detailListPropsCompanies: string[] = [
		"logo",
	];
	public detailDisplayColumnCompanies: string[] = [
		"Logo",
	];

	public acceptDataCompany = (company: Company) => {
		this._companyService.UpdateStatus(company.companyId, true, false).subscribe(
			(response) => {
				if (response === true) {
					console.log(response);
					this.refreshDataCompanies();

					this._toastService.success("Accepted", "Accepted", {
						timeOut: 3000,
						positionClass: 'toast-top-center',
						toastClass: ' my-custom-toast ngx-toastr',
						progressBar: true
					});
				}
				else {
					this._toastService.error("Error", "Error", {
						timeOut: 3000,
						positionClass: 'toast-top-center',
						toastClass: ' my-custom-toast ngx-toastr',
						progressBar: true
					});
				}
			}
		)
	}
	public denyDataCompany = (company: Company) => {
		this._companyService.UpdateStatus(company.companyId, false, true).subscribe(
			(response) => {
				if (response === true) {
					console.log(response);
					this.refreshDataCompanies();

					this._toastService.success("Deny", "Deny", {
						timeOut: 3000,
						positionClass: 'toast-top-center',
						toastClass: ' my-custom-toast ngx-toastr',
						progressBar: true
					});
				}
				else {
					this._toastService.error("Error", "Error", {
						timeOut: 3000,
						positionClass: 'toast-top-center',
						toastClass: ' my-custom-toast ngx-toastr',
						progressBar: true
					});
				}
			}
		)
	}

	public acceptDataRecruiter = (recruiter: Recruiter) => {
		this._recruiterService.UpdateStatus(recruiter.recruiterId, true, false).subscribe(
			(response) => {
				if (response === true) {
					console.log(response);
					this.refreshDataRecruiters();

					this._toastService.success("Accepted", "Accepted", {
						timeOut: 3000,
						positionClass: 'toast-top-center',
						toastClass: ' my-custom-toast ngx-toastr',
						progressBar: true
					});
				}
				else {
					this._toastService.error("Error", "Error", {
						timeOut: 3000,
						positionClass: 'toast-top-center',
						toastClass: ' my-custom-toast ngx-toastr',
						progressBar: true
					});
				}
			}
		)
	}
	public denyDataRecruiter = (recruiter: Recruiter) => {
		this._recruiterService.UpdateStatus(recruiter.recruiterId, false, true).subscribe(
			(response) => {
				if (response === true) {
					console.log(response);
					this.refreshDataRecruiters();

					this._toastService.success("Deny", "Deny", {
						timeOut: 3000,
						positionClass: 'toast-top-center',
						toastClass: ' my-custom-toast ngx-toastr',
						progressBar: true
					});
				}
				else {
					this._toastService.error("Error", "Error", {
						timeOut: 3000,
						positionClass: 'toast-top-center',
						toastClass: ' my-custom-toast ngx-toastr',
						progressBar: true
					});
				}
			}
		)
	}

	public actionsRecruiters: ActionType[] = ['accept', 'deny'];
	public listPropsRecruiters: string[] = [
		"recruiterId",
		"userId",
		"companyId",
	];
	public displayColumnRecruiters: string[] = [
		"Recruiter Id",
		"User Id",
		"Company Id",
	];
	public listRecruiters = new BehaviorSubject<Recruiter[]>([]);

	constructor(
		public _recruiterService: RecruiterService,
		public _companyService: CompanyService,
		public _toastService: ToastrService
	) {
		this.refreshDataRecruiters();
		this.refreshDataCompanies();
	}

	refreshDataCompanies() {
		this._companyService.getAll().subscribe(
			recruiters => {
				this.listCompanies.next(recruiters.filter(e => !e.isActived && !e.isDeleted));
			},
			error => console.error(error)
		);
	}

	refreshDataRecruiters() {
		this._recruiterService.getAll().subscribe(
			recruiters => {
				this.listRecruiters.next(recruiters.filter(e => !e.isActived && !e.isDeleted));
			},
			error => console.error(error)
		);
	}
}
