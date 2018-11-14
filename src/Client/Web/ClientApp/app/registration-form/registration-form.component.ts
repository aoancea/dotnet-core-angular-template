import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { RegisterModel } from './registration-form.models';
import { UserService } from './registration-form.service';

@Component({
    selector: 'app-registration-form',
    templateUrl: './registration-form.component.html',
    styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {

    public registerModel: RegisterModel = <RegisterModel>{};

    constructor(private userService: UserService, private router: Router) {

    }

    ngOnInit() {
    }

    registerUser() {

        this.userService.register(this.registerModel).subscribe(x => {
            this.router.navigate(['/periodic-elements']);
        });
    }
}