import { Component, OnInit } from '@angular/core';
import { TaskService } from '../task.service';
import { Task } from '../task';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-task',
  templateUrl: './view-task.component.html',
  styleUrls: ['./view-task.component.scss']
})
export class ViewTaskComponent implements OnInit {
  public _taskService!: TaskService;
  public availableTasks!: Task[];
  public parentTask;
  public taskSearch: TaskSearch = new TaskSearch();
  constructor(private taskService: TaskService, private router: Router) {
    this._taskService = taskService;
  }

  ngOnInit() {
  }

  callService() {
    this._taskService.getAllTasks().subscribe(
      lstResults => {
        let result: Task[] = lstResults;
        if (this.taskSearch.TaskName !== "") {
          result = result.filter(t => t.Name.includes(this.taskSearch.TaskName));
        }

        result = result.filter(t => t.Priority >= this.taskSearch.PriorityFrom && t.Priority <= this.taskSearch.PriorityTo);


        this.availableTasks = result;
      }
    );
    console.log(this.availableTasks);
  }

  endTask(task: Task) {
    this._taskService.endTask(task.TaskId).subscribe(
      result => {
        alert('Task ended successfully.');
        for (var i = 0; i < this.availableTasks.length; i++) {
          if (this.availableTasks[i] === task) {
            this.availableTasks.splice(i, 1);
          }
        }
      }
    );
  }

  updateTask(task: Task) {
    this.router.navigate(['/AddTask'], { queryParams: { TaskId: task.TaskId } });
  }
  Reset(){}

}

export class TaskSearch {
  TaskName: string = "";
  ParentName: string = "";
  PriorityFrom: number = 0;
  PriorityTo: number = 30;
  StartDate: string = new Date().toISOString().split('T')[0];
  EndDate: string = new Date().toISOString().split('T')[0];
}
