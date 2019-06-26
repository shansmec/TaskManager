using System;
using System.Collections.Generic;
using TaskManagerDataAccess;

namespace TaskManagerBusiness
{
    public class TaskManagerBAL
    {
        public List<Task> ReadAllTask()
        {
            TaskManagerDAL taskManagerDA = new TaskManagerDAL();
            return taskManagerDA.ReadAllTask();
        }

        public List<ParentTask> ReadAllParentTask()
        {
            TaskManagerDAL taskManagerDA = new TaskManagerDAL();
            return taskManagerDA.ReadAllParentTask();
        }

        public Task ReadTask(int TaskId)
        {
            TaskManagerDAL taskManagerDA = new TaskManagerDAL();
            return taskManagerDA.ReadTask(TaskId);
        }

        public ParentTask ReadParentTask(int? TaskId)
        {
            TaskManagerDAL taskManagerDA = new TaskManagerDAL();
            return taskManagerDA.ReadParentTask(TaskId);
        }

        public void AddTask(Task task)
        {
            TaskManagerDAL taskManagerDA = new TaskManagerDAL();
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
            TaskManagerDAL taskManagerDA = new TaskManagerDAL();
            taskManagerDA.EndTask(taskManagerDA.ReadTask(taskId));
        }

        public void UpdateTask(Task task)
        {
            TaskManagerDAL taskManagerDA = new TaskManagerDAL();
            taskManagerDA.UpdateTask(task);
        }
    }
}
