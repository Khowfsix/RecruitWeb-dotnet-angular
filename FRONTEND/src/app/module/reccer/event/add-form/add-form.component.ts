/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Position } from '../../../../data/position/position.model';
import { AutocompleteComponent } from "../../../../shared/component/inputs/autocomplete/autocomplete.component";
import { PositionService } from '../../../../data/position/position.service';
import { AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Subject, debounceTime, pairwise, startWith } from 'rxjs';
import { Recruiter } from '../../../../data/recruiter/recruiter.model';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DATE_FORMATS, MAT_DATE_LOCALE, DateAdapter } from '@angular/material/core';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { MY_DAY_FORMATS } from '../../../../core/constants/app.env';
import { MatButtonModule } from '@angular/material/button';
import { EventService } from '../../../../data/event/event.service';
import { ToastrService } from 'ngx-toastr';
import { GreaterOrEqualToDay, dateValidator, timeValidator } from '../../../../shared/validators/date.validator';
import { CustomDateTimeService } from '../../../../shared/service/custom-datetime.service';
import { Event } from '../../../../data/event/event.model';
import { MatIcon } from '@angular/material/icon';
import { AddEventHasPositionsComponent } from '../add-event-has-positions/add-event-has-positions.component';
import { fileFormatter } from '../../../../shared/service/fileFormatter';
import { FileService } from '../../../../data/file/file-service.service';
import moment from 'moment';
import { EventHasPosition } from '../../../../data/eventHasPosition/eventHasPosition.model';
import { EventHasPositionService } from '../../../../data/eventHasPosition/eventHasPosition.service';
import { MAX_MAX_PARTICIPANTS } from '../../../../core/constants/event.constants';
@Component({
	selector: 'app-add-form',
	standalone: true,
	templateUrl: './add-form.component.html',
	styleUrl: './add-form.component.css',
	providers: [
		{ provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
		{ provide: MAT_DATE_FORMATS, useValue: MY_DAY_FORMATS },
	],
	imports: [
		AddEventHasPositionsComponent,
		MatIcon,
		ReactiveFormsModule,
		MatButtonModule,
		MatDatepickerModule,
		MatInputModule,
		AutocompleteComponent,
		MatFormFieldModule
	]
})
export class AddFormComponent implements OnInit {
	constructor(
		@Inject(MAT_DIALOG_DATA) public data: any,
		private formBuilder: FormBuilder,
		public dialogRef: MatDialogRef<AddFormComponent>,
		// private openStreetMapService: OpenStreetMapService,
		private customDateTimeService: CustomDateTimeService,
		private toastr: ToastrService,
		private positionService: PositionService,
		private eventService: EventService,
		public fileFormatter: fileFormatter,
		private fileService: FileService,
		private customDateService: CustomDateTimeService,
		private eventHasPositionService: EventHasPositionService,
	) { }

	private DateTimeRangeValidator(startDate: string, startTime: string, endDate: string, endTime: string) {
		return (control: AbstractControl): { [key: string]: any } | null => {
			let startDateValue = control.get(startDate)?.value;
			const startTimeValue = control.get(startTime)?.value;
			let endDateValue = control.get(endDate)?.value;
			const endTimeValue = control.get(endTime)?.value;

			if (typeof startDateValue === 'string')
				startDateValue = moment(startDateValue)

			if (typeof endDateValue === 'string')
				endDateValue = moment(endDateValue)


			if (startDateValue && endDateValue && startDateValue.toDate().setHours(0, 0, 0, 0) === endDateValue.toDate().setHours(0, 0, 0, 0)) {
				if (startTimeValue && endTimeValue && startTimeValue >= endTimeValue)
					return { 'dateTimeRangeInvalid': true }
			}

			return null;
		};

	}

	private recruiterId = this.data ? this.data.recruiter.recruiterId : '';
	private recruiter: Recruiter = this.data ? this.data.recruiter : undefined;
	public foundEvent?: Event = this.data ? this.data.event : undefined;
	public positionData$ = this.positionService.getAllPositions(undefined, undefined, undefined, undefined, this.recruiter.recruiterId);
	private positionData?: Position[];
	public positionIdSubject = new Subject<any>();
	public showApplicationAutocomplete = false;
	public openStreetMapData? = null
	public isEditing = false;
	@Input()
	public isEditForm: boolean = this.data ? this.data.isEditForm ?? false : false;
	public isEdit: boolean = false;

	public addForm: FormGroup = this.formBuilder.group({
		eventName: [this.foundEvent ? this.foundEvent.eventName : '', [Validators.required]],
		imageURL: [this.foundEvent ? this.foundEvent.imageURL : '', []],
		recruiterId: [this.foundEvent ? this.foundEvent.recruiterId : '', [Validators.required]],
		imageName: [this.foundEvent ? this.foundEvent.imageURL : '', []],
		imageFile: [this.foundEvent ? this.foundEvent.imageURL : null, []],
		description: [this.foundEvent ? this.foundEvent.description : '', []],
		applyPriority: [this.foundEvent ? this.foundEvent.applyPriority : '', []],
		place: [this.foundEvent ? this.foundEvent.place : '', [Validators.required]],
		startTime: [this.foundEvent ? this.foundEvent.startDateTime?.toString().slice(11, 19) : '', [Validators.required]],
		endTime: [this.foundEvent ? this.foundEvent.endDateTime?.toString().slice(11, 19) : '', [Validators.required]],
		startDate: [this.foundEvent ? this.foundEvent.startDateTime : '', [Validators.required, GreaterOrEqualToDay()]],
		endDate: [this.foundEvent ? this.foundEvent.endDateTime : '', [Validators.required, GreaterOrEqualToDay()]],
		maxParticipants: [this.foundEvent ? this.foundEvent.maxParticipants : '', [Validators.required, Validators.max(MAX_MAX_PARTICIPANTS)]],
		eventHasPositions: [this.foundEvent ? this.foundEvent.eventHasPositions : [], [],],
	}, { validator: [this.DateTimeRangeValidator('startDate', 'startTime', 'endDate', 'endTime'), dateValidator('startDate', 'endDate', true)] });


	ngOnInit(): void {
		// console.log('foundEvent', this.foundEvent ? this.foundEvent : 'undefined')
		// console.log('blaaaaaaaaaa: ', this.foundEvent?.endDateTime?.toString().slice(11, 19))
		// this.addForm.valueChanges.subscribe(() => console.log('this.addForm.value', this.addForm.value));

		// console.log('call api googlleeeeeeee')
		// this.openStreetMapService.search('võ văn ngân').subscribe((data: any) => {
		// 	console.log('open street map data', data)
		// 	this.openStreetMapData = data;
		// })
		if (this.recruiterId)
			this.addForm.get('recruiterId')?.setValue(this.recruiterId);

		if (this.foundEvent) {
			this.addForm.patchValue({
				eventName: this.foundEvent.eventName,
				imageURL: this.foundEvent.imageURL,
				recruiterId: this.foundEvent.recruiterId,
				imageName: this.foundEvent.imageURL,
				imageFile: this.foundEvent.imageURL,
				description: this.foundEvent.description,
				place: this.foundEvent.place,
				startTime: this.foundEvent.startDateTime?.toString().slice(11, 19),
				endTime: this.foundEvent.endDateTime?.toString().slice(11, 19),
				startDate: this.foundEvent.startDateTime,
				endDate: this.foundEvent.endDateTime,
				maxParticipants: this.foundEvent.maxParticipants,
				eventHasPositions: this.foundEvent.eventHasPositions,
			});
			this.showApplicationAutocomplete = true;
			this.addForm.disable();
		}

		this.addForm.get('priority')?.disable();

		this.positionData$.subscribe((data) => {
			this.positionData = data;
		})

		this.addForm.get('positionId')?.valueChanges.pipe(startWith(null), pairwise()).subscribe(([oldValue, newValue]: [any, any]) => {
			// console.log('oldValue', oldValue);
			// console.log('newValue', newValue);
			if (this.positionData?.map(e => e.positionId).includes(newValue)) {
				// console.log('newValue', newValue);
				// if (this.addForm.get('positionId')?.value !== newValue)
				if (oldValue !== newValue)
					this.positionIdSubject.next(newValue);
			}
			else {
				this.showApplicationAutocomplete = false;
				this.addForm.get('applicationId')?.setValue('');
			}

		});

		this.positionIdSubject.pipe(debounceTime(300)).subscribe((positionId) => {
			// console.log('positionId', positionId)
			this.showApplicationAutocomplete = true;
		})
	}

	public updateEvent() {
		// console.log(this.addForm.errors)
		// console.log(this.addForm.value)
		const fieldValue = this.addForm.value;
		const file: File = this.addForm.get('imageFile')?.value;
		if (file && file.name) {
			if (this.foundEvent?.imageURL) {
				const formData = new FormData();
				formData.append('newImage', file, file.name);
				formData.append('oldImageUrl', this.foundEvent?.imageURL ?? '');
				this.fileService.updateFile(formData).subscribe({
					next: (response: any) => {
						fieldValue.imageURL = response.url;
						this.callApiUpdateEvent(fieldValue);
					},
					error: () => {
						this.toastr.error('File upload failed.', 'Error!', {
							timeOut: 3000,
							toastClass: ' my-custom-toast ngx-toastr'
						});
						return;
					},
				});
			}
			else {
				const formData = new FormData();
				formData.append('formFile', file, file.name);
				this.fileService.uploadFile(formData).subscribe({
					next: (response: any) => {
						fieldValue.imageURL = response.url;
						this.callApiUpdateEvent(fieldValue);
					},
					error: () => {
						this.toastr.error('File upload failed.', 'Error!', {
							timeOut: 3000,
						});
						return;
					},
				});
			}

		}
		else {
			this.callApiUpdateEvent(fieldValue);
		}
	}

	private callApiUpdateEvent(fieldValue: any) {
		delete fieldValue.imageName;
		delete fieldValue.imageFile;

		if (typeof fieldValue.startDate === 'string')
			fieldValue.startDate = moment(fieldValue.startDate)
		if (typeof fieldValue.endDate === 'string')
			fieldValue.endDate = moment(fieldValue.endDate)

		const startDateTime = moment(`${fieldValue.startDate.format('DD-MM-YYYY')}T${fieldValue.startTime}:00`, 'DD-MM-YYYY HH:mm:ss');
		const endDateTime = moment(`${fieldValue.endDate.format('DD-MM-YYYY')}T${fieldValue.endTime}:00`, 'DD-MM-YYYY HH:mm:ss');

		fieldValue = {
			...fieldValue,
			startDateTime: this.customDateService.sameValueToUTC(startDateTime, false),
			endDateTime: this.customDateService.sameValueToUTC(endDateTime, false),
		};
		delete fieldValue.startDate;
		delete fieldValue.endDate;
		delete fieldValue.startTime;
		delete fieldValue.endTime;

		this.eventService.update(this.foundEvent?.eventId ?? '', fieldValue).subscribe({
			next: (resp: any) => {
				if (resp === true) {
					if (this.foundEvent?.eventHasPositions) {
						this.foundEvent?.eventHasPositions?.forEach(e => {
							this.callApiDeleteEventHasPosition(e.eventHasPositionId ?? '');
						});
					}

					const eventHasPositions: EventHasPosition[] = this.addForm.get('eventHasPositions')?.value;
					if (eventHasPositions) {
						eventHasPositions.forEach((req) => {
							req.eventId = this.foundEvent?.eventId;
							this.callApiSaveEventHasPosition(req);
						});
					}

					this.dialogRef.close();
					this.toastr.success('Event Updated...', 'Successfully!', {
						timeOut: 3000,
						toastClass: ' my-custom-toast ngx-toastr'
					});
				}
				else if (resp === 'Not found') {
					this.toastr.error('Something wrong...', 'Event update Error!!!', {
						timeOut: 3000,
						toastClass: ' my-custom-toast ngx-toastr'
					});
				}
			},
			error: () => {
				this.toastr.error('Something wrong...', 'Event update Error!!!', {
					timeOut: 3000,
					toastClass: ' my-custom-toast ngx-toastr'
				});
			},
			complete: () => {
			},
		});
	}

	private callApiDeleteEventHasPosition(eventHasPositionId: string) {
		this.eventHasPositionService.delete(eventHasPositionId).subscribe({
			next: () => { },
			error: () => {
				this.toastr.error('Something wrong...', 'Delete Event Has Position Error!!!', {
					timeOut: 3000,
					toastClass: ' my-custom-toast ngx-toastr'
				});
			},
			complete: () => { },
		})
	}

	private callApiSaveEventHasPosition(eventHasPosition: EventHasPosition) {
		this.eventHasPositionService.save(eventHasPosition).subscribe({
			next: () => { },
			error: () => {
				this.toastr.error('Something wrong...', 'Save Event Has Position Error!!!', {
					timeOut: 3000,
					toastClass: ' my-custom-toast ngx-toastr'
				});
			},
			complete: () => { },
		})
	}

	private callApiSaveEvent(fieldValue: any) {
		delete fieldValue.imageName;
		delete fieldValue.imageFile;
		const startDateTime = moment(`${fieldValue.startDate.format('DD-MM-YYYY')}T${fieldValue.startTime}:00`, 'DD-MM-YYYY HH:mm:ss');
		const endDateTime = moment(`${fieldValue.endDate.format('DD-MM-YYYY')}T${fieldValue.endTime}:00`, 'DD-MM-YYYY HH:mm:ss');

		fieldValue = {
			...fieldValue,
			startDateTime: this.customDateService.sameValueToUTC(startDateTime, false),
			endDateTime: this.customDateService.sameValueToUTC(endDateTime, false),
		};
		delete fieldValue.startDate;
		delete fieldValue.endDate;
		delete fieldValue.startTime;
		delete fieldValue.endTime;

		this.eventService.save(fieldValue).subscribe({
			next: (resp: any) => {
				const eventHasPositions: EventHasPosition[] = this.addForm.get('eventHasPositions')?.value;
				eventHasPositions.forEach((req) => {
					req.eventId = resp.eventId;
					this.callApiSaveEventHasPosition(req);
				});
				this.dialogRef.close();
				this.toastr.success('Position Added...', 'Successfully!', {
					timeOut: 3000,
					toastClass: ' my-custom-toast ngx-toastr'
				});
			},
			error: () => {
				this.toastr.error('Something wrong...', 'Save Position Error!!!', {
					timeOut: 3000,
					toastClass: ' my-custom-toast ngx-toastr'
				});
			},
			complete: () => {
			},
		});
	}

	public saveEvent() {
		// console.log(this.addForm.errors)
		// console.log(this.addForm.value)
		const fieldValue = this.addForm.value;
		const file: File = this.addForm.get('imageFile')?.value;
		if (file) {
			const formData = new FormData();
			formData.append('formFile', file, file.name);
			this.fileService.uploadFile(formData).subscribe({
				next: (response: any) => {
					fieldValue.imageURL = response.url;
					this.callApiSaveEvent(fieldValue);
				},
				error: () => {
					this.toastr.error('File upload failed.', 'Error!', {
						timeOut: 3000,
						toastClass: ' my-custom-toast ngx-toastr'
					});
					return;
				},
			});
		}
		else {
			this.callApiSaveEvent(fieldValue);
		}
	}
}
