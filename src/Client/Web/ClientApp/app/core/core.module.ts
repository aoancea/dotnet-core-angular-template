﻿import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AuthenticationGuard } from './guards/authentication.guard';

import { HttpRequestInterceptor } from './services/http-request-interceptor';

import { SecurityService } from './services/security.service';

@NgModule({
    declarations: [
    ],
    imports: [],
    providers: [
        AuthenticationGuard,
        SecurityService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: HttpRequestInterceptor,
            multi: true
        }
    ],
    exports: []
})

export class CoreModule {

}