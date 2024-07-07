import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { EventHasPositionService } from '../../../data/eventHasPosition/eventHasPosition.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { EventHasPosition } from '../../../data/eventHasPosition/eventHasPosition.model';

@Component({
	selector: 'app-event-has-position',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './event-has-position.component.html',
	styleUrl: './event-has-position.component.css'
})
export class EventHasPositionComponent {
	public actions: ActionType[] = [];
	public listProps: string[] = [
		"eventHasPositionId",
		"eventId",
		"positionId",
	];
	public displayColumn: string[] = [
		"Event-Has-Position Id",
		"Event Id",
		"Position Id",
	];
	public listEventHasPositions = new BehaviorSubject<EventHasPosition[]>([]);

	constructor(
		public _eventHasPositionService: EventHasPositionService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._eventHasPositionService.getAll().subscribe(
			eventhaspositions => {
				this.listEventHasPositions.next(eventhaspositions);
			},
			error => console.error(error)
		);
	}
}
