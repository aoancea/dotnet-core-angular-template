import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

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
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PeriodicElementRoutingModule {
    static routedComponents = [PeriodicElementListComponent, PeriodicElementEditComponent];
}