import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-task-page',
  templateUrl: './task-page.component.html',
  styleUrls: ['./task-page.component.scss']
})
export class TaskPageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    console.log(filterValue);
  }


}