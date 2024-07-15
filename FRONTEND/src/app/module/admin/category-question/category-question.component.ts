import { Component, ViewContainerRef } from '@angular/core';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { CategoryQuestionService } from '../../../data/categoryQuestion/category-question.service';
import { CategoryQuestion } from '../../../data/categoryQuestion/categoryQuestion.model';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { AddFormComponent } from './add-form/add-form.component';

@Component({
	selector: 'app-category-question',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './category-question.component.html',
	styleUrl: './category-question.component.css',
})
export class CategoryQuestionComponent {
	public actions: ActionType[] = ['update'];
	public listProps: string[] = [
		"categoryQuestionId",
		"categoryQuestionName",
		"weight",
	];
	public displayColumn: string[] = [
		"ID",
		"Name",
		"Weight",
	];
	public listCategoryQuestions = new BehaviorSubject<CategoryQuestion[]>([]);

	constructor(
		private viewContainerRef: ViewContainerRef,
		private dialog: MatDialog,

		public _categoryQuestionService: CategoryQuestionService,
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

	public edit = (row: CategoryQuestion): void => {
		const editFormDialog = this.dialog.open(AddFormComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				foundCategoryQuestion: row,
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
		this._categoryQuestionService.getAllCategoryQuestions().subscribe(
			categoryQuestions => {
				this.listCategoryQuestions.next(categoryQuestions);
			},
			error => console.error(error)
		);
	}
}
