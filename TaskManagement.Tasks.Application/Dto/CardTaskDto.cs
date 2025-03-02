using Newtonsoft.Json;

namespace TaskManagement.Tasks.Application.Dto
{
    public class CardTaskDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("taskId")]
        public string TaskId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("assignedTo")]
        public Guid? AssignedTo { get; set; }

        [JsonProperty("createdBy")]
        public Guid CreatedBy { get; set; }
        
        [JsonProperty("priority")]
        public string? Priority { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}