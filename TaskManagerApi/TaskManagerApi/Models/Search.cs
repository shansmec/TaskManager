using System;

namespace TaskManagerApi.Models
{
    public class Search
    {
        public string Name { get; set; }
        public int StartPriority { get; set; }
        public int EndPriority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public string ParentTaskName { get; set; }
    }
}