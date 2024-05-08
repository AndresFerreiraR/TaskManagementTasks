using Newtonsoft.Json;

namespace TaskManagement.Tasks.Domain.Entities
{
    public class TaskCommentCosmosDb
    {
        [JsonProperty("commentId")]
        public Guid CommentId { get; set; }

        [JsonProperty("textComment")]
        public string TextComment { get; set; }

        [JsonProperty("userId")]
        public Guid UserId { get; set; }
        
        [JsonProperty("commentDate")]
        public DateTime CommentDate { get; set; }
    }
}