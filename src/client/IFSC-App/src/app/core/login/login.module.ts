import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import {
    FormsModule,
    ReactiveFormsModule,
} from '@angular/forms';

import { IfscSpinnerModule } from '../../shared/ifsc-spinner/ifsc-spinner.module';
import { MaterialModule } from '../../shared/material/material.module';
import { LoginComponent } from './login.component';

@NgModule({
    declarations: [
        LoginComponent,
    ],
    imports: [
        CommonModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule,
        IfscSpinnerModule,
    ]
})
export class LoginModule { }
