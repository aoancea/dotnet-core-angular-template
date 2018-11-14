import { Injectable, Inject } from '@angular/core';
import { Response, Headers, RequestOptions } from '@angular/http';

import { RegisterModel } from './registration-form.models';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class UserService {

    private loggedIn = false;

    constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        //this.loggedIn = !!localStorage.getItem('auth_token');
    }

    register(registerModel: RegisterModel) {
        return this.httpClient.post<any>(`${this.baseUrl}Account/Register`, registerModel, { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) });
    }

    //login(userName, password) {
    //    let headers = new Headers();
    //    headers.append('Content-Type', 'application/json');

    //    return this.http
    //        .post(
    //            this.baseUrl + '/auth/login',
    //            JSON.stringify({ userName, password }), { headers }
    //        )
    //        .map(res => res.json())
    //        .map(res => {
    //            localStorage.setItem('auth_token', res.auth_token);
    //            this.loggedIn = true;
    //            this._authNavStatusSource.next(true);
    //            return true;
    //        })
    //        .catch(this.handleError);
    //}

    //logout() {
    //    localStorage.removeItem('auth_token');
    //    this.loggedIn = false;
    //    this._authNavStatusSource.next(false);
    //}

    //isLoggedIn() {
    //    return this.loggedIn;
    //}
}