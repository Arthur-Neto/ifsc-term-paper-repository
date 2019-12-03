import {
    Component,
    Input,
    OnInit,
} from '@angular/core';

import { take } from 'rxjs/operators';

import { TermPaperService } from '../shared/term-paper.service';

@Component({
    selector: 'term-paper-list',
    templateUrl: './term-paper-list.component.html',
    styleUrls: ['./term-paper-list.component.scss']
})
export class TermPaperListComponent implements OnInit {
    @Input() termPaperFiles: any;

    constructor(private termPaperService: TermPaperService) { }

    public ngOnInit() {
        this.termPaperService
            .getAll()
            .pipe(take(1))
            .subscribe((result: any) => {
                this.termPaperFiles = result;
            });
    }

}
