using Newtonsoft.Json;

namespace TaskManagement.Tasks.Application.Dto
{
    public class TaskCommentCosmosDbDto
    {
        public Guid Id { get; set; }
        public string TextComment { get; set; }
        public Guid CommentBy { get; set; }     
        public DateTime CommentDate { get; set; }
    }
}