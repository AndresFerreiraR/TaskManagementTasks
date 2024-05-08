namespace TaskManagement.Tasks.Domain.Entities
{
    public class Priority
    {
        public Guid PriorityId { get; set; }
        public string PriorityName { get; set; }
        public string PriorityDescription { get; set; }
    }
}