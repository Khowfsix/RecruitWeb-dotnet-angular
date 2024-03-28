/* eslint-disable @typescript-eslint/no-explicit-any */
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { Component, ElementRef, Input, OnInit, ViewChild, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteSelectedEvent, MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatChipInputEvent, MatChipsModule } from '@angular/material/chips';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { MatIconModule } from '@angular/material/icon';
import { AsyncPipe } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { LiveAnnouncer } from '@angular/cdk/a11y';

@Component({
	selector: 'app-chips-autocomplete',
	standalone: true,
	imports: [
		FormsModule,
		MatFormFieldModule,
		MatChipsModule,
		MatIconModule,
		MatAutocompleteModule,
		ReactiveFormsModule,
		AsyncPipe,
	],
	templateUrl: './chips-autocomplete.component.html',
	styleUrl: './chips-autocomplete.component.css'
})
export class ChipsAutocompleteComponent implements OnInit {

	separatorKeysCodes: number[] = [ENTER, COMMA];

	@Input({ required: true })
	public formGroup!: FormGroup;
	@Input({ required: true })
	public formField!: string;
	@Input({ required: true })
	public observableData?: Observable<any[]>;
	@Input({ required: true })
	public displayFieldName!: string;
	@Input({ required: true })
	public valueFieldName!: string;
	@Input({ required: true })
	public label!: string;
	@Input({ required: true })
	public placeholder!: string;

	public allData!: any[];
	public autocompleteCtrl = new FormControl('');
	public filteredDatas!: Observable<any[]>;
	public selectedData: any[] = [];
	public displaySelectedData: any[] = [];

	@ViewChild('chipsInput') chipsInput!: ElementRef<HTMLInputElement>;

	announcer = inject(LiveAnnouncer);

	ngOnInit(): void {
		this.observableData?.subscribe((data) => {
			this.allData = data;
			this.filteredDatas = this.autocompleteCtrl.valueChanges.pipe(
				startWith(null),
				map((search: string | null) => (search ? this._filter(search) : this.allData ? this.allData.map(x => x[this.displayFieldName]).filter(x => !this.displaySelectedData.includes(x)).slice() : [])),
			);
		});
	}

	add(event: MatChipInputEvent): void {
		const value = (event.value || '').trim();

		if (value) {
			this.displaySelectedData.push(value);
			this.selectedData.push(this.allData.find(item => item[this.displayFieldName] === value));
			this.formGroup.get(this.formField)?.setValue(this.selectedData.map(item => item[this.valueFieldName]).toString());
		}

		event.chipInput!.clear();

		this.autocompleteCtrl.setValue(null);
	}

	remove(data: string): void {
		const index = this.displaySelectedData.indexOf(data);

		if (index >= 0) {
			this.displaySelectedData.splice(index, 1);
			this.selectedData.splice(index, 1);
			this.formGroup.get(this.formField)?.setValue(this.selectedData.map(item => item[this.valueFieldName]).toString());
			this.announcer.announce(`Removed ${data}`);
			this.filteredDatas = this.autocompleteCtrl.valueChanges.pipe(
				startWith(null),
				map((search: string | null) => (search ? this._filter(search) : this.allData ? this.allData.map(x => x[this.displayFieldName]).filter(x => !this.displaySelectedData.includes(x)).slice() : [])),
			);
		}
	}

	selected(event: MatAutocompleteSelectedEvent): void {
		if (!this.displaySelectedData.includes(event.option.viewValue)) {
			this.displaySelectedData.push(event.option.viewValue);
			this.selectedData.push(this.allData.find(item => item[this.displayFieldName] === event.option.viewValue));
			this.formGroup.get(this.formField)?.setValue(this.selectedData.map(item => item[this.valueFieldName]).toString());
		}
		this.chipsInput.nativeElement.value = '';
		this.autocompleteCtrl.setValue(null);
	}

	private _filter(value: string): string[] {
		const filterValue = value.toLowerCase();
		const filteredData = this.allData.filter(item => item[this.displayFieldName].toLowerCase().includes(filterValue) && !this.displaySelectedData.includes(item[this.displayFieldName]));
		return filteredData.map(item => item[this.displayFieldName]);
	}
}
