import { Component, OnInit } from '@angular/core';
import { Options } from 'ng5-slider';
import { CommonModule } from '@angular/common'
import { Task } from '../task';
import { TaskService } from '../task.service';
import { ParentTask } from '../parent-task';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.scss']
})
export class AddTaskComponent implements OnInit {

  public _taskService!: TaskService;
  public addTask: Task = new Task();
  public start: string = new Date().toISOString().split('T')[0];
  public end: string = new Date().toISOString().split('T')[0];
  public availableParentTasks!: ParentTask[];
  public selectedParent: string;
  defaultSliderValue: number = 5;
  options: Options = {
    floor: 0,
    ceil: 30
  };

  constructor(private taskService: TaskService, private router: Router) {
    this._taskService = taskService;
  };

  ngOnInit() {
    this.getAllParentTasks();
  }
  

  getTaskDetails() {
    let id = window.top.location.href.split("?TaskId=")[1];
    if (id === "0" || id === "undefined") {
      return;
    }
    this._taskService.getTask(parseInt(id)).subscribe(
      result => {
        this.addTask = result;
        this.start = result.StartDate;
        this.end = result.EndDate;
      }
    );

    console.log(this.addTask);
  }

  getAllParentTasks() {
    this._taskService.getAllParentTasks().subscribe(
      lstResults => {
        this.availableParentTasks = lstResults;
      }
    );
  }

  saveTask() {

    this._taskService.addTask(this.addTask).subscribe(
      result => {
        alert('Task saved successfully.');
        this.router.navigate(['/view-task']);
      }
    );
  }
  
  defaultBindingsList = [
    { value: 1, label: 'Requirement Analysis' },
    { value: 2, label: 'Development' },
    { value: 3, label: 'Unit Testing' },
    { value: 3, label: 'System Testing' },
    { value: 3, label: 'Performance Testing' },
    { value: 3, label: 'Deployment' }
  ];


}
