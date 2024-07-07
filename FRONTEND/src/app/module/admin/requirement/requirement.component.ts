import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { RequirementsService } from '../../../data/requirements/requirements.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { Requirements } from '../../../data/requirements/requirements.model';

@Component({
	selector: 'app-requirement',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './requirement.component.html',
	styleUrl: './requirement.component.css'
})
export class RequirementComponent {
	public actions: ActionType[] = ['read'];
	public listProps: string[] = [
		"requirementId",
		"positionId",
		"skillId",
		"experience",
	];
	public displayColumn: string[] = [
		"Requirement Id",
		"Position Id",
		"Skill Id",
		"Experience",
	];
	public detailListProps: string[] = [
		"notes",
	];
	public detailDisplayedColumns: string[] = [
		"Notes",
	];
	public listRequirements = new BehaviorSubject<Requirements[]>([]);

	constructor(
		public _requirementService: RequirementsService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._requirementService.getAllRequirements().subscribe(
			requirements => {
				this.listRequirements.next(requirements.filter(e => !e.isDeleted));
			},
			error => console.error(error)
		);
	}
}
