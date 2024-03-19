import { Component } from '@angular/core';
import { LoginRequestModel } from '../models/login-request-model';
import { AuthService } from '../services/auth.service';
import { LoginResponseModel } from '../models/login-response-model';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { User } from '../models/user-model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginModel: LoginRequestModel = { email: '', password: '' };
  loginResponse: LoginResponseModel;

  constructor(private authService: AuthService, private cookieService: CookieService, private router: Router) {
    this.loginModel.email = '';
    this.loginModel.password = '';
    this.loginResponse = { token: '', email: '', roles: [] };
  }

  onFormSubmit(): void {
    this.authService.Login(this.loginModel).subscribe((data: any) => {
      this.loginResponse = data;
      console.log(this.loginResponse);
      //Set Auth Cookie
      this.cookieService.set('Authorization', `Bearer ${this.loginResponse.token}`, undefined, '/', undefined, true,);

      //Set user data
      const user: User = {
        email: this.loginResponse.email,
        roles: this.loginResponse.roles
      };
      this.authService.setUser(user);

      //Redirect to Home
      this.router.navigateByUrl('/');

    });
  }

}
