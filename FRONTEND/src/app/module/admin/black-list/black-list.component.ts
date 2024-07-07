import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { BlackListService } from '../../../data/blacklist/blacklist.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { BlackList } from '../../../data/blacklist/blacklist.model';

@Component({
	selector: 'app-black-list',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './black-list.component.html',
	styleUrl: './black-list.component.css'
})
export class BlackListComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"blackListId",
		"candidateId",
		"reason",
		"datetime",
		"status",
	];
	public displayColumn: string[] = [
		"BlackList Id",
		"Candidate Id",
		"Reason",
		"Datetime",
		"Status",
	];
	public listBlackLists = new BehaviorSubject<BlackList[]>([]);

	constructor(
		public _blacklistService: BlackListService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._blacklistService.getAll().subscribe(
			blacklists => {
				this.listBlackLists.next(blacklists.filter(e => !e.isDeleted));
			},
			error => console.error(error)
		);
	}
}
