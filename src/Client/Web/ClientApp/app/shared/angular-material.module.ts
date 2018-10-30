import { NgModule } from '@angular/core';

import {
    MatSlideToggleModule,
    MatListModule,
    MatTableModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule
} from '@angular/material';

@NgModule({
    imports: [
        MatSlideToggleModule,
        MatListModule,
        MatTableModule,
        MatFormFieldModule,
        MatSelectModule,
        MatInputModule
    ],
    exports: [
        MatSlideToggleModule,
        MatListModule,
        MatTableModule,
        MatFormFieldModule,
        MatSelectModule,
        MatInputModule
    ],
    providers: [
    ],
})
export class AngularMaterialModule { }