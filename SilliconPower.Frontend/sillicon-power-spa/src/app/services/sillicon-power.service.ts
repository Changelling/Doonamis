import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseUrl = 'https://localhost:5001/api';

@Injectable({
  providedIn: 'root'
})
export class SilliconPowerService {

  constructor(private http: HttpClient) { }

  register(data): Observable<any> {
    return this.http.post(`${baseUrl}/user/register`, data);
  }

}