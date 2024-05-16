import { Component } from '@angular/core';
import {
	FormBuilder,
	FormControl,
	FormGroup,
	FormsModule,
	ReactiveFormsModule,
} from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
	selector: 'app-event',
	standalone: true,
	imports: [
		FormsModule,
		MatFormFieldModule,
		MatInputModule,
		ReactiveFormsModule
	],
	templateUrl: './event.component.html',
	styleUrl: './event.component.css'
})
export class EventComponent {
	constructor(
		private formBuilder: FormBuilder,
	) { }


	public filterForm: FormGroup = this.formBuilder.group({
		search: ['', []],
		sortString: ['StartDateTime_DESC', []],
		// onlyMine: [false, []],
		// companyStatus: ['', []],
		// fromTime: ['', []],
		// toTime: ['', []],
		// fromDate: [null, []],
		// toDate: [null, []],
	});

	public searchFormControl = this.filterForm.get('search') as FormControl;
}
