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
        public Guid Id { get; set; }
        
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("assignedTo")]
        public Guid? AssignedTo { get; set; }

        [JsonProperty("createdBy")]
        public Guid CreatedBy { get; set; }
        
        [JsonProperty("priority")]
        public string? Priority { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }
    }
}