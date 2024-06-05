/* eslint-disable prefer-const */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Input } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { AsyncPipe } from '@angular/common';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { combineLatest } from 'rxjs';
import { MatButtonModule } from '@angular/material/button';
import { ToastrService } from 'ngx-toastr';
import { Position } from '../../../../data/position/position.model';
import { PositionService } from '../../../../data/position/position.service';
import { AutocompleteComponent } from '../../../../shared/component/inputs/autocomplete/autocomplete.component';
import { AuthService } from '../../../../core/services/auth.service';
import { EventHasPosition } from '../../../../data/eventHasPosition/eventHasPosition.model';

@Component({
	selector: 'app-add-event-has-positions',
	standalone: true,
	imports: [
		FormsModule,
		AutocompleteComponent,
		MatFormFieldModule,
		MatInputModule,
		MatAutocompleteModule,
		ReactiveFormsModule,
		MatButtonModule,
		AsyncPipe,],
	templateUrl: './add-event-has-positions.component.html',
	styleUrl: './add-event-has-positions.component.css'
})
export class AddEventHasPositionsComponent {
	@Input({ required: true })
	public fieldName!: string;
	@Input({ required: true })
	public placeholder!: string;
	@Input({ required: true })
	public label!: string;
	@Input({ required: true })
	public formGroup!: FormGroup;
	@Input({ required: true })
	public isEditForm!: boolean;
	public isDisabled = false;
	public fetchPositions: Position[] = [];
	public displayEventHasPositions: EventHasPosition[] = [];
	public isUpdateEventHasPosition: boolean = false;
	public localstorageRecruiter = this.authService.getLocalCurrentUser().recruiters?.pop();
	public observablePositions = this.positionService.getAllPositions(undefined, undefined, undefined, undefined, this.localstorageRecruiter?.recruiterId);


	constructor(
		private positionService: PositionService,
		private formBuilder: FormBuilder,
		private toastr: ToastrService,
		private authService: AuthService,
	) { }

	public addForm: FormGroup = this.formBuilder.group({
		positionId: [
			'',
			[Validators.required]
		],
	});

	private setupValidators() {
		this.addForm
			.get('positionId')
			?.setValidators([
				Validators.required,
				this.isInAllowedValues(
					this.fetchPositions.map((x) => x.positionId),
				),
			]);

		this.addForm.get('positionId')?.updateValueAndValidity();
	}

	private isInAllowedValues(allowedValues: any[]): ValidatorFn {
		return (control: AbstractControl): ValidationErrors | null => {
			const value = control.value;

			if (!value) {
				return null;
			}

			return allowedValues.includes(value)
				? null
				: { invalid: 'invalid value' };
		};
	}

	ngOnInit(): void {
		if (this.isEditForm)
			this.displayEventHasPositions = this.formGroup?.get(this.fieldName)?.value;
		this.fetchAllPosition();

		combineLatest([
			this.observablePositions,
		]).subscribe(([positions]) => {
			this.fetchPositions = positions;
			this.setupValidators();
		});
	}

	public clearAllPositions() {
		this.displayEventHasPositions = [];
		this.formGroup?.get(this.fieldName)?.setValue([]);
		this.isUpdateEventHasPosition = false;
	}

	public getEventHasPosition(positionId: string) {
		const foundEventHasPosition = this.displayEventHasPositions.find(x => x.positionId === positionId);
		this.addForm.get('positionId')?.setValue(foundEventHasPosition?.positionId);
	}

	public removeEventHasPosition(positionId: string) {
		if (this.displayEventHasPositions.map(x => x.positionId).includes(this.addForm.get('positionId')?.value)) {
			this.isUpdateEventHasPosition = false;
		}
		this.displayEventHasPositions = this.displayEventHasPositions.filter(x => x.positionId !== positionId);
		const formatedPositions = this.displayEventHasPositions.map(x => {
			return {
				eventHasPositionId: '',
				eventId: '',
				positionId: x.positionId,
			}
		})
		this.formGroup?.get(this.fieldName)?.setValue(formatedPositions);
	}

	public addEventHasPositionToList(): void {
		let currentEventHasPositions: EventHasPosition[] | null = this.formGroup?.get(this.fieldName)?.value;

		const positionId = this.addForm.get('positionId')?.value;
		if (currentEventHasPositions?.map(x => x.positionId).includes(positionId)) {
			this.toastr.error('Position conflict !!!!', 'Error', {
				toastClass: ' my-custom-toast ngx-toastr'
			});
			return;
		}
		let eventHasPosition: any = {
			eventHasPositionId: '',
			eventId: '',
			positionId: positionId,
			position: {
				positionName: ""
			}
		}
		const updatedEventHasPositions = [...(currentEventHasPositions ?? []), eventHasPosition];
		this.formGroup?.get(this.fieldName ?? '')?.setValue(updatedEventHasPositions);

		const displayEventHasPosition = {
			...eventHasPosition,
			position: {
				positionName: this.fetchPositions?.find(e => e.positionId === this.addForm.get('positionId')?.value)?.positionName,
			}
		}
		this.displayEventHasPositions.push(displayEventHasPosition);
		// console.log('this.formGroup?.get(this.fieldName)?.value', this.formGroup?.get(this.fieldName ?? '')?.value);
	}

	private fetchAllPosition() {
		this.positionService.getAllPositions().subscribe({
			next: (data: any) => {
				this.fetchPositions = data;
				if (this.isEditForm)
					if (this.displayEventHasPositions) {
						this.displayEventHasPositions = this.displayEventHasPositions.map(x => ({
							eventHasPositionId: x.eventHasPositionId,
							positionId: x.positionId,
							eventId: x.eventId,
							position: { positionName: this.fetchPositions?.find(y => y.positionId === x.positionId)?.positionName },
						}))
					}
			},
		}
		);
	}
}
