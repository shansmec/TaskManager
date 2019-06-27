import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-task',
  templateUrl: './view-task.component.html',
  styleUrls: ['./view-task.component.scss']
})
export class ViewTaskComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}

export class TaskSearch {
  TaskName: string = "";
  ParentName: string = "";
  PriorityFrom: number = 0;
  PriorityTo: number = 30;
  StartDate: string = new Date().toISOString().split('T')[0];
  EndDate: string = new Date().toISOString().split('T')[0];
}
