import {
    Component,
    OnInit,
} from '@angular/core';

import { take } from 'rxjs/operators';

import { FileManagerService } from '../../shared/file-manager/file-manager.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

    public newRouteUrl = 'term-paper/add';
    public termPaperFiles: any;

    constructor(
        private fileManagerService: FileManagerService
    ) { }

    public ngOnInit() {
        this.fileManagerService
            .getAll()
            .pipe(take(1))
            .subscribe((result: any) => {
                this.termPaperFiles = result;
            });
    }
}
