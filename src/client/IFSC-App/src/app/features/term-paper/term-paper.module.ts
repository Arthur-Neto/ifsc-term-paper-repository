import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import {
    FormsModule,
    ReactiveFormsModule,
} from '@angular/forms';

import { FileManagerService } from '../../shared/file-manager/file-manager.service';
import { MaterialModule } from '../../shared/material/material.module';
import { TermPaperAddComponent } from './term-paper-add/term-paper-add.component';
import { TermPaperRoutingModule } from './term-paper-routing.module';

@NgModule({
    declarations: [
        TermPaperAddComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule,
        TermPaperRoutingModule
    ],
    providers: [
        FileManagerService,
    ]
})
export class TermPaperModule { }
