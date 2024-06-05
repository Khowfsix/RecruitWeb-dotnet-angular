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
		address: [this.foundInterview ? this.foundInterview.address : '', [Validators.required]],
		detailLocation: [this.foundInterview ? this.foundInterview.detailLocation : '', [Validators.required]],
		meetingDate: [this.foundInterview ? this.foundInterview.meetingDate : '', [Validators.required, GreaterOrEqualToDay()]],
		startTime: [this.foundInterview ? this.foundInterview.startTime : '', [Validators.required]],
		endTime: [this.foundInterview ? this.foundInterview.endTime : '', [Validators.required]],
	}, { validator: timeValidator('startTime', 'endTime') });

	private interviewerId = this.data ? this.data.interviewerId : '';
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
				address: this.foundInterview.address,
				detailLocation: this.foundInterview.detailLocation,
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

		})

		this.addForm.get('applicationId')?.valueChanges.subscribe((newValue) => {
			if (this.applicationData?.map(e => e.applicationId).includes(newValue)) {
				console.log('addform', newValue);
			}
		})

		this.positionIdSubject.pipe(debounceTime(300)).subscribe((positionId) => {
			console.log('positionId', positionId)
			this.applicationService.getAllByPositionId(positionId).subscribe((data) => {
				this.applicationData = data;
			});
			this.applicationData$ = this.applicationService.getAllByPositionId(positionId);
			this.showApplicationAutocomplete = true;
		})
		// this.addForm.get('positionName')?.valueChanges.subscribe((newValue: any) => {
		// 	console.log(newValue)
		// 	this.positionData$.subscribe((data) => this.positionData = data);
		// 	const foundPosition = this.positionData?.find(o => o.positionName === newValue);
		// 	console.log('Position data:', this.positionData)
		// 	console.log('foundPosition:', this.positionData)
		// 	this.applicationData$ = this.applicationService.getAllByPositionId(foundPosition?.positionId);
		// });
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
