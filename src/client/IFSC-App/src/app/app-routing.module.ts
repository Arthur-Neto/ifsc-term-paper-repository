import { NgModule } from '@angular/core';
import {
    RouterModule,
    Routes,
} from '@angular/router';

import { HomeComponent } from './core/home/home.component';
import { LoginComponent } from './core/login/login.component';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full',
    },
    {
        path: 'home',
        component: HomeComponent,
        loadChildren: () => import('./core/home/home.module').then((mod) => mod.HomeModule)
    },
    {
        path: 'login',
        component: LoginComponent,
    },
    {
        path: 'term-paper',
        loadChildren: () => import('./features/term-paper/term-paper.module').then((mod) => mod.TermPaperModule)
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes, { useHash: true })],
    exports: [RouterModule]
})
export class AppRoutingModule { }
