import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

import { PeriodicElement, PeriodicElementHeader, PeriodicElementForEdit } from './periodic-element.models';
import { ValidationError } from '../core/core.models';
import { ApplicationService } from '../core/services/application.service';

@Injectable()
export class PeriodicElementService {

    constructor(
        private http: HttpClient,
        private applicationService: ApplicationService) { }

    detailPeriodicElementHeaderByPosition(position: number) {
        return this.http.get<PeriodicElementHeader>(`${this.applicationService.baseUrl}PeriodicElement/DetailPeriodicElementHeaderByPosition?position=${position}`);
    }

    listPeriodicElements() {
        return this.http.get<PeriodicElement[]>(`${this.applicationService.baseUrl}PeriodicElement/ListPeriodicElements`);
    }

    loadPeriodicElementForEdit(periodicElementID: string) {
        return this.http.get<PeriodicElementForEdit>(`${this.applicationService.baseUrl}PeriodicElement/LoadForEdit?periodicElementID=${periodicElementID}`);
    }

    savePeriodicElement(periodicElement: PeriodicElement) {
        return this.http.post<ValidationError[]>(`${this.applicationService.baseUrl}PeriodicElement/SavePeriodicElement`, periodicElement);
    }

    deletePeriodicElement(periodicElementID: string) {
        return this.http.delete<any>(`${this.applicationService.baseUrl}PeriodicElement/DeletePeriodicElement?periodicElementID=${periodicElementID}`);
    }
}
