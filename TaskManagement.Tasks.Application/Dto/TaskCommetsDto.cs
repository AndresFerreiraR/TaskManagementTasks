namespace TaskManagement.Tasks.Application.Dto
{
    public class TaskCommetsDto
    {
        public Guid CommentId { get; set; }
        public string TextComment { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskItemId { get; set; }
        public TaskItemDto TaskItem { get; set; }
    }
}