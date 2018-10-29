import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpRequest, HttpErrorResponse, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { empty, Observable, throwError, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class HttpRequestInterceptor implements HttpInterceptor {

    constructor(
        private router: Router
    ) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            catchError(
                (error: HttpErrorResponse, caught: Observable<HttpEvent<HttpErrorResponse>>) => {

                    if (error.status === 401) {
                        this.router.navigate(['/login']);
                        return of<HttpEvent<HttpErrorResponse>>();
                    }

                    if (error.status === 403) {
                        this.router.navigate(['/forbidden']);
                        return of<HttpEvent<HttpErrorResponse>>();
                    }
                    return throwError(error);
                }
            )
        );
    }
}