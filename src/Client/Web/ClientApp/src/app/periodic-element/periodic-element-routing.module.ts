import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthenticationGuard } from '../core/guards/authentication.guard';

import { PeriodicElementComponent } from './periodic-element.component';
import { PeriodicElementListComponent } from './periodic-element-list/periodic-element-list.component';
import { PeriodicElementEditComponent } from './periodic-element-edit/periodic-element-edit.component';

import { PeriodicElementService } from './periodic-element.service';

const routes: Routes = [
    {
        path: '', component: PeriodicElementComponent, data: { navArea: 'periodic-elements' },
        children: [
            { path: '', redirectTo: 'list', pathMatch: 'full' },
            { path: 'list', component: PeriodicElementListComponent, canActivate: [AuthenticationGuard] },
            { path: 'edit/:id', component: PeriodicElementEditComponent, canActivate: [AuthenticationGuard] },
            { path: 'edit', component: PeriodicElementEditComponent, canActivate: [AuthenticationGuard] },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PeriodicElementRoutingModule {
    static routedComponents = [PeriodicElementComponent, PeriodicElementListComponent, PeriodicElementEditComponent];
}