using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerDataAccess
{
    public class TaskManagerDA
    {
        public List<Task> ReadAllTask()
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                return FSECapsuleEntities.Tasks.ToList<Task>();
            }
        }
        public List<ParentTask> ReadAllParentTask()
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                return FSECapsuleEntities.ParentTasks.ToList<ParentTask>();
            }
        }
        
        public Task ReadTask(int? TaskId)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                return FSECapsuleEntities.Tasks.Where(t => t.Task_ID == TaskId).FirstOrDefault();
            }
        }

        public ParentTask ReadParentTask(int? TaskId)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                return FSECapsuleEntities.ParentTasks.Where(t => t.Parent_ID == TaskId).FirstOrDefault();
            }
        }

        public void AddTask(Task task)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                try
                {
                    FSECapsuleEntities.Tasks.Add(task);
                    FSECapsuleEntities.SaveChanges();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void EndTask(Task taskId)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                Task task = FSECapsuleEntities.Tasks.Where(t => t.Task_ID == taskId.Task_ID).FirstOrDefault();
                FSECapsuleEntities.Tasks.Remove(task);
                FSECapsuleEntities.SaveChanges();
            }
        }

        public void UpdateTask(Task task)
        {
            using (FSECapsuleEntities FSECapsuleEntities = new FSECapsuleEntities())
            {
                Task currentTask = FSECapsuleEntities.Tasks.Where(t => t.Task_ID == task.Task_ID).FirstOrDefault();
                currentTask.Parent__ID = task.Parent__ID;
                currentTask.Task1 = task.Task1;
                currentTask.Priority = task.Priority;
                currentTask.Start_Date = task.Start_Date;
                currentTask.End_Date = task.End_Date;
                FSECapsuleEntities.SaveChanges();
            }
            
        }
    }
}
