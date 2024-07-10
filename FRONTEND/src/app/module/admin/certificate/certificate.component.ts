import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { CertificateService } from '../../../data/certificate/certificate.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { Certificate } from '../../../data/certificate/certificate.model';

@Component({
	selector: 'app-certificate',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './certificate.component.html',
	styleUrl: './certificate.component.css'
})
export class CertificateComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"certificateId",
		"certificateName",
		"description",
		"issueDate",
		"certificateURL",
		"candidateId",
	];
	public displayColumn: string[] = [
		"Certificate Id",
		"Certificate Name",
		"Description",
		"Issue Date",
		"Certificate URL",
		"Candidate Id",
	];
	public listCertificates = new BehaviorSubject<Certificate[]>([]);

	constructor(
		public _certificateService: CertificateService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._certificateService.getAllCertificates().subscribe(
			certificates => {
				this.listCertificates.next(certificates);
			},
			error => console.error(error)
		);
	}
}
