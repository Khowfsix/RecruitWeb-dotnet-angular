import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Recruiter } from './recruiter.model';
import { API } from '../api.service';

@Injectable({
  providedIn: 'root'
})
export class RecruiterService {

  private api = inject(API);
  
  getRecruiterByUserId(userId: string): Observable<Recruiter> {
    return this.api.GET('/api/Recruiter/GetRecruiterByUserId/' + userId);
  }
}
