using TaskManagement.Tasks.Domain.Entities;

namespace TaskManagement.Tasks.Infrastructure.Interfaces
{
    public interface ITaskDL
    {
        #region SQL Region
        public Task CreateTask(TaskItem task);
        public Task UpdateTask(TaskItem task);
        public Task<TaskItem> GetTaskById(Guid id);
        public Task<List<TaskItem>> GetAllTasks();
        public Task<List<TaskItem>> GetTasksByFilter(TaskItem task);

        #endregion

        #region CosmosDb
        public Task<List<TaskCosmosDb>> GetListTaskFromCosmosDb();

        public Task CreateTaskCosmos(TaskCosmosDb taskCosmos);

        public Task UpdateTaskCosmos(TaskCosmosDb taskCosmos);

        public Task<TaskCosmosDb> GetTaskCosmosById(string id);

        #endregion
    }
}