import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpResponse, HttpResponseGet } from '../models/HttpResponse';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
  })
export class ApiService<T> {
  constructor(private http: HttpClient) {}

  post(item: T, endpoint: string): Observable<any> {
    return this.http.post(`${endpoint}/create`, item);
  }

  put(item: T, endpoint: string): Observable<any> {
    return this.http.put(`${endpoint}/update`, item);
  }

  delete(id: number, endpoint: string): Observable<HttpResponse> {
    return this.http.delete<HttpResponse>(`${endpoint}/remove/${id}`);
  }

  get(id: number, endpoint: string): Observable<HttpResponseGet> {
    return this.http.get<HttpResponseGet>(`${endpoint}/get/${id}`);
  }

  getAll(endpoint: string): Observable<HttpResponse> {
    return this.http.get<HttpResponse>(`${endpoint}/get-all`);
  }
}
  
//   getEscalas() {
//     return this.http.get<HttpResponse>('https://localhost:7051/api/escales/get-all');