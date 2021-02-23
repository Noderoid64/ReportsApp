import { Component, EventEmitter, Input, AfterViewInit, Output, ViewChild, OnDestroy } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Subscription } from 'rxjs';
import { Task } from '../../../model/task.model';

@Component({
  selector: 'app-task-table',
  templateUrl: './task-table.component.html',
  styleUrls: ['./task-table.component.scss']
})
export class TaskTableComponent implements AfterViewInit, OnDestroy {

  @Input() public tasks: Array<Task> = [];
  @Input() public pageSize = 10;
  @Input() public allItems = 0;
  @Output() public pageChanged = new EventEmitter<number>();

  @ViewChild(MatPaginator) paginator: MatPaginator;

  public displayedColumns: string[] = ['id', 'taskNumber', 'date', 'status', 'comment'];

  private subscribtion: Subscription;

  constructor() { }

  public ngAfterViewInit(): void {
    this.subscribtion = this.paginator.page.subscribe((val: PageEvent) => {
      this.pageChanged.emit(val.pageIndex);
    });
  }

  public ngOnDestroy(): void {
    this.subscribtion.unsubscribe();
  }

}
