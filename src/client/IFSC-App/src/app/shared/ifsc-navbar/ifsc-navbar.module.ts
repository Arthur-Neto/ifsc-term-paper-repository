import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material.module';
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
