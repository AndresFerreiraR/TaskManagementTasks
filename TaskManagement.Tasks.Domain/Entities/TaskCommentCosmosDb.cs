using Newtonsoft.Json;

namespace TaskManagement.Tasks.Domain.Entities
{
    public class TaskCommentCosmosDb
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("textComment")]
        public string TextComment { get; set; }

        [JsonProperty("commentBy")]
        public Guid CommentBy { get; set; }
        
        [JsonProperty("commentDate")]
        public DateTime CommentDate { get; set; }
    }
}