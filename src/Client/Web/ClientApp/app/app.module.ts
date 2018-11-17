import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { PeriodicElementListComponent } from './periodic-element/periodic-element-list/periodic-element-list.component';
import { PeriodicElementEditComponent } from './periodic-element/periodic-element-edit/periodic-element-edit.component';

import { AngularMaterialModule } from './shared/angular-material.module';
import { CoreModule } from './core/core.module';

import { AuthenticationGuard } from './core/guards/authentication.guard';

import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';

import { UserService } from './registration/registration.service';
import { LoginService } from './login/login.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent,
        PeriodicElementListComponent,
        PeriodicElementEditComponent,
        RegistrationComponent,
        LoginComponent
    ],
    imports: [
        BrowserAnimationsModule,
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'periodic-elements', component: PeriodicElementListComponent, canActivate: [AuthenticationGuard] },
            { path: 'periodic-element-edit/:id', component: PeriodicElementEditComponent, canActivate: [AuthenticationGuard] },
            { path: 'periodic-element-edit', component: PeriodicElementEditComponent, canActivate: [AuthenticationGuard] },

            { path: 'register', component: RegistrationComponent },
            { path: 'login', component: LoginComponent },
        ]),
        AngularMaterialModule,
        CoreModule
    ],
    exports: [
        AngularMaterialModule,
        CoreModule
    ],
    providers: [UserService, LoginService],
    bootstrap: [AppComponent]
})
export class AppModule { }
