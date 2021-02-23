import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskPageComponent } from './pages/task-page/task-page.component';
import { ReportPageComponent } from './pages/report-page/report-page.component';
import { ReportsRoutingModule } from './reports-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { TaskTableComponent } from './pages/task-page/task-table/task-table.component';
import { TaskAddDialogComponent } from './pages/task-page/task-add-dialog/task-add-dialog.component';



@NgModule({
  declarations: [
    TaskPageComponent,
    ReportPageComponent,
    TaskTableComponent,
    TaskAddDialogComponent
  ],
  imports: [
    CommonModule,
    ReportsRoutingModule,
    SharedModule
  ]
})
export class ReportsModule { }
