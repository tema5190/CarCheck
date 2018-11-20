import { LoginResult } from './../../models/login/login.models';
import { AuthService } from 'src/app/shared/services/auth.service';
import { Component } from '@angular/core';
import { LoginModel } from 'src/app/models/login/login.models';
import { Router } from '@angular/router';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
})
export class LoginComponent {

    public email: string;
    public password: string;

    constructor(private _authService: AuthService, private router: Router) {

    }

    public login(email: string, password: string, confirmPassword: string) {
        const loginModel = new LoginModel();
        loginModel.email = this.email;
        loginModel.password = this.password;
        this._authService.login(loginModel).subscribe((loginResult: LoginResult) => {
            if (loginResult.isSuccess) {
                this.router.navigate(['/dashboard']);
            }
        });
    }
}
