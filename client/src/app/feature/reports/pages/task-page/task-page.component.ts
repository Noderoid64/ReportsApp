import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable, of } from 'rxjs';
import { Task } from '../../model/task.model';
import { TasksRestProviderService } from '../../services/tasks-rest-provider.service';
import { TaskAddDialogComponent } from './task-add-dialog/task-add-dialog.component';

@Component({
  selector: 'app-task-page',
  templateUrl: './task-page.component.html',
  styleUrls: ['./task-page.component.scss']
})
export class TaskPageComponent implements OnInit {

  public tasks$: Observable<Task[]> = of();

  constructor(
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private taskProvider: TasksRestProviderService
  ) { }

  public ngOnInit(): void {
    this.tasks$ = this.taskProvider.getTasks(15, 0, undefined);
  }

  public applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.tasks$ = this.taskProvider.getTasks(15, 0, filterValue);
  }

  public openDialog() {
    const dialogRef = this.dialog.open(TaskAddDialogComponent);

    dialogRef.afterClosed().subscribe(taskToCreate => {
      this.taskProvider.addTask(taskToCreate).subscribe(() => {
        this.tasks$ = this.taskProvider.getTasks(15, 0, undefined);
      }, error => {
        console.error(error);
      });
    });
  }


}
