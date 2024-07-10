import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { EventService } from '../../../data/event/event.service';
import { ActionType, GenericTableComponent } from '../generic/generic-table.component';
import { Event } from '../../../data/event/event.model';

@Component({
	selector: 'app-event',
	standalone: true,
	imports: [
		GenericTableComponent,
	],
	templateUrl: './event.component.html',
	styleUrl: './event.component.css'
})
export class EventComponent {
	public actions: ActionType[] = ['read'];
	public listProps: string[] = [
		"eventId",
		"eventName",
		"recruiterId",
		"place",
		"startDateTime",
		"endDateTime",
		"maxParticipants",
	];
	public displayColumn: string[] = [
		"Event Id",
		"Event Name",
		"Recruiter Id",
		"Place",
		"Start DateTime",
		"End DateTime",
		"Max Participants",
	];
	public detailDisplayedColumns: string[] = [
		"Image URL",
		"Description",
	]
	public detailListProps: string[] = [
		"imageURL",
		"description",
	]
	public listEvents = new BehaviorSubject<Event[]>([]);

	constructor(
		public _eventService: EventService,
		public _toastService: ToastrService
	) {
		this.refreshData();
	}

	refreshData() {
		this._eventService.getAll().subscribe(
			events => {
				this.listEvents.next(events.filter(e => !e.isDeleted));
			},
			error => console.error(error)
		);
	}
}
