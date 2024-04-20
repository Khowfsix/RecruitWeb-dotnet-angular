/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Input } from '@angular/core';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
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
	public fieldName?: string;
	@Input({ required: true })
	public placeholder?: string;
	@Input({ required: true })
	public label?: string;
	@Input({ required: true })
	public observableOptions?: Observable<any[]>;
	@Input({ required: true })
	public formGroup?: FormGroup;

	public filteredOptions?: Observable<any[]>;
	public options?: any[];

	ngOnInit(): void {
		this.observableOptions?.subscribe((data) => {
			this.options = data;
			this.filteredOptions = this.formGroup?.get(this.fieldName ?? '')?.valueChanges.pipe(
				startWith(''),
				map(value => this._filter(value || '')),
			);
		});
	}

	public isDisabled = false;

	public clear() {
		this.isDisabled = false;
		this.formGroup?.get(this.fieldName ?? '')?.setValue('');
	}

	public _filter(value: string): any[] {
		const filterValue = value.toLowerCase();
		return this.options?.filter(option => option[this.fieldName ?? ""].toLowerCase().includes(filterValue)) || [];
	}
}
