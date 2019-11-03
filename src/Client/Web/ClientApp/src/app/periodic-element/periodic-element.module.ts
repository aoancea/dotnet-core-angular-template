import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CoreModule } from '../core/core.module';
import { AngularMaterialModule } from '../shared/angular-material.module';

import { PeriodicElementService } from './periodic-element.service';

import { PeriodicElementRoutingModule } from './periodic-element-routing.module';

@NgModule({
    declarations: [PeriodicElementRoutingModule.routedComponents],
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        CoreModule,
        AngularMaterialModule,
        ReactiveFormsModule,
        PeriodicElementRoutingModule
    ],
    providers: [PeriodicElementService]
})
export class PeriodicElementModule { }