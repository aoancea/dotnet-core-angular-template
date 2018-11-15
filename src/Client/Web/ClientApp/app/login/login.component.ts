import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { LoginModel } from './login.models';
import { LoginService } from './login.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    public loginModel: LoginModel = <LoginModel>{};

    constructor(private loginService: LoginService, private router: Router) {

    }

    ngOnInit() {
    }

    registerUser() {
        this.loginService.login(this.loginModel).subscribe(x => {
            this.router.navigate(['/periodic-elements']);
        });
    }
}
