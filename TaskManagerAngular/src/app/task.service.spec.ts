import { TestBed, getTestBed } from '@angular/core/testing';
import { TaskService } from './task.service';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('Create Task Manager Service', () => {
  let injector: TestBed;
  let service: TaskService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TaskService]
    });
    injector = getTestBed();
    service = injector.get(TaskService);
    httpMock = injector.get(HttpTestingController);
    service.getAllParentTasks().subscribe(
      lstResults => {
        expect(lstResults.length).toBeGreaterThanOrEqual(1);
      }
    );

    it('should get all tasks', () => {
      service.getAllTasks().subscribe(
        lstResults => {
          expect(lstResults.length).toBeGreaterThanOrEqual(1);
        }
      );
    });

    it('should get all tasks', () => {
      service.getAllTasks().subscribe(
        lstResults => {
          expect(lstResults.length).toBeGreaterThanOrEqual(1);
          service.getTask(lstResults[0].TaskId).subscribe(
            getResult => {
              expect(getResult.TaskId).toBeGreaterThanOrEqual(1);
            });
        }
      );
    });

  });
});
