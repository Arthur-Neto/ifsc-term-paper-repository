import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { MaterialModule } from './material.module';
import { IfscNavbarModule } from './ifsc-navbar/ifsc-navbar.module';

@NgModule({
    declarations: [],
    imports: [
        CommonModule
    ],
    exports: [
        MaterialModule,
        IfscNavbarModule,
    ],
})
export class SharedModule { }
