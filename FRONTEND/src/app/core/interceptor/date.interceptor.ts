import { Injectable } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import moment from 'moment';

@Injectable()
export class DateInterceptor implements HttpInterceptor {

	intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		const clonedReq = req.clone({
			body: this.convertDatesToUtcMidnight(req.body)
		});

		return next.handle(clonedReq);
	}

	private convertDatesToUtcMidnight(body: any): any {
		if (body === null || body === undefined) {
			return body;
		}

		// Check if body is a moment object and if it's valid
		if (moment.isMoment(body) && body.isValid()) {
			// Convert to JavaScript Date then to UTC midnight
			return this.toUtcMidnight(body.toDate());
		}

		if (typeof body === 'object') {
			if (body instanceof Date) {
				// If it's already a Date, convert to UTC midnight
				return this.toUtcMidnight(body);
			} else if (Array.isArray(body)) {
				// If it's an array, apply the conversion to each element
				return body.map(item => this.convertDatesToUtcMidnight(item));
			} else {
				// If it's an object, apply the conversion to each date property
				const convertedBody = { ...body };
				Object.keys(convertedBody).forEach(key => {
					convertedBody[key] = this.convertDatesToUtcMidnight(body[key]);
				});
				return convertedBody;
			}
		}

		// If it's not an object, array, or Date, return it unmodified
		return body;
	}

	private toUtcMidnight(date: Date): string {
		const utcDate = new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate()));
		return utcDate.toISOString();
	}
}

export const DateInterceptorProvider = {
	provide: HTTP_INTERCEPTORS,
	useClass: DateInterceptor,
	multi: true,
};
