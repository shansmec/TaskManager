using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagerApi.Controllers;
using TaskManagerApi.Models;

namespace TaskManagerApi.Tests.Controllers
{
    [TestClass]
    public class TaskManagerControllerTest
    {
        [TestMethod]
        public void TestAdd()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddTask(new Models.Task() { Name = "AddTask", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), ParentId = 1, Priority = 10 });
            IEnumerable<Task> tasks = taskManagerController.GetAllTasks();
            Assert.IsNotNull(tasks);
            Assert.IsNotNull(tasks.Where(t => t.Name == "AddTask").First());
        }

        [TestMethod]
        public void TestGet()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddTask(new Models.Task() { Name = "GetTask1", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), ParentId = 1, Priority = 10 });
            taskManagerController.AddTask(new Models.Task() { Name = "GetTask2", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), ParentId = 1, Priority = 10 });
            IEnumerable<Task> tasks = taskManagerController.GetAllTasks();
            Assert.IsNotNull(tasks);
            int taskId = tasks.FirstOrDefault().TaskId;
            Task task = taskManagerController.GetTask(taskId);
            Assert.IsNotNull(task);
        }

        [TestMethod]
        public void TestGetParents()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            IEnumerable<ParentTask> tasks = taskManagerController.GetAllParentTasks();
            Assert.IsNotNull(tasks);
        }

        [TestMethod]
        public void TestDelete()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddTask(new Models.Task() { Name = "TestDelete1", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), ParentId = 1, Priority = 10 });
            IEnumerable<Task> tasks = taskManagerController.GetAllTasks();
            Assert.IsNotNull(tasks);
            int taskId = tasks.Where(t => t.Name == "TestDelete1").FirstOrDefault().TaskId;
            Task task = taskManagerController.GetTask(taskId);
            taskManagerController.DeleteTask(taskId);
            task = taskManagerController.GetTask(taskId);
            Assert.IsNull(task);
        }

        [TestMethod]
        public void TestUpdate()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddTask(new Models.Task() { Name = "TestUpdate1", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), ParentId = 1, Priority = 10 });
            IEnumerable<Task> tasks = taskManagerController.GetAllTasks();
            Assert.IsNotNull(tasks);
            Task task = tasks.Where(t => t.Name == "TestUpdate1").FirstOrDefault();
            string newName = task.Name + "Renamed";
            task.Name = newName;
            task.StartDate  = DateTime.ParseExact(task.StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).ToString();
            task.EndDate = DateTime.ParseExact(task.EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).ToString();
            taskManagerController.UpdateTask(task);
            task = taskManagerController.GetTask(task.TaskId);
            Assert.IsTrue(task.Name == newName);
        }
    }
}
