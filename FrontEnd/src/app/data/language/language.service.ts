import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Language } from './language.model';
import { API } from '../api.service';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {

  private api = inject(API);
  
  getAllLanguagues(): Observable<Language[]> {
    return this.api.GET('/api/Language');
  }
}
