import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { PeriodicElement } from './../periodic-element.models';

@Component({
    selector: 'app-periodic-element-list',
    templateUrl: './periodic-element-list.component.html',
    styleUrls: ['./periodic-element-list.component.css']
})
export class PeriodicElementListComponent implements OnInit {

    public displayedColumns: string[] = ['position', 'name', 'weight', 'symbol', 'action'];
    public periodicElements: PeriodicElement[] = [];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<PeriodicElement[]>(baseUrl + 'PeriodicElement/ListPeriodicElements').subscribe(result => {
            this.periodicElements = result;
        }, error => console.error(error));
    }

    ngOnInit() {
    }
}