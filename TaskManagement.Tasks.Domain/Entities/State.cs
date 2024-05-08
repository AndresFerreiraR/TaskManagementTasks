namespace TaskManagement.Tasks.Domain.Entities
{
    public class State
    {
        public Guid StateId { get; set; }
        public string StateName { get; set;}
        public string StateDescription { get; set;}
    }
}