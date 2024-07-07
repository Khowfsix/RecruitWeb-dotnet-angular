import { Component, ViewContainerRef } from '@angular/core';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { BehaviorSubject } from 'rxjs';
import { Language } from '../../../data/language/language.model';
import { LanguageService } from '../../../data/language/language.service';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { AddFormComponent } from './add-form/add-form.component';

@Component({
	selector: 'app-language',
	standalone: true,
	imports: [
		GenericTableComponent
	],
	templateUrl: './language.component.html',
	styleUrl: './language.component.css',
})
export class LanguageComponent {
	public actions: ActionType[] = ['create', 'update', 'delete'];
	public listProps: string[] = [
		"languageId",
		"languageName",
	];
	public displayColumn: string[] = [
		"ID",
		"Name",
	];
	public listDatas = new BehaviorSubject<Language[]>([]);

	constructor(
		private viewContainerRef: ViewContainerRef,
		private dialog: MatDialog,

		public _languageService: LanguageService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._languageService.getAllLanguagues().subscribe(
			datas => {
				this.listDatas.next(datas.filter(data => data.isDeleted == false));
			},
			error => console.error(error)
		);
	}

	delete = (language: Language): void => {
		this._languageService.deleteLanguage(language.languageId).subscribe(
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
			height: '300px',
			enterAnimationDuration: '100ms',
			exitAnimationDuration: '0ms',
		});

		addFormDialog.afterClosed().subscribe(() => {
			this.refreshData();
		});
	}

	public edit = (row: Language): void => {
		const editFormDialog = this.dialog.open(AddFormComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				foundLanguage: row,
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
