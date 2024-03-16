import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LoginRequestModel } from '../models/login-request-model';
import { Observable } from 'rxjs';
import { LoginResponseModel } from '../models/login-response-model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient) { }

  apiUrl = environment.apiBaseUrl;

  Login(loginrequest:LoginRequestModel): Observable<LoginResponseModel>{
    return this.http.post<LoginResponseModel>(`${this.apiUrl}/api/auth/login`, {userName: loginrequest.email, password: loginrequest.password});
  }
}
