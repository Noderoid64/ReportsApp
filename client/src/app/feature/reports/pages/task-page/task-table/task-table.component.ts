import { Component, Input, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Task } from '../../../model/task.model';

@Component({
  selector: 'app-task-table',
  templateUrl: './task-table.component.html',
  styleUrls: ['./task-table.component.scss']
})
export class TaskTableComponent implements OnInit {

  @Input() public tasks: Array<Task> = [];

  public dataSource = new MatTableDataSource(this.tasks);
  displayedColumns: string[] = ['id', 'taskNumber', 'date', 'status', 'comment'];

  constructor() { }

  ngOnInit(): void {
  }

}
