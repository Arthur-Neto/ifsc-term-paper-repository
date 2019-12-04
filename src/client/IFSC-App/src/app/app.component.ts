import {
    Component,
    OnInit,
} from '@angular/core';

import { LoginService } from './core/login/shared/login.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
    title = 'Repositório de TCC';

    private currentUser: any;

    get isLogged() {
        return this.currentUser !== null;
    }

    constructor(
        private loginService: LoginService
    ) { }

    public ngOnInit(): void {
        this.loginService.currentUser.subscribe((x) => this.currentUser = x);
    }

    public onLogout(): void {
        this.loginService.logout();
    }
}
