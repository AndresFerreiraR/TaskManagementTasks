using Microsoft.EntityFrameworkCore;
using TaskManagement.Tasks.Domain.Entities;

namespace TaskManagement.Tasks.Infrastructure.Contexts
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {

        }

        public DbSet<TaskItem> TaskItem { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<TaskCommets> TaskComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TaskItem>(e =>
            {
                e.HasKey(t => t.TaskItemId);
                e.ToTable("Task");
                e.Property(t => t.TaskItemDescription).HasColumnType("nvarchar(MAX)");
                e.Property(t => t.OriginalTimeEstimated).HasPrecision(precision: 3, scale: 1);
                e.Property(t => t.RemainingTime).HasPrecision(precision: 3, scale: 1);
                e.Property(t => t.CompletedTime).HasPrecision(precision: 3, scale: 1);
            });

            // modelBuilder.Entity<Priority>(e => 
            // {
            //     e.HasKey(t => t.PriorityId);
            // });

            // modelBuilder.Entity<State>(e => 
            // {
            //     e.HasKey(t => t.StateId);
            // });

            modelBuilder.Entity<TaskCommets>(e => 
            {
                e.HasKey(t => t.CommentId);
                e.Property(p => p.TextComment).HasColumnType("nvarchar(MAX)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}