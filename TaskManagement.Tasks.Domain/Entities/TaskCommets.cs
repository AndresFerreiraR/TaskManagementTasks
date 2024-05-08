namespace TaskManagement.Tasks.Domain.Entities
{
    public class TaskCommets
    {

        public Guid CommentId { get; set; }
        public string TextComment { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
    }
}