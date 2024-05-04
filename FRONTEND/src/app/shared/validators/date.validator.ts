/* eslint-disable @typescript-eslint/no-explicit-any */
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import moment from 'moment';

export function GreaterOrEqualToDay(): ValidatorFn {
	return (control: AbstractControl): ValidationErrors | null => {
		let value = control.value;

		if (!value) {
			return null;
		}
		if (moment.isMoment(value)) {
			value = value.startOf('day').add(value.utcOffset(), 'minutes').toDate();
		}
		const currentDate = new Date();
		currentDate.setHours(0, 0, 0, 0);

		// console.log(value)
		value = new Date(value);
		value.setHours(0, 0, 0, 0);
		return value >= currentDate
			? null
			: { invalid: 'invalid value' };
	};
}

export function timeValidator(startFieldName: string, endFieldName: string) {
	return (control: AbstractControl): { [key: string]: any } | null => {
		const startTime = control.get(startFieldName)?.value;
		const endTime = control.get(endFieldName)?.value;

		if (startTime && endTime && startTime >= endTime) {
			return { 'invalidTimeRange': true };
		}

		return null;
	};
}

// export function timeValidator(control: AbstractControl,
// 	startFieldName: string, endFieldName: string): { [key: string]: any } | null {
// 	const startTime = control.get(startFieldName)?.value;
// 	const endTime = control.get(endFieldName)?.value;

// 	if (startTime && endTime && startTime >= endTime) {
// 		return { 'invalidTimeRange': true };
// 	}

// 	return null;
// }
