import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { SecurityQuestionService } from '../../../data/security-question/security-question.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { SecurityQuestion } from '../../../data/security-question/security-question.module';

@Component({
	selector: 'app-security-question',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './security-question.component.html',
	styleUrl: './security-question.component.css'
})
export class SecurityQuestionComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"securityQuestionId",
		"questionString",
	];
	public displayColumn: string[] = [
		"Security-Question Id",
		"Question String",
	];
	public listSecurityQuestions = new BehaviorSubject<SecurityQuestion[]>([]);

	constructor(
		public _securityQuestionService: SecurityQuestionService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._securityQuestionService.getAllSecurityQuestions().subscribe(
			securityQuestions => {
				this.listSecurityQuestions.next(securityQuestions);
			},
			error => console.error(error)
		);
	}
}
