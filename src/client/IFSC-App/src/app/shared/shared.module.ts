import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';

import { IfscNavbarModule } from './ifsc-navbar/ifsc-navbar.module';
import { IfscSearchbarModule } from './ifsc-searchbar/ifsc-searchbar.module';
import { IfscSpinnerModule } from './ifsc-spinner/ifsc-spinner.module';
import { IfscTermPaperCardModule } from './ifsc-term-paper-card/ifsc-term-paper-card.module';
import { MaterialModule } from './material/material.module';

@NgModule({
    declarations: [],
    imports: [
        CommonModule
    ],
    exports: [
        MaterialModule,
        IfscTermPaperCardModule,
        IfscNavbarModule,
        IfscSearchbarModule,
        IfscSpinnerModule,
    ],
})
export class SharedModule {
    constructor(
        private matIconRegistry: MatIconRegistry,
        private domSanitizer: DomSanitizer
    ) {
        this.matIconRegistry.addSvgIcon('ifsc-logo', this.domSanitizer.bypassSecurityTrustResourceUrl('assets/ifsc-logo.svg'));
        this.matIconRegistry.addSvgIcon('add', this.domSanitizer.bypassSecurityTrustResourceUrl('assets/add.svg'));
        this.matIconRegistry.addSvgIcon('delete', this.domSanitizer.bypassSecurityTrustResourceUrl('assets/delete.svg'));
    }
}
