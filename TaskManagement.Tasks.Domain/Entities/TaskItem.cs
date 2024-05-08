
namespace TaskManagement.Tasks.Domain.Entities
{
    using System;


    public class TaskItem
    {
        public Guid TaskItemId { get; set; }
        public string TaskItemName { get; set; }
        public string TaskItemDescription { get; set; }
        public DateTime? TaskItemStart { get; set; }
        public DateTime? TaskItemEnd { get; set; }
        public DateTime? TaskItemCreated { get; set; }
        public double OriginalTimeEstimated { get; set; }
        public double RemainingTime { get; set; }
        public double CompletedTime { get; set; }
        public Guid? UserId { get; set; }
        public Guid StateId { get; set; }
        public Guid PriorityId { get; set; }
        public Priority Priority { get; set; }
        public State State { get; set; }
        public List<TaskCommets>? TaskCommets { get; set; }
    }
}