import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Options } from 'ng5-slider';
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
  public addTaskButtonName :string ="Add Task";
  options: Options = {
    floor: 0,
    ceil: 30
  };

  constructor(private taskService: TaskService, private router: Router, private cdr:ChangeDetectorRef) {
    this._taskService = taskService;
    this.getAllParentTasks();
  };

  ngOnInit() {
    this.getTaskDetails();
  }

  getTaskDetails() {
    let id = window.top.location.href.split("?TaskId=")[1];
    if (id === "0" || id === undefined) {
      this.addTaskButtonName="Add Task";
      return;
    }
    this._taskService.getTask(parseInt(id)).subscribe(
      result => {
        this.setTaskDetails(result);
        this.addTaskButtonName="Update Task";
      }
    );
  }

  private setTaskDetails(result: Task) {
    this.addTask = result;
    this.start = result.StartDate;
    this.end = result.EndDate;
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
}
