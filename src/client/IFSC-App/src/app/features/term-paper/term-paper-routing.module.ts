import { NgModule } from '@angular/core';
import {
    RouterModule,
    Routes,
} from '@angular/router';

import { TermPaperAddComponent } from './term-paper-add/term-paper-add.component';

const routes: Routes = [
    {
        path: '',
        children: [
            {
                path: 'add',
                component: TermPaperAddComponent
            }
        ],
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class TermPaperRoutingModule { }
