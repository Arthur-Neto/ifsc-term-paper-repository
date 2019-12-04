import {
    ChangeDetectionStrategy,
    Component,
    Input,
    OnChanges,
    SimpleChanges,
} from '@angular/core';

import { NgxSpinnerService } from 'ngx-spinner';

@Component({
    selector: 'ifsc-spinner',
    templateUrl: './ifsc-spinner.component.html',
    styleUrls: ['./ifsc-spinner.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class IfscSpinnerComponent implements OnChanges {
    @Input() isLoading: boolean;

    constructor(
        private spinnerService: NgxSpinnerService
    ) { }

    public ngOnChanges(changes: SimpleChanges) {
        if (changes.isLoading.currentValue === true) {
            this.spinnerService.show();
        } else {
            this.spinnerService.hide();
        }
    }
}
