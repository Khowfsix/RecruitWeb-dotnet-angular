import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule } from '@angular/forms';

@Component({
	selector: 'app-dynamic-form',
	standalone: true,
	imports: [
		FormsModule,
		CommonModule
	],
	templateUrl: './dynamic-form.component.html',
})
export class DynamicFormComponent {
	@Input() OldData: object | null = null;
	@Input() dataInterface: any;

	dataFields: { key: string; label: string; type: string }[] = [];
	form: FormGroup = new FormGroup({});

	OnInit(): void {
		this.dataFields = this.getDataFields(this.dataInterface);
		this.form = new FormGroup({});

		this.dataFields.forEach(field => {
			this.form.addControl(field.key, new FormControl());
		});
	}

	getDataFields<T>(dataInterface: T): { key: string; label: string; type: string }[] {
		const dataFields: { key: string; label: string; type: string }[] = [];

		for (const property in dataInterface) {
			if (dataInterface.hasOwnPropertty(property)) {
				const propType = typeof dataInterface[property];
				dataFields.push({
					key: property,
					label: property[0].toUpperCase() + property.slice(1), // Capitalize label
					type: propType === 'string' ? 'text' : propType === 'number' ? 'number' : 'text' // Default type
				});
			}
		}
		return dataFields;
	}

	onSubmit() {
		console.log(this.form.value);
	}


}


