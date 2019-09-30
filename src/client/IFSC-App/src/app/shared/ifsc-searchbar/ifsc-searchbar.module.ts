import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { MaterialModule } from '../material/material.module';
import { IfscSearchbarComponent } from './ifsc-searchbar.component';

@NgModule({
    declarations: [
        IfscSearchbarComponent,
    ],
    imports: [
        CommonModule,
        MaterialModule,
    ],
    exports: [
        IfscSearchbarComponent,
    ]
})
export class IfscSearchbarModule { }
