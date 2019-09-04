import { OverlayModule } from '@angular/cdk/overlay';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatToolbarModule } from '@angular/material/toolbar';

@NgModule({
    exports: [
        CommonModule,
        OverlayModule,
        MatButtonModule,
        MatListModule,
        MatInputModule,
        MatFormFieldModule,
        MatDividerModule,
        MatProgressSpinnerModule,
        MatToolbarModule,
        MatIconModule,
    ]
})
export class MaterialModule { }
