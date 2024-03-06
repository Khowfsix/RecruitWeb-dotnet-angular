import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseUrl = 'https://localhost:7029';
// const baseUrl = 'https://jasminerecruitmentweb.azurewebsites.net';

@Injectable({
  providedIn: 'root'
})
export class API {
  //Admin JWT
  tempJWT = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiQWRtaW5lSmFzbWluZSIsImp0aSI6IjJjZTM1ODY0LWY5MjktNGU2OC1iNjU4LWFjY2E4ZDVmZmRiNiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNzEyOTg2MDAzLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo3MDI5In0.7-KCwSmDtV5fiLq2JQ04Ebyg_XDBtuvZfp6nGngm8gM';

  //Reccer JWT
  // tempJWT = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoibHlob25ncGhhdCIsImp0aSI6Ijg2MjY4YTU5LWI1ODQtNDI3My1hZGQ1LTM0MWVlYTliYWQ0MyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlJlY3J1aXRlciIsImV4cCI6MTcxMzMxOTMzMiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzAyOSJ9.oNvXTSk6750EQ_MmAXqSIKqUqJNcPGKB_ayNV2D2PIM';
  constructor(private http: HttpClient) { }

  public GET(path: string): Observable<any> {
    return this.http.get<any[]>(baseUrl + path, { headers: {'Authorization':'Bearer ' + this.tempJWT} });
  }

  public POST(path: string, data: any): Observable<any> {
    return this.http.post(baseUrl + path, data, { headers: {'Authorization':'Bearer ' + this.tempJWT}});
  }

  public PUT(path: string, data: any): Observable<any> {
    return this.http.put(baseUrl + path, data);
  }

  public DELETE(path: string): Observable<any> {
    return this.http.delete(baseUrl + path, { headers: {'Authorization':'Bearer ' + this.tempJWT}});
  }
}