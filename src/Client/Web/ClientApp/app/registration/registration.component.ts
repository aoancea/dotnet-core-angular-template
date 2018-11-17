import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { RegisterModel } from './registration.models';
import { UserService } from './registration.service';

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

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