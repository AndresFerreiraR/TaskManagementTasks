using TaskManagement.Tasks.Application.Dto;
using TaskManagement.Tasks.Common.Common.Responses;

namespace TaskManagement.Tasks.Application.Interfaces
{
    public interface ITaskBL
    {
        public Task<Response<List<TaskCosmosDbDto>>> GetListTaskFromCosmosDb();
        public Task<Response<bool>> CreateTaskCosmos(TaskCosmosDbDto taskCosmos);
        public Task<Response<bool>> UpdateTaskCosmos(TaskCosmosDbDto taskCosmos);
        public Task<Response<TaskCosmosDbDto>> GetTaskCosmosDbById(string id);
    }
}