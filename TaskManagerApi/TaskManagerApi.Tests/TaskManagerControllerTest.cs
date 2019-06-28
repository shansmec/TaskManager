using System;
using System.Collections.Generic;
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
            taskManagerController.Add(new Models.Task() { Name = "AddTask", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), ParentId = 1, Priority = 10 });
            IEnumerable<Task> tasks = taskManagerController.Get();
            Assert.IsNotNull(tasks);
            Assert.IsNotNull(tasks.Where(t => t.Name == "AddTask").First());
        }

        [TestMethod]
        public void TestGet()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.Add(new Models.Task() { Name = "GetTask1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), ParentId = 1, Priority = 10 });
            taskManagerController.Add(new Models.Task() { Name = "GetTask2", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), ParentId = 1, Priority = 10 });
            IEnumerable<Task> tasks = taskManagerController.Get();
            Assert.IsNotNull(tasks);
            int taskId = tasks.FirstOrDefault().TaskId;
            Task task = taskManagerController.Get(taskId);
            Assert.IsNotNull(task);
        }

        [TestMethod]
        public void TestDelete()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.Add(new Models.Task() { Name = "TestDelete1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), ParentId = 1, Priority = 10 });
            IEnumerable<Task> tasks = taskManagerController.Get();
            Assert.IsNotNull(tasks);
            int taskId = tasks.Where(t => t.Name == "TestDelete1").FirstOrDefault().TaskId;
            Task task = taskManagerController.Get(taskId);
            taskManagerController.Delete(taskId);
            task = taskManagerController.Get(taskId);
            Assert.IsNull(task);
        }

        [TestMethod]
        public void TestUpdate()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.Add(new Models.Task() { Name = "TestUpdate1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), ParentId = 1, Priority = 10 });
            IEnumerable<Task> tasks = taskManagerController.Get();
            Assert.IsNotNull(tasks);
            Task task = tasks.Where(t => t.Name == "TestUpdate1").FirstOrDefault();
            string newName = task.Name + "Renamed";
            task.Name = newName;
            taskManagerController.Update(task);
            task = taskManagerController.Get(task.TaskId);
            Assert.IsTrue(task.Name == newName);
        }
    }
}
