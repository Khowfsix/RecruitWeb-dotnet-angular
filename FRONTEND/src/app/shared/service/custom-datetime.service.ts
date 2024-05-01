import { Injectable } from '@angular/core'
import moment, { Moment } from 'moment';
@Injectable({
	providedIn: 'root',
})
export class CustomDateTimeService {
	public sameValueToUTC(date: Moment, onlyDate: boolean = false) {
		if (!date || date === null)
			return null
		if (!moment.isMoment(date)) {
			return date;
		}
		if (onlyDate)
			return date.startOf('day').add(date.utcOffset(), 'minutes').toDate().toISOString();
		return date.add(date.utcOffset(), 'minutes').toDate().toISOString();
	}
}
