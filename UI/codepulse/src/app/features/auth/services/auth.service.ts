import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LoginRequestModel } from '../models/login-request-model';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginResponseModel } from '../models/login-response-model';
import { User } from '../models/user-model';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  $user = new BehaviorSubject<User | undefined>(undefined);

  constructor(private http:HttpClient,private cookieService:CookieService) { }

  apiUrl = environment.apiBaseUrl;

  Login(loginrequest:LoginRequestModel): Observable<LoginResponseModel>{
    return this.http.post<LoginResponseModel>(`${this.apiUrl}/api/auth/login`, {userName: loginrequest.email, password: loginrequest.password});
  }

  setUser(user:User):void {
    this.$user.next(user);
    localStorage.setItem('user-email', user.email);
    localStorage.setItem('user-roles', user.roles.join(','));
  }

  user():Observable<User | undefined> {
    return this.$user.asObservable();
  }

  logOut():void {
    //remove cookie
    this.cookieService.delete('Authorization','/');
    localStorage.clear();
    this.$user.next(undefined);
  }

  getUser(): User | undefined {
    const email = localStorage.getItem('user-email');
    const roles = localStorage.getItem('user-roles');
    if(email && roles) {
      return {email, roles: roles.split(',')};
    }
    return undefined;
  }

}
