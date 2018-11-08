import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl, FormArray, FormBuilder } from '@angular/forms';
import { map } from 'rxjs/operators';

import { PeriodicElement, Isotope } from './../periodic-element.models';
import { Router, ActivatedRoute } from '@angular/router';
import { PeriodicElementService } from '../periodic-element.service';
import { ValidationError } from '../../core/core.models';

@Component({
    selector: 'app-periodic-element-edit',
    templateUrl: './periodic-element-edit.component.html',
    styleUrls: ['./periodic-element-edit.component.css']
})
export class PeriodicElementEditComponent implements OnInit {

    private periodicElementID: string;

    public periodicElement: PeriodicElement;

    private isEdit: boolean = false;

    private formGroup: FormGroup;

    private errorMessage: string;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private periodicElementService: PeriodicElementService,
        private formBuilder: FormBuilder) { }

    ngOnInit() {

        this.periodicElementID = this.route.snapshot.params['id'];

        if (this.periodicElementID) {
            this.periodicElementService.detailPeriodicElementByID(this.periodicElementID).subscribe(res => {
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
        this.clearErrorMessages();

        Object.keys(this.formGroup.controls).forEach(control => {
            this.formGroup.get(control).markAsTouched();
        });

        if (this.formGroup.valid) {
            this.periodicElement = this.formGroup.value as PeriodicElement;

            if (this.isEdit) {
                this.periodicElement.id = this.periodicElementID;

                this.periodicElementService.updatePeriodicElement(this.periodicElement).subscribe((validationErrors: ValidationError[]) => {
                    if (validationErrors.length != 0) {
                        this.displayErrorMessages(validationErrors)
                    } else {
                        this.router.navigate(['/periodic-elements']);
                    }
                });
            }
            else {
                this.periodicElementService.createPeriodicElement(this.periodicElement).subscribe((validationErrors: ValidationError[]) => {
                    if (validationErrors.length != 0) {
                        this.displayErrorMessages(validationErrors)
                    } else {
                        this.router.navigate(['/periodic-elements']);
                    }
                });
            }
        }
    }

    displayErrorMessages(validationErrors: ValidationError[]) {
        this.errorMessage = validationErrors.map(x => x.message).join(' | ');
    }

    clearErrorMessages() {
        this.errorMessage = null;
    }

    initForm(periodicElement: PeriodicElement) {
        this.formGroup = this.formBuilder.group({
            position: [periodicElement.position, [Validators.required, Validators.max(118)] /*, [this.validatePositionTaken.bind(this)]*/],
            name: periodicElement.name,
            weight: [periodicElement.weight, Validators.required],
            symbol: periodicElement.symbol,
            isotopes: this.formBuilder.array((periodicElement.isotopes || []).map(isotope => this.createIsotopeFormGroup(isotope)))
        });
    }

    createIsotopeFormGroup(isotope: Isotope) {
        return this.formBuilder.group({
            name: isotope.name
        });
    }

    addIsotope() {
        (this.formGroup.get('isotopes') as FormArray).push(this.createIsotopeFormGroup(<Isotope>{}));
    }

    validatePositionTaken(control: AbstractControl) {
        return this.periodicElementService.detailPeriodicElementHeaderByPosition(control.value).pipe(
            map(periodicElement => periodicElement ? null : { positionTaken: true })
        );
    }

}