using Newtonsoft.Json;

namespace TaskManagement.Tasks.Domain.Entities
{
    public class TaskCosmosDb
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("startDate")]
        public DateTime? startDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime? endDate { get; set; }

        [JsonProperty("creationDate")]
        public DateTime? creationDate { get; set; }
        
        [JsonProperty("originalTimeEstimated")]
        public double originalTimeEstimated { get; set; }

        [JsonProperty("remainingTime")]
        public double remainingTime { get; set; }

        [JsonProperty("completedTime")]
        public double completedTime { get; set; }

        [JsonProperty("createdBy")]
        public Guid? CreatedBy { get; set; }

        [JsonProperty("assignedTo")]
        public Guid? AssignedTo { get; set; }

        [JsonProperty("projectId")]
        public Guid ProjectId { get; set; }

        [JsonProperty("priority")]
        public string priority { get; set; }

        [JsonProperty("state")]
        public string state { get; set; }

        [JsonProperty("commets")]
        public List<TaskCommentCosmosDb>? commets { get; set; }
    }
}