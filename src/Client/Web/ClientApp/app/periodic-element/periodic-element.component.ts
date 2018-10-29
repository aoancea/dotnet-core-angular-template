import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export interface PeriodicElement {
    name: string;
    position: number;
    weight: number;
    symbol: string;
}

@Component({
    selector: 'app-periodic-element',
    templateUrl: './periodic-element.component.html',
    styleUrls: ['./periodic-element.component.css']
})
export class PeriodicElementListComponent implements OnInit {

    public displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
    public periodicElements: PeriodicElement[] = [];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<PeriodicElement[]>(baseUrl + 'PeriodicElement/ListPeriodicElements').subscribe(result => {
            this.periodicElements = result;
        }, error => console.error(error));
    }

    ngOnInit() {
    }
}