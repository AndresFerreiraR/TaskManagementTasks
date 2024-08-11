using Newtonsoft.Json;

namespace TaskManagement.Tasks.Application.Dto
{
    public class TaskCommentCosmosDbDto
    {
        public Guid Id { get; set; }
        public string TextComment { get; set; }
        public Guid UserId { get; set; }     
        public DateTime Date { get; set; }
    }
}