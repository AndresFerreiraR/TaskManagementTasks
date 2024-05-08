

using Newtonsoft.Json;

namespace TaskManagement.Tasks.Domain.Entities
{
    public class TaskCosmosDb
    {
        [JsonProperty("id")]
        public Guid TaskItemId { get; set; }
        
        [JsonProperty("Name")]
        public string TaskItemName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("startDate")]
        public DateTime? TaskItemStart { get; set; }

        [JsonProperty("endDate")]
        public DateTime? TaskItemEnd { get; set; }

        [JsonProperty("createdDate")]
        public DateTime? TaskItemCreated { get; set; }
        
        [JsonProperty("originalTimeEstimated")]
        public double OriginalTimeEstimated { get; set; }

        [JsonProperty("remainingTime")]
        public double RemainingTime { get; set; }

        [JsonProperty("completedTime")]
        public double CompletedTime { get; set; }

        [JsonProperty("userId")]
        public Guid? UserId { get; set; }

        [JsonProperty("priority")]
        public string State { get; set; }

        [JsonProperty("state")]
        public string Priority { get; set; }

        [JsonProperty("commets")]
        public List<TaskCommentCosmosDb>? TaskCommets { get; set; }
    }
}