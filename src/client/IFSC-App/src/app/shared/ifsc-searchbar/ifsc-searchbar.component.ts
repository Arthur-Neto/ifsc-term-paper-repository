import {
    Component,
    EventEmitter,
    Output,
} from '@angular/core';

import resources from '../../../assets/resources/resources-ptBR.json';

@Component({
    selector: 'ifsc-searchbar',
    templateUrl: './ifsc-searchbar.component.html',
    styleUrls: ['./ifsc-searchbar.component.scss']
})
export class IfscSearchbarComponent {
    public readonly resources = resources;

    @Output() query = new EventEmitter<string>();

    constructor() { }

    public onKeyUp(event: any) {
        this.query.emit(event.target.value);
    }
}
