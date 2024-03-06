import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Position } from './position.model';
import { API } from '../api.service';

@Injectable({
  providedIn: 'root'
})
export class PositionService {

  constructor(private api: API) { }

  getAllPositions(): Observable<Position[]> {
    return this.api.GET('/api/Position');
  }

  getAllPositionsByCurrentUser(): Observable<Position[]> {
    return this.api.GET('/api/Position/CurrentUser');
  }

  // get(id: any): Observable<Position> {
  //   return this.http.get<Position>(`${baseUrl}/${id}`);
  // }

  create(data: any): Observable<any> {
    console.log('data:......', data)
    return this.api.POST('/api/Position', data);
  }

  // update(id: any, data: any): Observable<any> {
  //   return this.http.put(`${baseUrl}/${id}`, data);
  // }

  delete(id: any): Observable<any> {
    return this.api.DELETE('/api/Position/'+id);
  }

  // deleteAll(): Observable<any> {
  //   return this.http.delete(baseUrl);
  // }

  // findByTitle(title: any): Observable<Position[]> {
  //   return this.http.get<Position[]>(`${baseUrl}?title=${title}`);
  // }
}