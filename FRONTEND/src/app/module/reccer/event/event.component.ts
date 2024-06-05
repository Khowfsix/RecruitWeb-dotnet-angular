/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable no-var */
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import {
	FormBuilder,
	FormControl,
	FormGroup,
	FormsModule,
	ReactiveFormsModule,
} from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { EventService } from '../../../data/event/event.service';
import { AuthService } from '../../../core/services/auth.service';
import { Event } from '../../../data/event/event.model';
import { CommonModule } from '@angular/common';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, MatOptionModule } from '@angular/material/core';
import { MAX_MAX_PARTICIPANTS } from '../../../core/constants/event.constants';
import { CustomDateTimeService } from '../../../shared/service/custom-datetime.service';
import { debounceTime } from 'rxjs';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { MY_DAY_FORMATS } from '../../../core/constants/app.env';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSliderModule } from '@angular/material/slider';
import { MatDialog } from '@angular/material/dialog';
import { AddFormComponent } from './add-form/add-form.component';
import { DeleteDialogComponent } from '../../../shared/component/dialog/delete-dialog/delete-dialog.component';
import moment from 'moment';
import { QrcodeDialogComponent } from '../../../shared/component/dialog/qrcode-dialog/qrcode-dialog.component';
import { baseUrl } from '../../../data/api.service';

@Component({
	selector: 'app-event',
	standalone: true,
	providers: [
		{ provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
		{ provide: MAT_DATE_FORMATS, useValue: MY_DAY_FORMATS },
	],
	templateUrl: './event.component.html',
	styleUrl: './event.component.css',
	imports: [
		RouterModule,
		MatSliderModule,
		MatDatepickerModule,
		MatOptionModule,
		CommonModule,
		MatMenuModule,
		MatIconModule,
		MatDividerModule,
		MatButtonModule,
		FormsModule,
		MatFormFieldModule,
		MatInputModule,
		ReactiveFormsModule,
	]
})
export class EventComponent implements OnInit {
	constructor(
		private viewContainerRef: ViewContainerRef,
		private dialog: MatDialog,
		private authService: AuthService,
		private eventService: EventService,
		private formBuilder: FormBuilder,
		private customDateService: CustomDateTimeService,
	) { }
	public MAX_MAX_PARTICIPANTS_CONST = MAX_MAX_PARTICIPANTS;
	public sortString = new FormControl('StartDateTime_DESC');

	public filterForm: FormGroup = this.formBuilder.group({
		search: ['', []],
		fromDate: [null, []],
		toDate: [null, []],
		fromMaxParticipants: [0, []],
		toMaxParticipants: [MAX_MAX_PARTICIPANTS + 1, []],
	});

	public searchFormControl = this.filterForm.get('search') as FormControl;

	public localStorageRecruiter = this.authService.getLocalCurrentUser().recruiters?.pop();
	public fetchedEvents?: Event[];

	public openQRCodeDialog(event: Event, enterAnimationDuration: string,
		exitAnimationDuration: string) {
		this.dialog.open(QrcodeDialogComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				qrdata: `${baseUrl}/events/detail/${event.eventId}`,
			},
			width: '400px',
			height: '450px',
			enterAnimationDuration,
			exitAnimationDuration,
		});
	}

	private callApiGetAllByRecruiterId() {
		var filterFormValue = this.filterForm.value;

		filterFormValue.fromDate = this.customDateService.sameValueToUTC(filterFormValue.fromDate, true);
		filterFormValue.toDate = this.customDateService.sameValueToUTC(filterFormValue.toDate, true);

		this.eventService.getAllByRecruiterId(this.localStorageRecruiter?.recruiterId ?? '', filterFormValue, this.sortString.value!).subscribe((data) => {
			// console.log('data ', data)
			this.fetchedEvents = data;
		})
	}

	public isHappenning(startDateTime?: string | Date, endDateTime?: string | Date) {
		const startDateTimeMoment = moment(startDateTime);
		const endDateTimeMoment = moment(endDateTime);

		const nowDateTime = new Date();

		return (startDateTimeMoment.toDate() <= nowDateTime && nowDateTime <= endDateTimeMoment.toDate())
	}

	public openDeleteFormDialog(event: Event, enterAnimationDuration: string,
		exitAnimationDuration: string) {
		const editFormDialog = this.dialog.open(DeleteDialogComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				objectLabel: 'Event',
				objectName: event.eventName,
				deleteApiServiceObservable: this.eventService.delete(event.eventId ?? '')
			},
			width: '400px',
			height: '200px',
			enterAnimationDuration,
			exitAnimationDuration,
		});

		editFormDialog.afterClosed().subscribe(() => {
			this.callApiGetAllByRecruiterId();
		});
	}

	public openEditFormDialog(event: Event, enterAnimationDuration: string,
		exitAnimationDuration: string) {
		const editFormDialog = this.dialog.open(AddFormComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				recruiter: this.localStorageRecruiter,
				event: event,
				isEditForm: true,
			},
			width: '1000px',
			height: '500px',
			enterAnimationDuration,
			exitAnimationDuration,
		});

		editFormDialog.afterClosed().subscribe(() => {
			this.callApiGetAllByRecruiterId();
		});
	}

	public openAddFormDialog(
		enterAnimationDuration: string,
		exitAnimationDuration: string,
	): void {
		const dialogRef = this.dialog.open(AddFormComponent, {
			viewContainerRef: this.viewContainerRef,
			data: {
				recruiter: this.localStorageRecruiter,
			},
			width: '700px',
			height: '600px',
			enterAnimationDuration,
			exitAnimationDuration,
		});

		dialogRef.afterClosed().subscribe(() => {
			this.callApiGetAllByRecruiterId();
		});
	}

	public getMyControl(formField: string): FormControl {
		return this.filterForm.get(formField) as FormControl;
	}

	public setValue(event: any, formField: string) {
		this.filterForm.get(formField)?.setValue(event.target.value)
	}

	ngOnInit(): void {
		this.callApiGetAllByRecruiterId();

		this.filterForm.valueChanges.pipe(debounceTime(300)).subscribe(() => {
			this.callApiGetAllByRecruiterId();
		})

		this.sortString.valueChanges.pipe(debounceTime(300)).subscribe(() => {
			this.callApiGetAllByRecruiterId();
		})
	}
}
