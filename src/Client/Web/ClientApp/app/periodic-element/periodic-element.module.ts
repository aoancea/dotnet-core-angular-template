import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CoreModule } from '../core/core.module';
import { AngularMaterialModule } from '../shared/angular-material.module';

import { AuthenticationGuard } from '../core/guards/authentication.guard';

import { PeriodicElementListComponent } from './periodic-element-list/periodic-element-list.component';
import { PeriodicElementEditComponent } from './periodic-element-edit/periodic-element-edit.component';

import { PeriodicElementService } from './periodic-element.service';

const routes: Routes = [
    {
        path: '', component: PeriodicElementListComponent, data: { navArea: 'periodic-elements' },
        children: [
            { path: 'periodic-element-edit/:id', component: PeriodicElementEditComponent, canActivate: [AuthenticationGuard] },
            { path: 'periodic-element-edit', component: PeriodicElementEditComponent, canActivate: [AuthenticationGuard] },
        ]
    }
];

@NgModule({
    declarations: [
        PeriodicElementListComponent,
        PeriodicElementEditComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        CoreModule,
        AngularMaterialModule,
        ReactiveFormsModule,
        RouterModule.forChild(routes)
    ],
    providers: [PeriodicElementService]
})
export class PeriodicElementModule { }