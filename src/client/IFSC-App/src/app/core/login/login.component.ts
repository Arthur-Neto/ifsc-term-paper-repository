import {
    Component,
    OnInit,
} from '@angular/core';
import {
    FormBuilder,
    FormGroup,
    Validators,
} from '@angular/forms';
import { Router } from '@angular/router';

import { NgxSpinnerService } from 'ngx-spinner';
import {
    take,
    tap,
} from 'rxjs/operators';

import resources from '../../../assets/resources/resources-ptBR.json';
import { LoginService } from './shared/login.service.js';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
    public readonly resources = resources;

    public isLoading = false;
    public showIncorrectLoginOrPassword = false;
    public credentials: FormGroup;

    get f() { return this.credentials.controls; }

    constructor(
        private fb: FormBuilder,
        private loginService: LoginService,
        private router: Router,
    ) {
        if (this.loginService.currentUserValue) {
            this.router.navigate(['/']);
        }
    }

    public ngOnInit() {
        this.credentials = this.fb.group({
            login: ['', [Validators.required, Validators.minLength(4)]],
            password: ['', [Validators.required, Validators.minLength(4)]],
        });
    }

    public onSubmit(credentials: FormGroup) {
        this.isLoading = true;
        const command: any = {
            login: credentials.value.login,
            password: credentials.value.password
        };

        this.loginService
            .login(command)
            .pipe(
                take(1),
                tap(() => this.isLoading = false))
            .subscribe(
                (data) => {
                    if (data === null) {
                        this.showIncorrectLoginOrPassword = true;
                        return;
                    }
                    this.router
                        .navigate(['/'])
                        .then(() => {
                            window.location.reload();
                        });
                },
                (error) => {
                    console.log(error);
                });
    }
}
