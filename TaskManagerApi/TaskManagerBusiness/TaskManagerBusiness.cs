using System;
using System.Collections.Generic;
using TaskManagerDataAccess;

namespace TaskManagerBusiness
{
    public class TaskManagerBL
    {
        public List<Task> ReadAllTask()
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            return taskManagerDA.ReadAllTask();
        }

        public List<ParentTask> ReadAllParentTask()
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            return taskManagerDA.ReadAllParentTask();
        }

        public Task ReadTask(int TaskId)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            return taskManagerDA.ReadTask(TaskId);
        }

        public ParentTask ReadParentTask(int? TaskId)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            return taskManagerDA.ReadParentTask(TaskId);
        }

        public void AddTask(Task task)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            try
            {
                taskManagerDA.AddTask(task);
            }
            catch (Exception ex)
            {
            }
        }

        public void EndTask(int taskId)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            taskManagerDA.EndTask(taskManagerDA.ReadTask(taskId));
        }

        public void UpdateTask(Task task)
        {
            TaskManagerDA taskManagerDA = new TaskManagerDA();
            taskManagerDA.UpdateTask(task);
        }
    }
}
