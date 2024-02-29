import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseUrl = 'https://localhost:7029';
// const baseUrl = 'https://jasminerecruitmentweb.azurewebsites.net';

@Injectable({
  providedIn: 'root'
})
export class API {

  tempJWT = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiQURNSU5qYXNtaW5lIiwianRpIjoiNDgzNWIwNDktYzZkZC00NDE3LTg1NzktYjYzYzcyMjBiNmEwIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE3MTI3MzMyNTEsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcwMjkifQ.UxE9pkFekp_prxg1GTbg4wD5hWILBqRlVyrVOlLlm3c';

  constructor(private http: HttpClient) { }

  public GET(path: string): Observable<any[]> {
    return this.http.get<any[]>(baseUrl + path, { headers: {'Authorization':'Bearer ' + this.tempJWT} });
  }

  public POST(path: string, data: any): Observable<any> {
    return this.http.post(baseUrl + path, data);
  }

  public PUT(path: string, data: any): Observable<any> {
    return this.http.put(baseUrl + path, data);
  }

  public DELETE(path: string): Observable<any> {
    return this.http.delete(baseUrl + path);
  }
}