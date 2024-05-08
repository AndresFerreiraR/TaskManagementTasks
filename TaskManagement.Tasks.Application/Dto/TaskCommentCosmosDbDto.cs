using Newtonsoft.Json;

namespace TaskManagement.Tasks.Application.Dto
{
    public class TaskCommentCosmosDbDto
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