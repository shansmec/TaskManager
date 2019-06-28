import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Task } from './task';
import { Observable } from 'rxjs';
import { ParentTask } from './parent-task';
import { environment } from '../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class TaskService {

  BaseUrl = environment.baseUrl;
  
  constructor(private http: HttpClient) { }

  public getAllTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.BaseUrl + '/GetAllTasks');
  }
  public getTask(taskId: number): Observable<Task> {
    return this.http.get<Task>(this.BaseUrl + '/getTask/' + taskId);
  }
  public getAllParentTasks(): Observable<ParentTask[]> {
    return this.http.get<ParentTask[]>(this.BaseUrl + '/GetAllParentTasks');
  }
  public addTask(task: Task): Observable<any> {
    return this.http.post<any>(this.BaseUrl + '/addTask', task);
  }
  public updateTask(task: Task): Observable<any> {
    return this.http.post<any>(this.BaseUrl + '/updateTask', task);
  }
  public endTask(taskId: number): Observable<any> {
    return this.http.get<any>(this.BaseUrl + '/deleteTask/ ' + taskId);
  }  
  
}
