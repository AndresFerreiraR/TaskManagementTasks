
namespace TaskManagement.Tasks.Application.Classes
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using TaskManagement.Tasks.Application.Dto;
    using TaskManagement.Tasks.Application.Interfaces;
    using TaskManagement.Tasks.Common.Common.Resources;
    using TaskManagement.Tasks.Common.Common.Responses;
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

        #region SqlServer
        public async Task<Response<bool>> CreateTask(TaskItemDto task)
        {
            Response<bool> response = new();
            try
            {
                var taskEntity = _mapper.Map<TaskItem>(task);
                await _repoTask.CreateTask(taskEntity);

                response.IsSuccess = true;
                response.Message = TextResources.RECORD_CREATED;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.UtcNow} exception {ex.Message}");
                response.IsSuccess = false;
                response.Message = String.Format(TextResources.ERROR_MESSAGE, "TaskBL", ex.Message);
            }
            return response;
        }


        public async Task<Response<List<TaskItemDto>>> GetAllTasks()
        {
            Response<List<TaskItemDto>> response = new();
            try
            {
                var entity = await _repoTask.GetAllTasks();
                var taskItemDto = _mapper.Map<List<TaskItemDto>>(entity);

                if (taskItemDto.Any())
                {
                    response.IsSuccess = true;
                    response.Data = taskItemDto;
                }
                else
                {
                    response.IsSuccess = true;
                    response.Data = taskItemDto;
                    response.Message = TextResources.RECORS_NO_FOUND;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.UtcNow} exception {ex.Message}");
                response.IsSuccess = false;
                response.Message = String.Format(TextResources.ERROR_MESSAGE, "TaskBL", ex.Message);
            }
            return response;
        }


        public async Task<Response<TaskItemDto>> GetTaskById(Guid id)
        {
            Response<TaskItemDto> response = new();
            try
            {
                var entity = await _repoTask.GetTaskById(id);
                var taskItemDto = _mapper.Map<TaskItemDto>(entity);

                if (taskItemDto is not null)
                {
                    response.IsSuccess = true;
                    response.Data = taskItemDto;
                }
                else
                {
                    response.IsSuccess = true;
                    response.Message = TextResources.RECORS_NO_FOUND;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.UtcNow} exception {ex.Message}");
                response.IsSuccess = false;
                response.Message = String.Format(TextResources.ERROR_MESSAGE, "TaskBL", ex.Message);
            }
            return response;
        }

        public async Task<Response<List<TaskItemDto>>> GetTasksByFilter(TaskItemDto task)
        {
            Response<List<TaskItemDto>> response = new();
            try
            {
                var entity = _mapper.Map<TaskItem>(task);
                var entityResponse = await _repoTask.GetTasksByFilter(entity);
                var blData = _mapper.Map<List<TaskItemDto>>(entityResponse);

                if (blData.Any())
                {
                    response.IsSuccess = true;
                    response.Data = blData;
                }
                else
                {
                    response.IsSuccess = true;
                    response.Message = TextResources.RECORS_NO_FOUND;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.UtcNow} exception {ex.Message}");
                response.IsSuccess = false;
                response.Message = String.Format(TextResources.ERROR_MESSAGE, "TaskBL", ex.Message);
            }
            return response;
        }

        public async Task<Response<bool>> UpdateTask(TaskItemDto task)
        {
            Response<bool> response = new();
            try
            {
                var taskEntity = _mapper.Map<TaskItem>(task);
                await _repoTask.CreateTask(taskEntity);

                response.IsSuccess = true;
                response.Message = TextResources.RECORD_CREATED;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.UtcNow} exception {ex.Message}");
                response.IsSuccess = false;
                response.Message = String.Format(TextResources.ERROR_MESSAGE, "TaskBL", ex.Message);
            }
            return response;
        }

        #endregion


        #region CosmosDb

        public async Task<Response<List<TaskCosmosDbDto>>> GetListTaskFromCosmosDb()
        {
            Response<List<TaskCosmosDbDto>> response = new();
            try
            {
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
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.UtcNow} exception {ex.Message}");
                response.IsSuccess = false;
                response.Message = String.Format(TextResources.ERROR_MESSAGE, "TaskBL", ex.Message);
            }
            return response;
        }

        public async Task<Response<bool>> CreateTaskCosmos(TaskCosmosDbDto taskCosmos)
        {
            Response<bool> response = new();
            try
            {
                taskCosmos.TaskItemId = taskCosmos.TaskItemId == default ? Guid.NewGuid() : taskCosmos.TaskItemId;
                taskCosmos.TaskItemCreated = DateTime.Now.Date;
                var taskEntity = _mapper.Map<TaskCosmosDb>(taskCosmos);
                await _repoTask.CreateTaskCosmos(taskEntity);

                response.IsSuccess = true;
                response.Message = TextResources.RECORD_CREATED;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.UtcNow} exception {ex.Message}");
                response.IsSuccess = false;
                response.Message = String.Format(TextResources.ERROR_MESSAGE, "TaskBL", ex.Message);
            }
            return response;
        }


        public async Task<Response<bool>> UpdateTaskCosmos(TaskCosmosDbDto taskCosmos)
        {
            Response<bool> response = new();
            try
            {
                taskCosmos.TaskItemId = taskCosmos.TaskItemId == default ? Guid.NewGuid() : taskCosmos.TaskItemId;
                taskCosmos.TaskItemCreated = DateTime.Now.Date;
                var taskEntity = _mapper.Map<TaskCosmosDb>(taskCosmos);
                await _repoTask.UpdateTaskCosmos(taskEntity);

                response.IsSuccess = true;
                response.Message = TextResources.RECORD_CREATED;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.UtcNow} exception {ex.Message}");
                response.IsSuccess = false;
                response.Message = String.Format(TextResources.ERROR_MESSAGE, "TaskBL", ex.Message);
            }
            return response;
        }


        public async Task<Response<TaskCosmosDbDto>> GetTaskCosmosDbById(string id)
        {
            Response<TaskCosmosDbDto> response = new();
            try
            {
                var cosomosentity = await _repoTask.GetTaskCosmosById(id);
                var taskDto = _mapper.Map<TaskCosmosDbDto>(cosomosentity);

                response.Data = taskDto;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.UtcNow} exception {ex.Message}");
                response.IsSuccess = false;
                response.Message = String.Format(TextResources.ERROR_MESSAGE, "TaskBL", ex.Message);
            }
            return response;
        }

        #endregion
    }
}