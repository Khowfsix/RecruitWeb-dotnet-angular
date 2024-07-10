import { Component, ViewContainerRef } from '@angular/core';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { CategoryPositionService } from '../../../data/categoryPosition/category-position.service';
import { CategoryPosition } from '../../../data/categoryPosition/category-position.model';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { AddFormComponent } from './add-form/add-form.component';

@Component({
	selector: 'app-category-position',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './category-position.component.html',
	styleUrl: './category-position.component.css',
})
export class CategoryPositionComponent {
	public actions: ActionType[] = ['create', 'update'];
	public listProps: string[] = [
		"categoryPositionId",
		"categoryPositionName",
		"categoryPositionDescription",
	];
	public displayColumn: string[] = [
		"ID",
		"Name",
		"Description",
	];
	public listCategoryPositions = new BehaviorSubject<CategoryPosition[]>([]);

	constructor(
		private viewContainerRef: ViewContainerRef,
		private dialog: MatDialog,

		public _categoryPositionService: CategoryPositionService,
		public _toastService: ToastrService
	) {
		this.refreshData();
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

	public edit = (row: CategoryPosition): void => {
		const editFormDialog = this.dialog.open(AddFormComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				foundCategoryPosition: row,
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

	refreshData() {
		this._categoryPositionService.getAllCategoryPositions().subscribe(
			categoryPositions => {
				this.listCategoryPositions.next(categoryPositions.filter(e => !e.isDeleted));
			},
			error => console.error(error)
		);
	}
}
