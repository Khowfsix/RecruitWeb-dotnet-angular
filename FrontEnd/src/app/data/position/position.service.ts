import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Position } from './position.model';
import { API } from '../api.service';

@Injectable({
	providedIn: 'root',
})
export class PositionService {
	constructor(private api: API) { }

	getAllPositions(): Observable<Position[]> {
		return this.api.GET('/api/Position');
	}

	getAllPositionsByCurrentUser(): Observable<Position[]> {
		return this.api.GET('/api/Position/CurrentUser');
	}

	getById(id: string): Observable<Position> {
		return this.api.GET(`/api/Position/GetPositionById?positionId=${id}`);
	}

	create(data: any, options?: any): Observable<any> {
		console.log('data:......', data);
		return this.api.POST('/api/Position', data, options);
	}

	update(id: string, data: any): Observable<any> {
		return this.api.PUT(`/api/Position/${id}`, data);
	}

	delete(id: string): Observable<any> {
		return this.api.DELETE('/api/Position/' + id);
	}

	// deleteAll(): Observable<any> {
	//   return this.http.delete(baseUrl);
	// }

	// findByTitle(title: any): Observable<Position[]> {
	//   return this.http.get<Position[]>(`${baseUrl}?title=${title}`);
	// }
}
