import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-periodic-element-edit',
    templateUrl: './periodic-element-edit.component.html',
    styleUrls: ['./periodic-element-edit.component.css']
})
export class PeriodicElementEditComponent implements OnInit {

    public position: string = "test";
    public name: string = "test";
    public weight: string = "test";
    public symbol: string = "test";

    constructor() { }

    ngOnInit() {
    }
}