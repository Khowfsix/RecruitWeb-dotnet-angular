import { Injectable } from '@angular/core'
import { Moment } from 'moment';

@Injectable({
	providedIn: 'root',
})
export class CustomDateTimeService {
	public sameValueToUTC(date: Moment, onlyDate: boolean = false) {
		if (!date || date === null)
			return null
		if (onlyDate)
			return date.startOf('day').add(date.utcOffset(), 'minutes').toDate().toISOString();
		return date.add(date.utcOffset(), 'minutes').toDate().toISOString();
	}
}
