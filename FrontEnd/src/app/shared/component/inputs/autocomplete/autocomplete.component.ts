/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Input, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { AsyncPipe } from '@angular/common';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
	selector: 'app-autocomplete',
	standalone: true,
	imports: [
		FormsModule,
		MatFormFieldModule,
		MatInputModule,
		MatAutocompleteModule,
		ReactiveFormsModule,
		AsyncPipe,
	],
	templateUrl: './autocomplete.component.html',
	styleUrl: './autocomplete.component.css'
})

export class AutocompleteComponent {
	@Input({ required: true })
	public valueField!: string;
	@Input({ required: true })
	public labelField!: string;
	@Input()
	public placeholder?: string;
	@Input({ required: true })
	public label!: string;
	@Input({ required: true })
	public observableOptions!: Observable<any[]>;
	@Input({ required: true })
	public formField!: string;
	@Input({ required: true })
	public formGroup!: FormGroup;

	public filteredOptions?: Observable<any[]>;
	public options?: any[];

	constructor(
		private formBuilder: FormBuilder,
	) { }

	public autocompleFormGroup = this.formBuilder.group({
		search: ['', []]
	});

	ngOnChanges(changes: SimpleChanges): void {
		if (changes['formGroup'] && changes['formGroup'].currentValue) {
			this.formGroup.valueChanges.subscribe(() => {
				if (this.formGroup.get(this.formField)?.disabled) {
					this.autocompleFormGroup.disable();
					this.isDisabled = true;
				} else {
					this.autocompleFormGroup.enable();
				}
			});
		}
	}

	ngOnInit(): void {
		this.observableOptions?.subscribe((data) => {
			this.options = data;

			// console.log('this.options!.map(e => this.getLabelFieldValue(e)))', this.options!.map(e => this.getLabelFieldValue(e)))

			let isEdit = false;
			if (this.formGroup.get(this.formField)?.value) {
				const foundOption = data?.find(e => this.getValueFieldValue(e) === this.formGroup.get(this.formField)?.value)
				this.autocompleFormGroup.setValue({ search: this.getLabelFieldValue(foundOption) })
				isEdit = true;
				if (this.formGroup.get(this.formField)?.disabled) {
					this.isDisabled = true;
					this.autocompleFormGroup.disable()
				}
			}
			this.filteredOptions = this.autocompleFormGroup?.get('search')?.valueChanges.pipe(
				startWith(''),
				map(value => {
					if (isEdit) {
						isEdit = false;
						return []
					}
					return this._filter(value || '');
				}),
			);
		});

	}

	public getValueFieldValue(item: any): string {
		const fields = this.valueField.split('.');
		let fieldValue = item;
		for (const field of fields) {
			fieldValue = fieldValue[field];
		}
		return fieldValue;
	}

	public getLabelFieldValue(item: any): string {
		const fields = this.labelField.split('.');
		let fieldValue = item;
		for (const field of fields) {
			fieldValue = fieldValue[field];
		}
		return fieldValue;
	}

	public isDisabled = false;

	public onSelectionChange(event: any) {
		const selectedValue = event.source.value;
		const foundOption = this.options?.find(o => this.getValueFieldValue(o) === selectedValue)
		// console.log('selectedValue', selectedValue)
		// console.log('foundOption[this.valueField])', foundOption[this.valueField])
		this.isDisabled = true;
		this.autocompleFormGroup.get('search')?.setValue(this.getLabelFieldValue(foundOption))
		this.formGroup.get(this.formField)?.setValue(selectedValue);
	}

	public clear() {
		this.isDisabled = false;
		this.formGroup.get(this.formField)?.setValue('');
		this.autocompleFormGroup?.get('search')?.setValue('');
	}

	public _filter(value: string): any[] {
		const filterValue = value.toLowerCase();
		// console.log('filter value: ', filterValue)
		return this.options?.filter(option => (this.getLabelFieldValue(option).toLowerCase().includes(filterValue))) || [];
	}
}
