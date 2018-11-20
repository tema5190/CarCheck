import { AuthService } from './auth.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { AppConstants } from 'src/app/app.contans';

@Injectable()
export class ApiService {

    constructor(private _httpClient: HttpClient, private _authService: AuthService) { }

    public get<T>(method: string, params?: any): Observable<T> {
        return this._httpClient.get<T>(this.baseAndMethod(method), {
            params: params,
            headers: this.createHeadersRegardToken()
        });
    }

    public post<T>(method: string, params?: any): Observable<T> {
        return this._httpClient.post<T>(this.baseAndMethod(method), params, {
            headers: this.createHeadersRegardToken()
        });
    }

    public put<T>(method: string, params?: any): Observable<T> {
        return this._httpClient.put<T>(this.baseAndMethod(method), params, {
            headers: this.createHeadersRegardToken()
        });
    }


    public delete<T>(method: string, params?: any): Observable<T> {
        return this._httpClient.delete<T>(this.baseAndMethod(method), {
            params: params,
            headers: this.createHeadersRegardToken()
        });
    }

    private createHeadersRegardToken(): HttpHeaders {
        if (this._authService.getAuthToken()) {
            return new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this._authService.getAuthToken()}`
            });
        }
        return new HttpHeaders({
            'Content-Type': 'application/json',
        });
    }

    private baseAndMethod(method: string) {
        return `${AppConstants.API_URL}/${method}`;
    }
}
