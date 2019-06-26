import { Component, OnInit } from '@angular/core';
import { Options } from 'ng5-slider';
import { CommonModule } from '@angular/common'

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.scss']
})
export class AddTaskComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  public selectedParent: string;
  defaultSliderValue: number = 5;
  options: Options = {
    floor: 0,
    ceil: 30
  };
  
  defaultBindingsList = [
    { value: 1, label: 'Requirement Analysis' },
    { value: 2, label: 'Development' },
    { value: 3, label: 'Unit Testing' },
    { value: 3, label: 'System Testing' },
    { value: 3, label: 'Performance Testing' },
    { value: 3, label: 'Deployment' }
  ];


}
