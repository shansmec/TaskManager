export class Task {
    TaskId: number = 0;
    ParentId!: number;
    Name: string = "";
    StartDate: string = new Date().toISOString().split('T')[0];
    EndDate: string = new Date().toISOString().split('T')[0];
    Priority: number = 0;
    ParentTaskName: string = "";
  }
export class  DropdownList
{
    value: number;
    label: string
}