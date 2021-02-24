import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { untilDestroyed } from '@ngneat/until-destroy';
import { Observable, of } from 'rxjs';
import { debounceTime, map } from 'rxjs/operators';
import { TaskCountDto } from '../../model/task-count.dto';
import { Task } from '../../model/task.model';
import { TasksRestProviderService } from '../../services/tasks-rest-provider.service';
import { TaskAddDialogComponent } from './task-add-dialog/task-add-dialog.component';

@Component({
  selector: 'app-task-page',
  templateUrl: './task-page.component.html',
  styleUrls: ['./task-page.component.scss']
})
export class TaskPageComponent implements OnInit, OnDestroy {

  public readonly pageSize = 10;
  public tasks$: Observable<Task[]> = of();
  public taskCount$: Observable<number> = of(0);
  public currentPage = 0;
  public filterControl = new FormControl();

  constructor(
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private taskProvider: TasksRestProviderService
  ) { }

  public ngOnInit(): void {
    this.updateTasks();
    this.filterControl.valueChanges
      .pipe(
        untilDestroyed(this),
        debounceTime(500)
      )
      .subscribe(this.updateTasks.bind(this));
  }

  public ngOnDestroy(): void { }

  public openDialog(): void {
    const dialogRef = this.dialog.open(TaskAddDialogComponent);

    dialogRef.afterClosed().toPromise().then(taskToCreate => {
      this.taskProvider.addTask(taskToCreate).subscribe(() => {
        this.updateTasks();
      }, error => {
        console.error(error);
      });
    });
  }

  public onPageChanged(page: number): void {
    this.currentPage = page;
    this.updateTasks();
  }

  private updateTasks(): void {
    const tasks$ = this.taskProvider.getTasks(this.pageSize, this.pageSize * this.currentPage, this.filterControl.value);
    this.tasks$ = tasks$.pipe(map((val: TaskCountDto) => val.tasks));
    this.taskCount$ = tasks$.pipe(map((val: TaskCountDto) => val.taskCount));
  }


}
