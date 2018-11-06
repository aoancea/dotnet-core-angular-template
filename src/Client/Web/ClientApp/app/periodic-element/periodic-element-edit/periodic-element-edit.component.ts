import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl, FormArray } from '@angular/forms';
import { map } from 'rxjs/operators';

import { PeriodicElement, Isotope } from './../periodic-element.models';
import { Router, ActivatedRoute } from '@angular/router';
import { PeriodicElementService } from '../periodic-element.service';

@Component({
    selector: 'app-periodic-element-edit',
    templateUrl: './periodic-element-edit.component.html',
    styleUrls: ['./periodic-element-edit.component.css']
})
export class PeriodicElementEditComponent implements OnInit {

    public periodicElement: PeriodicElement;

    private isEdit: boolean = false;

    private formGroup: FormGroup;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private periodicElementService: PeriodicElementService) { }

    ngOnInit() {

        let periodicElementID = this.route.snapshot.params['id'];

        if (periodicElementID) {
            this.periodicElementService.detailPeriodicElementByID(periodicElementID).subscribe(res => {
                this.periodicElement = res;
                this.initForm(this.periodicElement);
                this.isEdit = true;
            });
        } else {
            this.isEdit = false;
            this.initForm(<PeriodicElement>{});
        }
    }

    save() {
        Object.keys(this.formGroup.controls).forEach(control => {
            this.formGroup.get(control).markAsTouched();
        });

        if (this.formGroup.valid) {
            this.periodicElement = this.formGroup.value as PeriodicElement;

            this.periodicElementService.createPeriodicElement(this.periodicElement).subscribe(() => {
                this.router.navigate(['/periodic-elements']);
            });
        }
    }

    initForm(periodicElement: PeriodicElement) {
        this.formGroup = new FormGroup({
            position: new FormControl(periodicElement.position, [Validators.required, Validators.max(118)]), // [this.validatePositionTaken.bind(this)]
            name: new FormControl(periodicElement.name),
            weight: new FormControl(periodicElement.weight),
            symbol: new FormControl(periodicElement.symbol),
            isotopes: this.createIsotopesArray(periodicElement.isotopes)
        });
    }

    createIsotopesArray(isotopes: Isotope[]) {
        let formArray = new FormArray([]);

        if (!isotopes)
            return formArray;

        isotopes.forEach(isotope => {
            formArray.push(new FormGroup({
                name: new FormControl(isotope.name)
            }));
        });

        return formArray;
    }

    addIsotope() {
        (this.formGroup.get('items') as FormArray).push(new FormGroup({
            name: new FormControl('')
        }));
    }

    validatePositionTaken(control: AbstractControl) {
        return this.periodicElementService.getPeriodicElement(control.value).pipe(
            map(periodicElement => periodicElement ? null : { positionTaken: true })
        );
    }
}