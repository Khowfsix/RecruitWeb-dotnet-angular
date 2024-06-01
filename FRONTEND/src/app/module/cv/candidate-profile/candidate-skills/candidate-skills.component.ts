import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { ToastrService } from 'ngx-toastr';

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
