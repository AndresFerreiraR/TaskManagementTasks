using TaskManagement.Tasks.Application.Dto;
using TaskManagement.Tasks.Common.Common.Responses;

namespace TaskManagement.Tasks.Application.Interfaces
{
    public interface ITaskBL
    {
        Task<Response<List<TaskCosmosDbDto>>> GetListTaskFromCosmosDb();
        Task<Response<bool>> CreateTaskCosmos(TaskCosmosDbDto taskCosmos);
        Task<Response<bool>> UpdateTaskCosmos(TaskCosmosDbDto taskCosmos);
        Task<Response<TaskCosmosDbDto>> GetTaskCosmosDbById(string id);
        Task<Response<List<CardTaskDto>>> GetTaskCardByProjectId(string projectId);
        Task<Response<bool>> UpdateTaskState(TaskCosmosDbDto taskCard);
    }
}