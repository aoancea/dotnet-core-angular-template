import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AuthenticationGuard } from './guards/authentication.guard';

import { HttpRequestInterceptor } from './services/http-request-interceptor';

@NgModule({
    declarations: [
    ],
    imports: [],
    providers: [
        AuthenticationGuard,
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