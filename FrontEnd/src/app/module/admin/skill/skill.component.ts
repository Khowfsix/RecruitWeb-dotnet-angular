import { Component, ViewContainerRef } from '@angular/core';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { SkillService } from '../../../data/skill/skill.service';
import { Skill } from '../../../data/skill/skill.model';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { AddFormComponent } from './add-form/add-form.component';

@Component({
	selector: 'app-skill',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './skill.component.html',
	styleUrl: './skill.component.css',
})
export class SkillComponent {
	public actions: ActionType[] = ['create', 'update', 'delete'];
	public listProps: string[] = [
		"skillId",
		"skillName",
		"description"
	];
	public displayColumn: string[] = [
		"ID",
		"Name",
		"Description"
	];
	public listSkills = new BehaviorSubject<Skill[]>([]);

	constructor(
		private viewContainerRef: ViewContainerRef,
		private dialog: MatDialog,

		public _skillService: SkillService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._skillService.getAllSkills().subscribe(
			skills => {
				this.listSkills.next(skills.filter(sk => sk.isDeleted == false));
			},
			error => console.error(error)
		);
	}

	delete = (skill: Skill): void => {
		this._skillService.deleteSkill(skill.skillId).subscribe(
			(response) => {
				console.log(response);
				this.refreshData();

				this._toastService.success("Delete success", "Delete skill success", {
					timeOut: 3000,
					positionClass: 'toast-top-center',
					toastClass: ' my-custom-toast ngx-toastr',
					progressBar: true
				});
			}
		)
	}

	public create = (): void => {
		const addFormDialog = this.dialog.open(AddFormComponent, {
			width: '500px',
			height: '350px',
			enterAnimationDuration: '100ms',
			exitAnimationDuration: '0ms',
		});

		addFormDialog.afterClosed().subscribe(() => {
			this.refreshData();
		});
	}

	public edit = (row: Skill): void => {
		const editFormDialog = this.dialog.open(AddFormComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				foundSkill: row,
				isEditForm: true,
			},
			width: '500px',
			height: '350px',
			enterAnimationDuration: '100ms',
			exitAnimationDuration: '0ms',
		});

		editFormDialog.afterClosed().subscribe(() => {
			this.refreshData();
		});
	}
}
