using System;
using System.Collections.Generic;
using System.Web.Http;
using TaskManagerApi.Models;
using TaskManagerBusiness;
using DA = TaskManagerDataAccess;

namespace TaskManagerApi.Controllers
{
    public class TaskManagerController : ApiController
    {
        [HttpGet]
        [ActionName("GetAllTasks")]
        // GET: api/TaskManager
        public IEnumerable<Task> GetAllTasks()
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            List<Task> lstTask = new List<Task>();
            foreach (var task in taskManagerBL.ReadAllTask())
            {
                lstTask.Add(new Task()
                {
                    Name = task.Task1,
                    EndDate = task.End_Date.ToString("dd/MM/yyyy"),
                    ParentId = task.Parent__ID,
                    StartDate = task.Start_Date.ToString("dd/MM/yyyy"),
                    Priority = task.Priority,
                    TaskId = task.Task_ID,
                    ParentTaskName = task.Parent__ID == null ? "" : taskManagerBL.ReadParentTask(task.Parent__ID).Parent_Task
                });
            }
            return lstTask;
        }

        [HttpGet]
        [ActionName("GetAllParentTasks")]
        // GET: api/TaskManager/5
        public IEnumerable<ParentTask> GetAllParentTasks()
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            List<ParentTask> lstTask = new List<ParentTask>();
            foreach (var task in taskManagerBL.ReadAllParentTask())
            {
                lstTask.Add(new ParentTask()
                {
                    ParentId = task.Parent_ID,
                    ParentTaskName = task.Parent_Task
                });
            }
            return lstTask;
        }

        [HttpGet]
        [ActionName("GetTask")]
        // GET: api/TaskManager/5
        public Task GetTask(int id)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            DA.Task task = taskManagerBL.ReadTask(id);

            if (task != null)
                return new Task()
                {
                    Name = task.Task1,
                    EndDate = task.End_Date.ToString("dd/MM/yyyy"),
                    ParentId = task.Parent__ID,
                    StartDate = task.Start_Date.ToString("dd/MM/yyyy"),
                    Priority = task.Priority,
                    TaskId = task.Task_ID
                };
            return null;
        }

        [HttpPost]
        [ActionName("AddTask")]
        // POST: api/TaskManager
        public void AddTask([FromBody]Task task)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();

            taskManagerBL.AddTask(new DA.Task()
            {
                Task1 = task.Name,
                Parent__ID = task.ParentId,
                Priority = task.Priority,
                End_Date = Convert.ToDateTime(task.EndDate),
                Start_Date = Convert.ToDateTime(task.StartDate)
            });
        }

        [HttpPost]
        [ActionName("UpdateTask")]
        // PUT: api/TaskManager/5
        public void UpdateTask([FromBody]Task task)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();

            taskManagerBL.UpdateTask(new DA.Task()
            {
                Task_ID = task.TaskId,
                Task1 = task.Name,
                Parent__ID = task.ParentId,
                Priority = task.Priority,
                End_Date = Convert.ToDateTime(task.EndDate),
                Start_Date = Convert.ToDateTime(task.StartDate)
            });
        }

        [HttpGet]
        [ActionName("DeleteTask")]
        // DELETE: api/TaskManager/5
        public void DeleteTask(int id)
        {
            TaskManagerBL taskManagerBL = new TaskManagerBL();
            taskManagerBL.EndTask(id);
        }
    }
}
