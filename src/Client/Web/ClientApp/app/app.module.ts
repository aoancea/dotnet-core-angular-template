import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
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

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent,
        PeriodicElementListComponent,
        PeriodicElementEditComponent
    ],
    imports: [
        BrowserAnimationsModule,
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'periodic-elements', component: PeriodicElementListComponent },
            { path: 'periodic-element-edit/:position', component: PeriodicElementEditComponent },
        ]),
        AngularMaterialModule,
        CoreModule
    ],
    exports: [
        AngularMaterialModule,
        CoreModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
