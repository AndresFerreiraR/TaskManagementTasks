using Newtonsoft.Json;

namespace TaskManagement.Tasks.Application.Dto
{
    public class TaskCosmosDbDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public double? OriginalTimeEstimated { get; set; }
        public double? RemainingTime { get; set; }
        public double? CompletedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? AssignedTo { get; set; }
        public Guid? ProjectId { get; set; }
        public string? State { get; set; }
        public string? Priority { get; set; }
        public List<TaskCommentCosmosDbDto>? Comments { get; set; }
    }
}