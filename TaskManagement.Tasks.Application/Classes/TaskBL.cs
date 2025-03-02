
namespace TaskManagement.Tasks.Application.Classes
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using TaskManagement.Tasks.Application.Dto;
    using TaskManagement.Tasks.Application.Interfaces;
    using TaskManagement.Tasks.Common.Common.Resources;
    using TaskManagement.Tasks.Common.Common.Responses;
    using TaskManagement.Tasks.Common.Mapper;
    using TaskManagement.Tasks.Domain.Entities;
    using TaskManagement.Tasks.Infrastructure.Interfaces;

    public class TaskBL : ITaskBL
    {
        private readonly ITaskDL _repoTask;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskBL> _logger;

        public TaskBL(ITaskDL repoTask,
                      IMapper mapper,
                      ILogger<TaskBL> logger)
        {
            _repoTask = repoTask;
            _mapper = mapper;
            _logger = logger;
        }

       #region CosmosDb

        public async Task<Response<List<TaskCosmosDbDto>>> GetListTaskFromCosmosDb()
        {
            Response<List<TaskCosmosDbDto>> response = new();
            _logger.LogInformation($"From Class {nameof(TaskBL)} an method {nameof(GetListTaskFromCosmosDb)} list cosmosTask");
            var entity = await _repoTask.GetListTaskFromCosmosDb();
            var taskItemDto = _mapper.Map<List<TaskCosmosDbDto>>(entity);

            if (taskItemDto.Any())
            {
                response.IsSuccess = true;
                response.Data = taskItemDto;
            }
            else
            {
                response.IsSuccess = true;
                response.Message = TextResources.RECORS_NO_FOUND;
            }

            return response;
        }

        public async Task<Response<bool>> CreateTaskCosmos(TaskCosmosDbDto taskCosmos)
        {
            Response<bool> response = new();

            taskCosmos.Id = string.IsNullOrEmpty(taskCosmos.Id) || 
                            Guid.Parse(taskCosmos.Id) == default ? 
                            Guid.NewGuid().ToString() : taskCosmos.Id;
            taskCosmos.TaskId = taskCosmos.Id;
            taskCosmos.CreationDate = DateTime.Now.Date;
            var taskEntity = _mapper.Map<TaskCosmosDb>(taskCosmos);
            await _repoTask.CreateTaskCosmos(taskEntity);

            response.IsSuccess = true;
            response.Message = TextResources.RECORD_CREATED;

            return response;
        }


        public async Task<Response<bool>> UpdateTaskCosmos(TaskCosmosDbDto taskCosmos)
        {
            Response<bool> response = new();

            if(taskCosmos.Comments.Any())
            {
                taskCosmos.Comments.Where(c => c.Id == default).ToList().ForEach(c => 
                {
                    c.Id = Guid.NewGuid();
                });
            }

            var taskEntity = _mapper.Map<TaskCosmosDb>(taskCosmos);
            await _repoTask.UpdateTaskCosmos(taskEntity);

            response.IsSuccess = true;
            response.Message = TextResources.RECORD_UPDATED;

            return response;
        }


        public async Task<Response<TaskCosmosDbDto>> GetTaskCosmosDbById(string id)
        {
            Response<TaskCosmosDbDto> response = new();

            var cosomosentity = await _repoTask.GetTaskCosmosById(id);
            var taskDto = _mapper.Map<TaskCosmosDbDto>(cosomosentity);

            response.Data = taskDto;
            response.IsSuccess = true;

            return response;
        }

        public async Task<Response<List<CardTaskDto>>> GetTaskCardByProjectId(string projectId)
        {
            Response<List<CardTaskDto>> response = new();

            var cosomosentity = await _repoTask.GetTaskCardByProjectId(projectId);
            var taskDto = _mapper.Map<List<CardTaskDto>>(cosomosentity);

            response.Data = taskDto;
            response.IsSuccess = true;

            return response;
        }

        public async Task<Response<bool>> UpdateTaskState(TaskCosmosDbDto taskCosmosDbDto)
        {
            Response<bool> response = new();
            var taskEntity = _mapper.Map<TaskCosmosDb>(taskCosmosDbDto);
            await _repoTask.UpdateTaskState(taskEntity);

            response.IsSuccess = true;
            response.Data = true;
 
            return response;
        }

        #endregion
    }
}