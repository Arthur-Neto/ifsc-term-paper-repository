import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { IfscSearchbarModule } from '../../shared/ifsc-searchbar/ifsc-searchbar.module';
import { IfscTermPaperCardModule } from '../../shared/ifsc-term-paper-card/ifsc-term-paper-card.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';

@NgModule({
    declarations: [
        HomeComponent,
    ],
    imports: [
        CommonModule,
        IfscSearchbarModule,
        IfscTermPaperCardModule,
        HomeRoutingModule,
    ]
})
export class HomeModule { }
