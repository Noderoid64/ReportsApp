import { Component, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Task } from '../../../model/task.model';

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
    comment: new FormControl()
  });
  public canAddBePressed = false;

  private subscribtions: Subscription;

  constructor() {
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
        comment: formValue.comment
      } as Task;
    }
    return result;
  }

}
