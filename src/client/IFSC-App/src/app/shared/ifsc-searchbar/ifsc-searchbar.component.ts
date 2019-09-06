import {
    Component,
    Input,
    OnInit,
} from '@angular/core';
import {
    ActivatedRoute,
    Router,
} from '@angular/router';

@Component({
    selector: 'ifsc-searchbar',
    templateUrl: './ifsc-searchbar.component.html',
    styleUrls: ['./ifsc-searchbar.component.scss']
})
export class IfscSearchbarComponent implements OnInit {

    @Input() newRouteUrl: string;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
    ) { }

    ngOnInit() { }

    public onNew() {
        this.router.navigate([this.newRouteUrl]);
    }
}
