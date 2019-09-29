import {
    Component,
    Input,
    OnInit,
} from '@angular/core';

import resources from '../../../assets/resources/resources-ptBR.json';

@Component({
    selector: 'ifsc-term-paper-card',
    templateUrl: './ifsc-term-paper-card.component.html',
    styleUrls: ['./ifsc-term-paper-card.component.scss']
})
export class IfscTermPaperCardComponent implements OnInit {

    public readonly resources = resources;

    @Input() termPaperFiles: any;

    constructor() { }

    ngOnInit() { }
}
