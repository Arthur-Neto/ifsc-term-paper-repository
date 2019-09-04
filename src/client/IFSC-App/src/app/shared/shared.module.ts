import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';

import { IfscNavbarModule } from './ifsc-navbar/ifsc-navbar.module';
import { IfscSearchbarModule } from './ifsc-searchbar/ifsc-searchbar.module';
import { MaterialModule } from './material/material.module';

@NgModule({
    declarations: [],
    imports: [
        CommonModule
    ],
    exports: [
        MaterialModule,
        IfscNavbarModule,
        IfscSearchbarModule,
    ],
})
export class SharedModule {
    constructor(
        private matIconRegistry: MatIconRegistry,
        private domSanitizer: DomSanitizer
    ) {
        this.matIconRegistry.addSvgIcon('ifsc-logo', this.domSanitizer.bypassSecurityTrustResourceUrl('assets/ifsc-logo.svg'));
    }
}
