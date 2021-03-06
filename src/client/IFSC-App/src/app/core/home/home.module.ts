import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { TermPaperModule } from '../../features/term-paper/term-paper.module';
import { IfscSearchbarModule } from '../../shared/ifsc-searchbar/ifsc-searchbar.module';
import { IfscSpinnerModule } from '../../shared/ifsc-spinner/ifsc-spinner.module';
import { MaterialModule } from '../../shared/material/material.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';

@NgModule({
    declarations: [
        HomeComponent,
    ],
    imports: [
        CommonModule,
        MaterialModule,
        TermPaperModule,
        IfscSearchbarModule,
        IfscSpinnerModule,
        HomeRoutingModule,
    ],
    providers: []
})
export class HomeModule { }
