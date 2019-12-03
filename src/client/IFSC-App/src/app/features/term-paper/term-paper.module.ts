import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import {
    FormsModule,
    ReactiveFormsModule,
} from '@angular/forms';

import { IfscTermPaperCardModule } from '../../shared/ifsc-term-paper-card/ifsc-term-paper-card.module';
import { MaterialModule } from '../../shared/material/material.module';
import { TermPaperAddComponent } from './term-paper-add/term-paper-add.component';
import { TermPaperListComponent } from './term-paper-list/term-paper-list.component';
import { TermPaperRoutingModule } from './term-paper-routing.module';

@NgModule({
    declarations: [
        TermPaperAddComponent,
        TermPaperListComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule,
        TermPaperRoutingModule,
        IfscTermPaperCardModule,
    ],
    exports: [
        TermPaperListComponent,
    ],
    providers: []
})
export class TermPaperModule { }
