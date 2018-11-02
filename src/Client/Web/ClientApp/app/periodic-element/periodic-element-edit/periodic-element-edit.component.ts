import { Component, OnInit } from '@angular/core';

import { PeriodicElement } from './../periodic-element.models';
import { Router, ActivatedRoute } from '@angular/router';
import { PeriodicElementService } from '../periodic-element.service';

@Component({
    selector: 'app-periodic-element-edit',
    templateUrl: './periodic-element-edit.component.html',
    styleUrls: ['./periodic-element-edit.component.css']
})
export class PeriodicElementEditComponent implements OnInit {

    public position: number;
    public name: string;
    public weight: number;
    public symbol: string;

    private isEdit: boolean = false;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private periodicElementService: PeriodicElementService) { }

    ngOnInit() {

        this.position = this.route.snapshot.params['position'];

        if (this.position) {
            this.periodicElementService.getPeriodicElement(this.position).subscribe(res => {
                this.name = res.name;
                this.symbol = res.symbol;
                this.weight = res.weight;

                this.isEdit = true;
            });

        } else {
            this.isEdit = false;
        }
    }
}