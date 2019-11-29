import {
    Component,
    OnInit,
} from '@angular/core';

import { take } from 'rxjs/operators';

import { TermPaperService } from '../term-paper/shared/term-paper.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

    public newRouteUrl = 'term-paper/add';
    public termPaperFiles: any;

    constructor(
        private termPaperService: TermPaperService
    ) { }

    public ngOnInit() {
        this.termPaperService
            .getAll()
            .pipe(take(1))
            .subscribe((result: any) => {
                this.termPaperFiles = result;
            });
    }

    public search(query) {
        this.termPaperService
            .search(query)
            .pipe(take(1))
            .subscribe((result: any) => {
                console.log(result);
            });
    }
}
