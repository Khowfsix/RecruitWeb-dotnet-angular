import { Component } from '@angular/core';
import { ActionType, GenericTableComponent } from "../generic/generic-table.component";
import { CompanyService } from '../../../data/company/company.service';
import { Company, CompanyAddModel } from '../../../data/company/company.model';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-company',
	standalone: true,
	templateUrl: './company.component.html',
	styleUrl: './company.component.css',
	imports: [GenericTableComponent]
})
export class CompanyComponent {
	public actions: ActionType[] = ['read'];
	public listProps: string[] = [
		"companyId",
		"companyName",
		"address",
		"email",
		"phone",
		"website",
	];
	public displayColumn: string[] = [
		"ID",
		"Name",
		"Address",
		"Email",
		"Phone",
		"Website",
	];
	public detailListProps: string[] = [
		"logo",
	];
	public detailDisplayColumn: string[] = [
		"Logo",
	];
	public listCompanies = new BehaviorSubject<Company[]>([]);

	constructor(
		public _companyService: CompanyService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._companyService.getAll().subscribe(
			companys => {
				this.listCompanies.next(companys.filter(sk => sk.isDeleted == false));
			},
			error => console.error(error)
		);
	}

	delete = (company: Company): void => {
		this._companyService.deleteCompany(company.companyId).subscribe(
			(response) => {
				console.log(response);
				this.refreshData();

				this._toastService.success("Delete success", "Delete company success", {
					timeOut: 3000,
					positionClass: 'toast-top-center',
					toastClass: ' my-custom-toast ngx-toastr',
					progressBar: true
				});
			}
		)
	}

	create = (newCompany: CompanyAddModel): void => {
		this._companyService.createCompany(newCompany).subscribe(
			(response) => {
				console.log(response);
				this.refreshData();

				this._toastService.success("Create success", "Create company success", {
					timeOut: 3000,
					positionClass: 'toast-top-center',
					toastClass: ' my-custom-toast ngx-toastr',
					progressBar: true
				});
			}
		)
	}
}
