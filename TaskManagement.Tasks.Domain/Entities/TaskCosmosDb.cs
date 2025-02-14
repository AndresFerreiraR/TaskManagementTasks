using Newtonsoft.Json;

namespace TaskManagement.Tasks.Domain.Entities
{
    public class TaskCosmosDb
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("taskId")]
        public string TaskId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("creationDate")]
        public DateTime? CreationDate { get; set; }
        
        [JsonProperty("originalTimeEstimated")]
        public double? OriginalTimeEstimated { get; set; }

        [JsonProperty("remainingTime")]
        public double? RemainingTime { get; set; }

        [JsonProperty("completedTime")]
        public double? CompletedTime { get; set; }

        [JsonProperty("createdBy")]
        public Guid CreatedBy { get; set; }

        [JsonProperty("assignedTo")]
        public Guid? AssignedTo { get; set; }

        [JsonProperty("projectId")]
        public Guid ProjectId { get; set; }

        [JsonProperty("priority")]
        public string? Priority { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("commets")]
        public List<TaskCommentCosmosDb>? Comments { get; set; }
        
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}