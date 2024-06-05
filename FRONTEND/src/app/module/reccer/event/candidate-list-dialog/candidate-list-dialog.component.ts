/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CandidateJoinEventService } from '../../../../data/candidateJoinEvent/candidate-join-event.service';
import { CandidateJoinEvent } from '../../../../data/candidateJoinEvent/candidate-join-event.model';
import { debounceTime } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
	selector: 'app-candidate-list-dialog',
	standalone: true,
	imports: [
		ReactiveFormsModule,
		CommonModule
	],
	templateUrl: './candidate-list-dialog.component.html',
	styleUrl: './candidate-list-dialog.component.css'
})
export class CandidateListDialogComponent implements OnInit {
	constructor(
		@Inject(MAT_DIALOG_DATA) public data: any,
		private formBuilder: FormBuilder,
		public dialogRef: MatDialogRef<CandidateListDialogComponent>,
		private candidateJoinEventService: CandidateJoinEventService
	) { }

	private eventId = this.data ? this.data.eventId : '';
	public fetchedCandidateJoinEvent?: CandidateJoinEvent[];
	public filterForm: FormGroup = this.formBuilder.group({
		search: ['', []],
	});
	public searchFormControl = this.filterForm.get('search') as FormControl;

	private callApiGetAllCandidateJoinEventByEventId() {
		this.candidateJoinEventService.getAllByEventId(this.eventId, this.filterForm.value.search).subscribe((resp) => {
			this.fetchedCandidateJoinEvent = resp;
			console.log('resp', resp)
		})
	}

	ngOnInit(): void {
		this.callApiGetAllCandidateJoinEventByEventId();
		this.filterForm.valueChanges.pipe(debounceTime(300)).subscribe(() => {
			this.callApiGetAllCandidateJoinEventByEventId();
		})
	}
}
