/* eslint-disable @typescript-eslint/no-explicit-any */
import { AsyncPipe, CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatSliderModule } from '@angular/material/slider';
import { MatExpansionModule } from '@angular/material/expansion';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { ChipsAutocompleteComponent } from '../../../shared/component/inputs/chips-autocomplete/chips-autocomplete.component';
import { CategoryPositionService } from '../../../data/categoryPosition/category-position.service';
import { LanguageService } from '../../../data/language/language.service';
import { CompanyService } from '../../../data/company/company.service';
import { PositionService } from '../../../data/position/position.service';
import { MatRippleModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';

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
		MatIconModule,
		MatRippleModule,
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
		{ provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
		{ provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
	],
	templateUrl: './filter.component.html',
	styleUrl: './filter.component.css'
})
export class FilterComponent implements OnInit {
	@Input({ required: true })
	public formGroup: FormGroup<any> = new FormGroup<any>({});

	public panelOpenState = false;

	public maxSalary?: number;
	public salaryStep?: number;

	public maxMaxHiringQty?: number;
	public maxHiringQtyStep?: number;

	constructor(
		public categoryPositionService: CategoryPositionService,
		public languageService: LanguageService,
		public companyService: CompanyService,
		public positionService: PositionService,
	) { }

	getMyControl(formField: string): FormControl {
		return this.formGroup.get(formField) as FormControl;
	}

	ngOnInit(): void {
		this.positionService.getAllMinMaxRange().subscribe((data) => {
			const maxSalary = data.maxSalary;
			for (let index = 1; ; index++) {
				if (10 ** index >= maxSalary) {
					this.maxSalary = (Math.floor(maxSalary / 10 ** (index - 1)) + 1) * 10 ** (index - 1);
					this.salaryStep = 10 ** (index - 1);
					break;
				}
			}

			const maxMaxHiringQty = data.maxMaxHiringQty;
			for (let index = 1; ; index++) {
				if (10 ** index >= maxMaxHiringQty) {
					this.maxMaxHiringQty = (Math.floor(maxMaxHiringQty / 10 ** (index - 1)) + 1) * 10 ** (index - 1);
					this.maxHiringQtyStep = 10 ** (index - 1);
					break;
				}
			}

			this.formGroup.get('fromSalary')?.setValue(0);
			this.formGroup.get('toSalary')?.setValue(this.maxSalary);
			this.formGroup.get('fromMaxHiringQty')?.setValue(0);
			this.formGroup.get('toMaxHiringQty')?.setValue(this.maxMaxHiringQty);
		});
	}


	formatLabel(value: number): string {
		if (value >= 1000) {
			return Math.round(value / 1000) + 'k';
		}

		return `${value}`;
	}

	public fromSalaryValue?: number;
	public toSalaryValue?: number;
	public fromMaxHiringQtyValue?: number;
	public toMaxHiringQtyValue?: number;
}

