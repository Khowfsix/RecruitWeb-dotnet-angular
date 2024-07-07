/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { PositionService } from '../../../data/position/position.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { Position } from '../../../data/position/position.model';

@Component({
	selector: 'app-position',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './position.component.html',
	styleUrl: './position.component.css'
})
export class PositionComponent {
	public actions: ActionType[] = ['read'];
	public listProps: string[] = [
		"positionId",
		"positionName",
		"startDate",
		"endDate",
		"companyId",
		"recruiterId",
		"categoryPositionId",
		"levelId",
	];
	public displayColumn: string[] = [
		"Position Id",
		"Position Name",
		"Start Date",
		"End Date",
		"Company Id",
		"Recruiter Id",
		"Category-Position Id",
		"Level Id",
	];
	public detailListProps: string[] = [
		"imageURL",
		"minSalary",
		"maxSalary",
		"maxHiringQty",
		"description",
	];
	public detailDisplayedColumns: string[] = [
		"Image URL",
		"Min Salary",
		"Max Salary",
		"Max Hiring Qty",
		"Description",
		"companyId",
	];
	public listPositions = new BehaviorSubject<Position[]>([]);

	constructor(
		public _positionService: PositionService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._positionService.getAll().subscribe(
			positions => {
				this.listPositions.next(positions.items.filter((e: any) => !e.isDeleted));
			},
			error => console.error(error)
		);
	}
}
