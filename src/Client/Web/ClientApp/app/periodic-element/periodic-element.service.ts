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
}
