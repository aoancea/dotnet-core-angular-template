import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PeriodicElementService } from './periodic-element.service';
import { CoreModule } from '../core/core.module';

@NgModule({
    imports: [
        CommonModule,
        CoreModule
    ],
    declarations: [],
    providers: [PeriodicElementService]
})
export class PeriodicElementModule { }
