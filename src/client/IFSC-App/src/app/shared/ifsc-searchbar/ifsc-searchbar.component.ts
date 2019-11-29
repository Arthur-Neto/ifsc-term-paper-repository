import {
    Component,
    EventEmitter,
    Input,
    OnInit,
    Output,
} from '@angular/core';
import { Router } from '@angular/router';

import resources from '../../../assets/resources/resources-ptBR.json';

@Component({
    selector: 'ifsc-searchbar',
    templateUrl: './ifsc-searchbar.component.html',
    styleUrls: ['./ifsc-searchbar.component.scss']
})
export class IfscSearchbarComponent {

    public readonly resources = resources;

    @Input() newRouteUrl: string;

    @Output() query = new EventEmitter<string>();

    constructor(
        private router: Router
    ) { }

    public onNew() {
        this.router.navigate([this.newRouteUrl]);
    }

    public onKeyUp(event: any) {
        this.query.emit(event.target.value);
    }
}
