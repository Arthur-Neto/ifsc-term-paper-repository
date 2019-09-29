import {
    Component,
    OnInit,
} from '@angular/core';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

    public newRouteUrl = 'term-paper/add';
    public termPaperFiles: any;

    constructor() { }

    ngOnInit() { }
}
