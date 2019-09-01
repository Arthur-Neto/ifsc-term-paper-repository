import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { MaterialModule } from '../material/material.module';
import { IfscNavbarComponent } from './ifsc-navbar.component';

@NgModule({
    declarations: [
        IfscNavbarComponent,
    ],
    imports: [
        CommonModule,
        MaterialModule,
    ],
    exports: [
        IfscNavbarComponent,
    ]
})
export class IfscNavbarModule { }
