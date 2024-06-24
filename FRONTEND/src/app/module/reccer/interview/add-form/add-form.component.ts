/* eslint-disable prefer-const */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Position } from '../../../../data/position/position.model';
import { AutocompleteComponent } from "../../../../shared/component/inputs/autocomplete/autocomplete.component";
import { PositionService } from '../../../../data/position/position.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ApplicationService } from '../../../../data/application/application.service';
import { Observable, Subject, debounceTime, pairwise, startWith } from 'rxjs';
import { Application } from '../../../../data/application/application.model';
import { InterviewerService } from '../../../../data/interviewer/interviewer.service';
import { Recruiter } from '../../../../data/recruiter/recruiter.model';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DATE_FORMATS, MAT_DATE_LOCALE, DateAdapter } from '@angular/material/core';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { MY_DAY_FORMATS } from '../../../../core/constants/app.env';
import { MatButtonModule } from '@angular/material/button';
import { InterviewService } from '../../../../data/interview/interview.service';
import { ToastrService } from 'ngx-toastr';
import { GreaterOrEqualToDay, timeValidator } from '../../../../shared/validators/date.validator';
import { CustomDateTimeService } from '../../../../shared/service/custom-datetime.service';
import { Interview } from '../../../../data/interview/interview.model';
import { ZoomService } from '../../../../shared/service/zoom.service';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { ZoomMeeting } from '../../../../shared/service/zoom-meeting.model';
import { Moment } from 'moment';
import moment from 'moment';

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
		MatSlideToggleModule,
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
		private zoomService: ZoomService,
		public dialogRef: MatDialogRef<AddFormComponent>,
		// private openStreetMapService: OpenStreetMapService,
		private customDateTimeService: CustomDateTimeService,
		private toastr: ToastrService,
		private positionService: PositionService,
		private applicationService: ApplicationService,
		private interviewService: InterviewService,
		private interviewerService: InterviewerService,
	) { }

	public addForm: FormGroup = this.formBuilder.group({
		positionId: [this.foundInterview ? this.foundInterview.application?.position?.positionId : '', [Validators.required]],
		interviewerId: [this.foundInterview ? this.foundInterview.interviewerId : '', [Validators.required]],
		applicationId: [this.foundInterview ? this.foundInterview.applicationId : '', [Validators.required]],
		priority: [this.foundInterview ? this.foundInterview.priority : '', []],
		notes: [this.foundInterview ? this.foundInterview.notes : '', []],
		onlineMeeting: [false, [Validators.required]],
		addressOrStartURL: [this.foundInterview ? this.foundInterview.addressOrStartURL : '', [Validators.required]],
		detailLocationOrJoinURL: [this.foundInterview ? this.foundInterview.detailLocationOrJoinURL : '', [Validators.required]],
		meetingDate: [this.foundInterview ? this.foundInterview.meetingDate : '', [Validators.required, GreaterOrEqualToDay()]],
		startTime: [this.foundInterview ? this.foundInterview.startTime : '', [Validators.required]],
		endTime: [this.foundInterview ? this.foundInterview.endTime : '', [Validators.required]],
	}, { validator: timeValidator('startTime', 'endTime') });

	private interviewerId = this.data ? this.data.interviewerId : '';
	private applicationId = this.data ? this.data.applicationId : '';
	private positionId = this.data ? this.data.positionId : '';
	private recruiter: Recruiter = this.data ? this.data.recruiter : undefined;
	public foundInterview?: Interview = this.data ? this.data.interview : undefined;
	public positionData$ = this.positionService.getAllPositions(undefined, undefined, undefined, undefined, this.recruiter.recruiterId);
	private positionData?: Position[];
	public applicationData$!: Observable<any>;
	public applicationData?: Application[];
	public positionIdSubject = new Subject<any>();
	public showApplicationAutocomplete = false;
	public interviewerData$ = this.interviewerService.getAll(this.recruiter.companyId);
	public openStreetMapData? = null
	public isEditing = false;

	ngOnInit(): void {
		// console.log('foundInterview', this.foundInterview ? this.foundInterview : ': undefine')

		// console.log('this.addForm.value', this.addForm.value)
		// console.log('call api googlleeeeeeee')
		// this.openStreetMapService.search('võ văn ngân').subscribe((data: any) => {
		// 	console.log('open street map data', data)
		// 	this.openStreetMapData = data;
		// })
		if (this.interviewerId)
			this.addForm.get('interviewerId')?.setValue(this.interviewerId);

		if (this.foundInterview) {
			this.addForm.patchValue({
				positionId: this.foundInterview.application?.position?.positionId,
				interviewerId: this.foundInterview.interviewerId,
				applicationId: this.foundInterview.applicationId,
				priority: this.foundInterview.priority,
				notes: this.foundInterview.notes,
				addressOrStartURL: this.foundInterview.addressOrStartURL,
				detailLocationOrJoinURL: this.foundInterview.detailLocationOrJoinURL,
				meetingDate: this.foundInterview.meetingDate,
				startTime: this.foundInterview.startTime,
				endTime: this.foundInterview.endTime,
			});
			this.applicationData$ = this.applicationService.getAllByPositionId(this.foundInterview.application?.position?.positionId);
			this.showApplicationAutocomplete = true;
			this.addForm.disable();
		}

		this.addForm.get('priority')?.disable();

		this.positionData$.subscribe((data) => {
			this.positionData = data;
		})

		this.addForm.get('positionId')?.valueChanges.pipe(startWith(null), pairwise()).subscribe(([oldValue, newValue]: [any, any]) => {
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

		})

		this.addForm.get('applicationId')?.valueChanges.subscribe((newValue) => {
			if (this.applicationData?.map(e => e.applicationId).includes(newValue)) {
				// console.log('addform', newValue);
			}
		})

		this.positionIdSubject.pipe(debounceTime(300)).subscribe((positionId) => {
			// console.log('positionId', positionId)
			this.applicationService.getAllByPositionId(positionId).subscribe((data) => {
				this.applicationData = data;
			});
			this.applicationData$ = this.applicationService.getAllByPositionId(positionId);
			this.showApplicationAutocomplete = true;
		})


		if (this.applicationId) {
			// console.log('applicationId', this.applicationId)
			this.applicationData$ = this.applicationService.getAllByPositionId(this.positionId);
			this.addForm.get('positionId')?.setValue(this.positionId);
			this.addForm.get('applicationId')?.setValue(this.applicationId);
			this.showApplicationAutocomplete = true;
		}
		// this.addForm.get('positionName')?.valueChanges.subscribe((newValue: any) => {
		// 	console.log(newValue)
		// 	this.positionData$.subscribe((data) => this.positionData = data);
		// 	const foundPosition = this.positionData?.find(o => o.positionName === newValue);
		// 	console.log('Position data:', this.positionData)
		// 	console.log('foundPosition:', this.positionData)
		// 	this.applicationData$ = this.applicationService.getAllByPositionId(foundPosition?.positionId);
		// });

		this.addForm.get('onlineMeeting')?.valueChanges.subscribe((newData) => {
			if (newData === true) {
				const meetingDate = this.addForm.get('meetingDate')?.value;
				const startTime = this.addForm.get('startTime')?.value;
				const endTime = this.addForm.get('endTime')?.value;
				if (meetingDate === '' || startTime === '' || endTime === '') {
					this.addForm.patchValue({ onlineMeeting: false });
					this.toastr.error('Must have meeting date, start time and end time...', 'Missing Data Error!!!!!!', {
						toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
					});
					return;
				}
				this.addForm.get('addressOrStartURL')?.disable();
				this.addForm.get('detailLocationOrJoinURL')?.disable();
			}
			else {
				this.addForm.get('addressOrStartURL')?.enable();
				this.addForm.get('detailLocationOrJoinURL')?.enable();
			}
		})
	}

	private callApiCreateZoom() {
		const meetingDate = this.addForm.get('meetingDate')?.value;
		const startTime = this.addForm.get('startTime')?.value;
		const endTime = this.addForm.get('endTime')?.value;
		// console.log('meeting dateTime', this.createMeetingDateTime(meetingDate, startTime));
		// console.log('this.createDuration(startTime, endTime),', this.createDuration(startTime, endTime));
		const meetingData: ZoomMeeting = {
			topic: `${this.recruiter.company?.companyName} Interview`,
			default_password: false,
			type: 2,
			start_time: this.createMeetingDateTime(meetingDate, startTime),
			duration: this.createDuration(startTime, endTime),
			timezone: 'Asia/Saigon',
			agenda: `${this.recruiter.company?.companyName} Interview`,
			settings: {
				host_video: false,
				participant_video: false,
				join_before_host: true,
				mute_upon_entry: true,
				use_pmi: false,
				watermark: true,
				approval_type: 0,
				audio: 'both',
				auto_recording: "none",
				// alternative_hosts: this.recruiter.user?.email,
			}
		}
		return this.zoomService.callApiCreateScheduledMeeting(meetingData);
	}

	private createDuration(startTime: string, endTime: string) {
		// console.log('startTime', startTime)
		// console.log('endTime', endTime)
		let date1 = moment();
		date1.hour(Number(startTime.slice(0, 2)))
		date1.minute(Number(startTime.slice(3, 5)))
		let date2 = moment();
		date2.hour(Number(endTime.slice(0, 2)))
		date2.minute(Number(endTime.slice(3, 5)))
		return date2.diff(date1, 'minutes');
	}

	private createMeetingDateTime(date: string | Moment, time: string) {
		if (typeof date === 'string') {
			let convertToMoment = moment(date);
			convertToMoment.second(0);
			convertToMoment.hour(Number(time.slice(0, 2)));
			convertToMoment.minute(Number(time.slice(3, 5)));
			return convertToMoment.format('YYYY-MM-DDTHH:mm:ss');
		}
		if (moment.isMoment(date)) {
			date.second(0);
			date.hour(Number(time.slice(0, 2)))
			date.minute(Number(time.slice(3, 5)));
			return date.format('YYYY-MM-DDTHH:mm:ss');
		}
		return undefined;
	}

	public updateInterview() {
		const fieldValue = this.addForm.value;
		delete fieldValue.positionId;
		delete fieldValue.applicationId;
		fieldValue.recruiterId = this.recruiter.recruiterId;
		fieldValue.meetingDate = this.customDateTimeService.sameValueToUTC(fieldValue.meetingDate, true);
		this.interviewService.update(this.foundInterview?.interviewId ?? '', fieldValue).subscribe({
			next: () => {
				this.dialogRef.close();
				this.toastr.success('Interview updated...', 'Successfully!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
			error: () => {
				this.toastr.error('Something wrong...', 'Update interview Error!!!', {
					toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
				});
			},
		});
	}

	public saveInterview() {
		const fieldValue = this.addForm.value;
		fieldValue.recruiterId = this.recruiter.recruiterId;
		fieldValue.meetingDate = this.customDateTimeService.sameValueToUTC(fieldValue.meetingDate, true);
		if (fieldValue.onlineMeeting === true) {
			this.callApiCreateZoom().subscribe({
				next: (resp) => {
					this.toastr.success('Create meeting...', 'Successfully!', {
						toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
					});
					this.addForm.patchValue({ addressOrStartURL: resp.start_url })
					this.addForm.patchValue({ detailLocationOrJoinURL: resp.join_url })
					fieldValue.addressOrStartURL = resp.start_url;
					fieldValue.detailLocationOrJoinURL = resp.join_url;
					delete fieldValue.onlineMeeting;
					this.interviewService.save(fieldValue).subscribe({
						next: () => {
							this.dialogRef.close();
							this.toastr.success('Created interview...', 'Successfully!', {
								toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
							});
						},
						error: () => {
							this.toastr.error('Something wrong...', 'Save interview Error!!!', {
								toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
							});
						},
					})
				},
				error: () => {
					this.toastr.error('Something wrong...', 'Create meeting Error!!!', {
						toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
					});
				},
			});
		}
		else {
			this.interviewService.save(fieldValue).subscribe({
				next: () => {
					this.dialogRef.close();
					this.toastr.success('Created interview...', 'Successfully!', {
						toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
					});
				},
				error: () => {
					this.toastr.error('Something wrong...', 'Save interview Error!!!', {
						toastClass: ' my-custom-toast ngx-toastr', timeOut: 3000,
					});
				},
			})
		}

	}
}
