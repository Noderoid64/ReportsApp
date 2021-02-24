import { Component, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Task } from '../../../model/task.model';
import { TasksRestProviderService } from '../../../services/tasks-rest-provider.service';
import { taskNumberValidator } from '../../../services/validators/task-number.validator';

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

  private subscribtions: Subscription;

  constructor(private taskProvider: TasksRestProviderService) {
    this.subscribtions = this.newTaskForm.valueChanges.subscribe(() => {
      this.canAddBePressed = this.newTaskForm.valid;
    });
  }

  public ngOnDestroy() {
    this.subscribtions.unsubscribe();
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
