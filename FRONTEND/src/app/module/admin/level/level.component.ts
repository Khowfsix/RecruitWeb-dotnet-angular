import { Component, ViewContainerRef } from '@angular/core';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { LevelService } from '../../../data/level/level.service';
import { Level } from '../../../data/level/level.model';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { AddFormComponent } from './add-form/add-form.component';

@Component({
	selector: 'app-level',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './level.component.html',
	styleUrl: './level.component.css',
})
export class LevelComponent {
	public actions: ActionType[] = ['create', 'update', 'delete'];
	public listProps: string[] = [
		"levelId",
		"levelName",
	];
	public displayColumn: string[] = [
		"ID",
		"Name",
	];
	public listLevels = new BehaviorSubject<Level[]>([]);

	constructor(
		private viewContainerRef: ViewContainerRef,
		private dialog: MatDialog,

		public _levelService: LevelService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._levelService.getAllLevels().subscribe(
			levels => {
				this.listLevels.next(levels.filter(sk => sk.isDeleted == false));
			},
			error => console.error(error)
		);
	}

	delete = (level: Level): void => {
		this._levelService.deleteLevel(level.levelId).subscribe(
			(response) => {
				console.log(response);
				this.refreshData();

				this._toastService.success("Delete success", "Delete level success", {
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
			height: '300px',
			enterAnimationDuration: '100ms',
			exitAnimationDuration: '0ms',
		});

		addFormDialog.afterClosed().subscribe(() => {
			this.refreshData();
		});
	}

	public edit = (row: Level): void => {
		const editFormDialog = this.dialog.open(AddFormComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				foundLevel: row,
				isEditForm: true,
			},
			width: '500px',
			height: '300px',
			enterAnimationDuration: '100ms',
			exitAnimationDuration: '0ms',
		});

		editFormDialog.afterClosed().subscribe(() => {
			this.refreshData();
		});
	}
}
