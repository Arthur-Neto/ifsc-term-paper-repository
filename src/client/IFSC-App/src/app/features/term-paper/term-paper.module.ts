import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { TermPaperAddComponent } from './term-paper-add/term-paper-add.component';
import { TermPaperRoutingModule } from './term-paper-routing.module';

@NgModule({
    declarations: [
        TermPaperAddComponent
    ],
    imports: [
        CommonModule,
        TermPaperRoutingModule
    ]
})
export class TermPaperModule { }
