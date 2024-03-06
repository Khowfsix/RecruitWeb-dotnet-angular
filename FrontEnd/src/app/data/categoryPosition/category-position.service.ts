import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CategoryPosition } from './category-position.model';
import { API } from '../api.service';

@Injectable({
  providedIn: 'root'
})
export class CategoryPositionService {

  constructor(private api: API) { }

  getAllCategoryPositions(): Observable<CategoryPosition[]> {
    return this.api.GET('/api/CategoryPosition');
  }

  create(data: any): Observable<any> {
    // console.log('data:......', data)
    return this.api.POST('/api/CategoryPosition', data);
  }
}