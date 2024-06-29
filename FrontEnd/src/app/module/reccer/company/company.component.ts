import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../../../data/company/company.service';
import { Company } from '../../../data/company/company.model';
import { CommonModule } from '@angular/common';

@Component({
	selector: 'app-company',
	standalone: true,
	imports: [
		CommonModule
	],
	templateUrl: './company.component.html',
	styleUrl: './company.component.css',
})
export class CompanyComponent implements OnInit {
	companies: Company[] = [];

	constructor(private _companyService: CompanyService) { }

	ngOnInit(): void {
		this._companyService.getAll().subscribe({
			next: (data: Company[]) => {
				this.companies = data;
			},
			complete: () => { },
		});
	}
}
