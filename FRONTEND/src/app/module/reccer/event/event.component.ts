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
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';

@Component({
	selector: 'app-event',
	standalone: true,
	imports: [
		MatIconModule,
		MatDividerModule,
		MatButtonModule,
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
