import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

import { PeriodicElement } from './periodic-element.models';

@Injectable({
    providedIn: 'root'
})
export class PeriodicElementService {

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    listPeriodicElements() {
        return this.http.get<PeriodicElement[]>(`${this.baseUrl}PeriodicElement/ListPeriodicElements`);
    }

    getPeriodicElement(position: number) {
        return this.http.get<PeriodicElement>(`${this.baseUrl}PeriodicElement/GetPeriodicElement?position=${position}`);
    }

    detailPeriodicElementByID(periodicElementID: string) {
        return this.http.get<PeriodicElement>(`${this.baseUrl}PeriodicElement/GetPeriodicElementByID?periodicElementID=${periodicElementID}`);
    }

    createPeriodicElement(periodicElement: PeriodicElement) {
        return this.http.post<any>(`${this.baseUrl}PeriodicElement/CreatePeriodicElement`, periodicElement);
    }
}
