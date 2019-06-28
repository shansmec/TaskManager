using System;

namespace TaskManagerApi.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Priority { get; set; }
        public string ParentTaskName { get; set; }
    }
}