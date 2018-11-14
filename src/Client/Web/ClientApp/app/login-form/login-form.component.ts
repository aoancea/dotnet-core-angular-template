import { Component, OnInit } from '@angular/core';
import { LoginModel } from './login-form.models';
import { Router } from '@angular/router';
import { LoginService } from './login-form.service';

@Component({
    selector: 'app-login-form',
    templateUrl: './login-form.component.html',
    styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

    public loginModel: LoginModel = <LoginModel>{};

    constructor(private loginService: LoginService, private router: Router) {

    }

    ngOnInit() {
    }

    registerUser() {

        this.loginService.login(this.loginModel).subscribe(x => {

            // save token
            localStorage.setItem('token', x);

            this.router.navigate(['/periodic-elements']);
        });
    }
}
