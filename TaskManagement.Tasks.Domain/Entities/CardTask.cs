using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TaskManagement.Tasks.Domain.Entities
{
    public class CardTask
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