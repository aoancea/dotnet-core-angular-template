import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PeriodicElementService } from './periodic-element.service';

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [],
    providers: [PeriodicElementService]
})
export class PeriodicElementModule { }
