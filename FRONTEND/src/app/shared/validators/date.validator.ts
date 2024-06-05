/* eslint-disable @typescript-eslint/no-explicit-any */
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import moment from 'moment';

export function GreaterOrEqualToDay(): ValidatorFn {
	return (control: AbstractControl): ValidationErrors | null => {
		let value = control.value;

		if (!value) {
			return null;
		}

		if (typeof value === 'string') {
			value = moment(value)
			value = value.startOf('day').add(value.utcOffset(), 'minutes').toDate();
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

export function dateValidator(startFieldName: string, endFieldName: string, allowEqual = false) {
	return (control: AbstractControl): { [key: string]: any } | null => {
		let startTime = control.get(startFieldName)?.value;
		let endTime = control.get(endFieldName)?.value;


		if (typeof startTime === 'string')
			startTime = moment(startTime)
		if (typeof endTime === 'string')
			endTime = moment(endTime)

		if (allowEqual) {
			if (startTime && endTime && startTime.toDate().setHours(0, 0, 0, 0) > endTime.toDate().setHours(0, 0, 0, 0)) {
				return { 'invalidDateRange': true };
			}
			return null
		}
		else {
			if (startTime && endTime && startTime.toDate().setHours(0, 0, 0, 0) >= endTime.toDate().setHours(0, 0, 0, 0)) {
				return { 'invalidDateRange': true };
			}

			return null;
		}


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
