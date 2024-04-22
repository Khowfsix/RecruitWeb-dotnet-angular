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
				if (this.formGroup.disabled) {
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
			let isEdit = false;
			if (this.formGroup.get(this.valueField)?.value) {
				const foundOptions = data?.find(e => e[this.valueField] === this.formGroup.get(this.valueField)?.value)
				this.autocompleFormGroup.setValue({ search: foundOptions[this.labelField] })
				isEdit = true;
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
			// console.log(`this.formGroup.get(${this.valueField})?.value`, this.formGroup.get(this.valueField)?.value)
			// console.log('data', data)
		});

	}

	public isDisabled = false;

	public onSelectionChange(event: any) {
		const selectedValue = event.source.value;
		const foundOption = this.options?.find(o => o[this.valueField] === selectedValue)
		// console.log('selectedValue', selectedValue)
		// console.log('foundOption[this.valueField])', foundOption[this.valueField])
		this.isDisabled = true;
		this.autocompleFormGroup.get('search')?.setValue(foundOption[this.labelField])
		if (this.valueField)
			this.formGroup.get(this.valueField)?.setValue(selectedValue);

		// const selectedValue = event.source.value;
		// const foundOption = this.options?.find(o => o[this.labelField] === selectedValue)
		// console.log('selectedValue', selectedValue)
		// console.log('foundOption[this.valueField])', foundOption[this.valueField])
		// this.isDisabled = true;
		// if (this.valueField)
		// 	this.formGroup.get(this.valueField)?.setValue(foundOption[this.valueField]);
	}

	public clear() {
		this.isDisabled = false;
		this.formGroup?.get(this.valueField ?? '')?.setValue('');
		this.autocompleFormGroup?.get('search')?.setValue('');
	}

	public _filter(value: string): any[] {
		const filterValue = value.toLowerCase();
		// console.log('filter value: ', filterValue)
		return this.options?.filter(option => (option[this.labelField ?? ""].toLowerCase().includes(filterValue))) || [];
	}
}
