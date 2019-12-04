import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { NgxSpinnerModule } from 'ngx-spinner';

import { IfscSpinnerComponent } from './ifsc-spinner.component';

@NgModule({
    declarations: [
        IfscSpinnerComponent
    ],
    imports: [
        CommonModule,
        NgxSpinnerModule,
    ],
    exports: [
        IfscSpinnerComponent
    ]
})
export class IfscSpinnerModule { }
