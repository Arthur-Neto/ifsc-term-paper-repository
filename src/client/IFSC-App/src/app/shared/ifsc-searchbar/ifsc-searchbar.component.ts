import {
    Component,
    Input,
    OnInit,
} from '@angular/core';
import { Router } from '@angular/router';

import { take } from 'rxjs/operators';

import resources from '../../../assets/resources/resources-ptBR.json';
import { FileManagerService } from '../file-manager/file-manager.service.js';

@Component({
    selector: 'ifsc-searchbar',
    templateUrl: './ifsc-searchbar.component.html',
    styleUrls: ['./ifsc-searchbar.component.scss']
})
export class IfscSearchbarComponent implements OnInit {

    public readonly resources = resources;

    @Input() termPaperFiles: any;
    @Input() newRouteUrl: string;

    constructor(
        private router: Router,
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

    public onNew() {
        this.router.navigate([this.newRouteUrl]);
    }

    public onKeyUp(event: any) {
        const query: string = event.target.value;

        this.fileManagerService
            .getByQuery(query)
            .pipe(take(1))
            .subscribe((result: any) => {
                this.termPaperFiles = result;
            });
    }
}
