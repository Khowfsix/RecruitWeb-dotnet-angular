/* eslint-disable @typescript-eslint/no-explicit-any */
import { AsyncPipe, CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatSliderModule } from '@angular/material/slider';
import { MatExpansionModule } from '@angular/material/expansion';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { ChipsAutocompleteComponent } from '../../../../shared/component/inputs/chips-autocomplete/chips-autocomplete.component';
import { CategoryPositionService } from '../../../../data/categoryPosition/category-position.service';
import { LanguageService } from '../../../../data/language/language.service';
import { CompanyService } from '../../../../data/company/company.service';

export const MY_FORMATS = {
	parse: {
		dateInput: 'DD/MM/YYYY',
	},
	display: {
		dateInput: 'DD/MM/YYYY',
		monthYearLabel: 'YYYY',
		dateA11yLabel: 'LL',
		monthYearA11yLabel: 'YYYY',
	},
};

@Component({
	selector: 'app-filter',
	standalone: true,
	imports: [
		ChipsAutocompleteComponent,
		MatSliderModule,
		AsyncPipe,
		MatDatepickerModule,
		ReactiveFormsModule,
		MatInputModule,
		FormsModule,
		MatFormFieldModule,
		MatExpansionModule,
		MatButtonModule,
		MatMenuModule,
		CommonModule,
	],
	providers: [
		// provideNativeDateAdapter(),
		{ provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
		{ provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
	],
	templateUrl: './filter.component.html',
	styleUrl: './filter.component.css'
})
export class FilterComponent {
	@Input({ required: true })
	public formGroup: FormGroup<any> = new FormGroup<any>({});

	public panelOpenState = false;

	constructor(
		public categoryPositionService: CategoryPositionService,
		public languageService: LanguageService,
		public companyService: CompanyService,
	) { }
}

