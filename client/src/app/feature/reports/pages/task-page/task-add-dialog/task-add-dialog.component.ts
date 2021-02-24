import { Component, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { Task } from '../../../model/task.model';
import { TasksRestProviderService } from '../../../services/tasks-rest-provider.service';
import { taskNumberValidator } from '../../../services/validators/task-number.validator';

@UntilDestroy()
@Component({
  selector: 'app-task-add-dialog',
  templateUrl: './task-add-dialog.component.html',
  styleUrls: ['./task-add-dialog.component.scss']
})
export class TaskAddDialogComponent implements OnDestroy {

  public newTaskForm = new FormGroup({
    status: new FormControl('', [
      Validators.required
    ]),
    taskNumber: new FormControl('', {
      validators: [
        Validators.required
      ],
      asyncValidators: [
        taskNumberValidator(this.taskProvider, (() => this.canAddBePressed = this.newTaskForm.valid))
      ]
    }),
    comment: new FormControl()
  });
  public canAddBePressed = false;

  constructor(private taskProvider: TasksRestProviderService) {
    this.newTaskForm.valueChanges
      .pipe(untilDestroyed(this))
      .subscribe(() => {
        this.canAddBePressed = this.newTaskForm.valid;
      });
  }

  public ngOnDestroy() {
  }

  public getTask(): Task {
    let result = null;
    if (this.newTaskForm.valid) {
      const formValue = this.newTaskForm.value;
      result = {
        date: new Date(),
        status: formValue.status,
        comment: formValue.comment,
        taskNumber: formValue.taskNumber
      } as Task;
    }
    return result;
  }

}
