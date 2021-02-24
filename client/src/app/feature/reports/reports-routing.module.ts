import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskPageComponent } from './pages/task-page/task-page.component';

export const routes: Routes = [
    {
        path: 'tasks', component: TaskPageComponent,
    },
    {
        path: '**', redirectTo: 'tasks', pathMatch: 'full'
    }
];


@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class ReportsRoutingModule {

}