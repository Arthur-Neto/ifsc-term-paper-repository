import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { FileManagerService } from '../file-manager/file-manager.service';
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
    ],
    providers: [
        FileManagerService,
    ]
})
export class IfscSearchbarModule { }
