import {
    Component,
    OnInit,
} from '@angular/core';
import { Router } from '@angular/router';

import { take } from 'rxjs/operators';

import resources from '../../../assets/resources/resources-ptBR.json';
import { TermPaperService } from '../../features/term-paper/shared/term-paper.service';
import { LoginService } from '../login/shared/login.service.js';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
    public readonly resources = resources;

    public termPaperFiles: any;

    private currentUser: any;

    constructor(
        private termPaperService: TermPaperService,
        private loginService: LoginService,
        private router: Router,
    ) { }

    public ngOnInit() {
        this.loginService.currentUser.subscribe((x) => this.currentUser = x);
    }

    public search(query) {
        this.termPaperService
            .search(query)
            .pipe(take(1))
            .subscribe((result: any) => {
                this.termPaperFiles = result;
            });
    }

    get isAdmin() {
        return this.currentUser;
    }

    public onNew() {
        this.router.navigate(['term-paper/add']);
    }
}
