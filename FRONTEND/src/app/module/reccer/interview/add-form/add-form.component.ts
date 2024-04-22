/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Position } from '../../../../data/position/position.model';
import { AutocompleteComponent } from "../../../../shared/component/inputs/autocomplete/autocomplete.component";
import { PositionService } from '../../../../data/position/position.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApplicationService } from '../../../../data/application/application.service';
import { Observable } from 'rxjs';

@Component({
	selector: 'app-add-form',
	standalone: true,
	templateUrl: './add-form.component.html',
	styleUrl: './add-form.component.css',
	imports: [AutocompleteComponent]
})
export class AddFormComponent implements OnInit {
	constructor(
		@Inject(MAT_DIALOG_DATA) public data: any,
		private formBuilder: FormBuilder,
		private positionService: PositionService,
		private applicationService: ApplicationService,
	) { }

	public addForm: FormGroup = this.formBuilder.group({
		positionId: ['', []],
		applicationId: ['', []],
	});
	private recruiterId = this.data ? this.data.recruiterId : undefined;
	public positionData$ = this.positionService.getAllPositions(undefined, undefined, undefined, undefined, this.recruiterId);
	private positionData?: Position[];
	public applicationData$!: Observable<any>;
	// public positionsData: Position[] = this.data ? this.data.positionsData : [];

	ngOnInit(): void {
		this.addForm.valueChanges.subscribe((newValue) => console.log('addform', newValue))
		// this.addForm.get('positionName')?.valueChanges.subscribe((newValue: any) => {
		// 	console.log(newValue)
		// 	this.positionData$.subscribe((data) => this.positionData = data);
		// 	const foundPosition = this.positionData?.find(o => o.positionName === newValue);
		// 	console.log('Position data:', this.positionData)
		// 	console.log('foundPosition:', this.positionData)
		// 	this.applicationData$ = this.applicationService.getAllByPositionId(foundPosition?.positionId);
		// });
	}
}
