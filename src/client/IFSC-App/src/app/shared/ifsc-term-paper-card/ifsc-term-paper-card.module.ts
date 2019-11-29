import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { MaterialModule } from '../material/material.module';
import { IfscTermPaperCardComponent } from './ifsc-term-paper-card.component';

@NgModule({
    declarations: [
        IfscTermPaperCardComponent,
    ],
    imports: [
        CommonModule,
        MaterialModule,
    ],
    exports: [
        IfscTermPaperCardComponent
    ]
})
export class IfscTermPaperCardModule { }
