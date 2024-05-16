import { Component } from '@angular/core';
import { GenericTableComponent } from '../generic/generic-table.component';
import { BehaviorSubject } from 'rxjs';
import { Language } from '../../../data/language/language.model';
import { LanguageService } from '../../../data/language/language.service';
import { ToastrService } from 'ngx-toastr';

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
		public _dataService: LanguageService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._dataService.getAllLanguagues().subscribe(
			datas => {
				this.listDatas.next(datas.filter(data => data.isDeleted == false));
			},
			error => console.error(error)
		);
	}

	// delete = (data: Language): void => {
	// this._dataService.(skill.skillId).subscribe(
	// 	(response) => {
	// 		console.log(response);
	// 		this.refreshData();

	// 		this._toastService.success("Delete success", "Delete skill success", {
	// 			timeOut: 3000,
	// 			positionClass: 'toast-top-center',
	// 			progressBar: true
	// 		});
	// 	}
	// )
	// }
}
