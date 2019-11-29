import { NgModule } from '@angular/core';
import {
    RouterModule,
    Routes,
} from '@angular/router';

import { HomeComponent } from './features/home/home.component';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full',
    },
    {
        path: 'home',
        component: HomeComponent,
        loadChildren: () => import('./features/home/home.module').then((mod) => mod.HomeModule)
    },
    {
        path: 'term-paper',
        loadChildren: () => import('./features/term-paper/term-paper.module').then((mod) => mod.TermPaperModule)
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
