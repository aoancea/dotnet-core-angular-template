import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observer, Observable } from 'rxjs';

import { Token, RegisterModel, LoginModel } from './security.models';

@Injectable({
    providedIn: 'root'
})
export class SecurityService {

    constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }

    register(registerModel: RegisterModel) {
        return new Observable<Token>((obs: Observer<Token>) => {
            this.httpClient.post<Token>(`${this.baseUrl}Account/Register`, registerModel).subscribe(token => {
                localStorage.setItem('token', token.value);

                obs.next(token);
                obs.complete();
            });
        });
    }

    login(registerModel: LoginModel) {
        return new Observable<Token>((obs: Observer<Token>) => {
            this.httpClient.post<Token>(`${this.baseUrl}Account/Login`, registerModel).subscribe(token => {
                localStorage.setItem('token', token.value);

                obs.next(token);
                obs.complete();
            });
        });
    }
}