import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { ToastrService } from 'ngx-toastr';
import { Candidate } from '../../../../data/candidate/candidate.model';

@Component({
	selector: 'app-candidate-skills',
	standalone: true,
	imports: [
		MatDividerModule,
		MatButtonModule
	],
	templateUrl: './candidate-skills.component.html',
	styleUrl: './candidate-skills.component.css'
})
export class CandidateSkillsComponent {
	@Input() candidate?: Candidate;
	@Output() refresh = new EventEmitter<void>();

	constructor(
		private _toastService: ToastrService
	) { }

	onClickEdit() {
		this._toastService.success("Click", "Edit", {
			timeOut: 3000,
			progressBar: true,
			positionClass: 'toast-bottom-right',
		})
	}


}
