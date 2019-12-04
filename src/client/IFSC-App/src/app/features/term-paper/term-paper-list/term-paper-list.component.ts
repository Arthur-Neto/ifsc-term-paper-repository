import {
    Component,
    Input,
    OnInit,
} from '@angular/core';

import {
    take,
    tap,
} from 'rxjs/operators';

import { TermPaperService } from '../shared/term-paper.service';

@Component({
    selector: 'term-paper-list',
    templateUrl: './term-paper-list.component.html',
    styleUrls: ['./term-paper-list.component.scss']
})
export class TermPaperListComponent implements OnInit {
    @Input() termPaperFiles: any;

    public isLoading = false;

    constructor(private termPaperService: TermPaperService) { }

    public ngOnInit() {
        this.isLoading = true;
        this.termPaperService
            .getAll()
            .pipe(
                take(1),
                tap(() => this.isLoading = false))
            .subscribe((result: any) => {
                this.termPaperFiles = result;
            });
    }

}
