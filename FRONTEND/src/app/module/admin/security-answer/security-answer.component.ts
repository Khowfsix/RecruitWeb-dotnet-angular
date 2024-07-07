import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { SecurityAnswerService } from '../../../data/security-answer/security-answer.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { SecurityAnswer } from '../../../data/security-answer/security-answer.module';

@Component({
	selector: 'app-security-answer',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './security-answer.component.html',
	styleUrl: './security-answer.component.css'
})
export class SecurityAnswerComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"securityAnswerId",
		"securityQuestionId",
		"webUserId",
		"answerString",
	];
	public displayColumn: string[] = [
		"Security-Answer Id",
		"Security-Question Id",
		"WebUser Id",
		"Answer String",
	];
	public listSecurityAnswers = new BehaviorSubject<SecurityAnswer[]>([]);

	constructor(
		public _securityAnswerService: SecurityAnswerService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._securityAnswerService.getAllSecurityAnswers().subscribe(
			securityAnswers => {
				this.listSecurityAnswers.next(securityAnswers);
			},
			error => console.error(error)
		);
	}
}
