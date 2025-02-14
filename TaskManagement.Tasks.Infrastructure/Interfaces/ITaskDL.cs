using TaskManagement.Tasks.Domain.Entities;

namespace TaskManagement.Tasks.Infrastructure.Interfaces
{
    public interface ITaskDL
    {
        #region CosmosDb
        public Task<List<TaskCosmosDb>> GetListTaskFromCosmosDb();
        public Task CreateTaskCosmos(TaskCosmosDb taskCosmos);
        public Task UpdateTaskCosmos(TaskCosmosDb taskCosmos);
        public Task<TaskCosmosDb> GetTaskCosmosById(string id);
        public Task UpdateTaskCosmosPatch(TaskCosmosDb taskCosmos);
        public Task<List<CardTask>> GetTaskCardByProjectId(string projectId);
        public Task UpdateTaskState(TaskCosmosDb taskCosmosDb);

        #endregion
    }
}