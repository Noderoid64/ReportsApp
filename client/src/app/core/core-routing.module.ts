import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './pages/login-page/login-page.component';

export const routes: Routes = [
    {
        path: 'login',
        component: LoginComponent,
    },
    {
        path: 'reports',
        loadChildren: () => import('../feature/reports/reports.module').then(m => m.ReportsModule)
    },
    {
        path: '**',
        redirectTo: 'login',
        pathMatch: 'full'
    }
];


@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class CoreRoutingModule {

}