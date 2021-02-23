import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TasksRestProviderService } from '../../services/tasks-rest-provider.service';
import { TaskAddDialogComponent } from './task-add-dialog/task-add-dialog.component';

@Component({
  selector: 'app-task-page',
  templateUrl: './task-page.component.html',
  styleUrls: ['./task-page.component.scss']
})
export class TaskPageComponent implements OnInit {

  constructor(
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private taskProvider: TasksRestProviderService
  ) { }

  ngOnInit(): void {
  }

  public applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    console.log(filterValue);
  }

  public openDialog() {
    const dialogRef = this.dialog.open(TaskAddDialogComponent);

    dialogRef.afterClosed().subscribe(taskToCreate => {
      this.taskProvider.addTask(taskToCreate).subscribe(() => {

      }, error => {
        console.error(error);
      });
    });
  }


}
