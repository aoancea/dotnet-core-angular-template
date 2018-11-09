import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { PeriodicElement } from './../periodic-element.models';
import { PeriodicElementService } from '../periodic-element.service';

@Component({
    selector: 'app-periodic-element-list',
    templateUrl: './periodic-element-list.component.html',
    styleUrls: ['./periodic-element-list.component.css']
})
export class PeriodicElementListComponent implements OnInit {

    public displayedColumns: string[] = ['position', 'name', 'weight', 'symbol', 'action'];
    public periodicElements: PeriodicElement[] = [];

    constructor(private periodicElementService: PeriodicElementService) {
    }

    ngOnInit() {
        this.loadPeriodicElements();
    }

    deletePeriodicElement(periodicElement: PeriodicElement) {
        this.periodicElementService.deletePeriodicElement(periodicElement.id).subscribe(x => {
            this.loadPeriodicElements();
        });
    }

    loadPeriodicElements() {
        this.periodicElementService.listPeriodicElements().subscribe(res => {
            this.periodicElements = res;
        });
    }
}