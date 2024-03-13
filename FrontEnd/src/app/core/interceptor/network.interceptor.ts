import { Injectable } from '@angular/core';
import {
	HttpRequest,
	HttpHandler,
	HttpEvent,
	HttpInterceptor,
	HTTP_INTERCEPTORS,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { LoadingService } from '../../shared/service/loading.service';

@Injectable()
class NetworkInterceptor implements HttpInterceptor {

	totalRequests = 0;
	requestsCompleted = 0;

	constructor(private loader: LoadingService) { }

	intercept(
		request: HttpRequest<unknown>,
		next: HttpHandler
	): Observable<HttpEvent<unknown>> {

		this.loader.show();
		this.totalRequests++;

		return next.handle(request).pipe(
			finalize(() => {
				this.requestsCompleted++;

				// console.log(this.requestsCompleted, this.totalRequests);

				if (this.requestsCompleted === this.totalRequests) {
					this.loader.hide();
					this.totalRequests = 0;
					this.requestsCompleted = 0;
				}
			})
		);
	}
}

export const NetworkInterceptorProvider = {
	provide: HTTP_INTERCEPTORS,
	useClass: NetworkInterceptor,
	multi: true,
};
