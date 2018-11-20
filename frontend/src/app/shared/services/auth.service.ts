import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { LoginResult, LoginModel } from 'src/app/models/login/login.models';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConstants } from 'src/app/app.contans';

@Injectable()
export class AuthService {

    constructor(private _httpClient: HttpClient) { }

    public get LoginData(): LoginResult {
        const rawData = localStorage.getItem('loginData');
        if (!rawData) { return null; }
        return JSON.parse(rawData) as LoginResult;
    }

    public getAuthToken(): string {
        if (this.isUserAuthentificated()) {
            return this.LoginData.jwtToken;
        }
        return null;
    }

    public isUserAuthentificated(): boolean {
        return this.LoginData != null;
    }

    public login(loginModel: LoginModel): Observable<LoginResult> {
        return this._httpClient.post<LoginResult>(`${AppConstants.API_URL}auth/authentificate`, loginModel).pipe(map(result => {
            if (result.isSuccess) {
                localStorage.setItem('loginData', JSON.stringify(result));
            }
            return result;
        }));
    }

    public logout(): void {
        localStorage.removeItem('loginData');
    }
}
