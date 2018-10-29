import { NgModule } from '@angular/core';

import {
    MatSlideToggleModule,
    MatListModule,
    MatTableModule
} from '@angular/material';

@NgModule({
    imports: [
        MatSlideToggleModule,
        MatListModule,
        MatTableModule
    ],
    exports: [
        MatSlideToggleModule,
        MatListModule,
        MatTableModule
    ],
    providers: [
    ],
})
export class AngularMaterialModule { }