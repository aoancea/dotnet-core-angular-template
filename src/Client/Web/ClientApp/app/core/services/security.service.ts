import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observer, Observable } from 'rxjs';

import { Token, RegisterModel, LoginModel } from './security.models';
import { TokenService } from './token.service';

@Injectable()
export class SecurityService {

    constructor(
        private httpClient: HttpClient,
        private tokenService: TokenService,
        @Inject('BASE_URL') private baseUrl: string) {
    }

    register(registerModel: RegisterModel) {
        return new Observable<Token>((obs: Observer<Token>) => {
            this.httpClient.post<Token>(`${this.baseUrl}Account/Register`, registerModel).subscribe(token => {

                this.tokenService.saveToken(token);

                obs.next(token);
                obs.complete();
            });
        });
    }

    login(registerModel: LoginModel) {
        return new Observable<Token>((obs: Observer<Token>) => {
            this.httpClient.post<Token>(`${this.baseUrl}Account/Login`, registerModel).subscribe(token => {

                this.tokenService.saveToken(token);

                obs.next(token);
                obs.complete();
            });
        });
    }
}