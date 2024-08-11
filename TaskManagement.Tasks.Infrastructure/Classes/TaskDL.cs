using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskManagement.Tasks.Domain.Entities;
using TaskManagement.Tasks.Infrastructure.Contexts;
using TaskManagement.Tasks.Infrastructure.Interfaces;

namespace TaskManagement.Tasks.Infrastructure.Classes
{
    public class TaskDL : ITaskDL
    {
        private readonly TaskContext _context;
        private readonly CosmosDbContext _cosmosContext;
        private readonly ILogger<TaskDL> _logger;
        public TaskDL(TaskContext context, ILogger<TaskDL> logger, CosmosDbContext cosmosContext)
        {
            _context = context;
            _logger = logger;
            _cosmosContext = cosmosContext;
        }

        #region Sql Server
        public async Task CreateTask(TaskItem task)
        {
            try
            {
                await _context.TaskItem.AddAsync(task);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"layer data error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TaskItem>> GetAllTasks()
        {
            try
            {
                var listTasks = await _context.TaskItem
                                              .Include(s => s.State)
                                              .Include(p => p.Priority)
                                              .Include(c => c.TaskCommets)
                                              .ToListAsync();

                return listTasks;
            }
            catch (Exception ex)
            {
                _logger.LogError($"layer data error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<TaskItem> GetTaskById(Guid id)
        {
            try
            {
                var taskEntity = await _context.TaskItem
                                               .Include(s => s.State)
                                               .Include(p => p.Priority)
                                               .Include(c => c.TaskCommets)
                                               .FirstOrDefaultAsync(t => t.TaskItemId == id);

                return taskEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"layer data error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<TaskItem>> GetTasksByFilter(TaskItem task)
        {
            try
            {
                var taskEntity = await _context.TaskItem
                                               .Include(s => s.State)
                                               .Include(p => p.Priority)
                                               .Include(c => c.TaskCommets)
                                               .Where(t => task.TaskItemName.Contains(t.TaskItemName))
                                               .ToListAsync();

                return taskEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"layer data error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateTask(TaskItem task)
        {
            try
            {
                var taskEntity = await _context.TaskItem.FirstOrDefaultAsync(x => x.TaskItemId == task.TaskItemId);

                if (taskEntity is not null)
                {
                    taskEntity.TaskItemName = task.TaskItemName;
                    taskEntity.TaskItemDescription = task.TaskItemDescription;
                    taskEntity.TaskItemStart = task.TaskItemStart;
                    taskEntity.TaskItemEnd = task.TaskItemEnd;
                    taskEntity.TaskItemCreated = task.TaskItemCreated;
                    taskEntity.OriginalTimeEstimated = task.OriginalTimeEstimated;
                    taskEntity.RemainingTime = task.RemainingTime;
                    taskEntity.CompletedTime = task.CompletedTime;
                    taskEntity.UserId = task.UserId;
                    taskEntity.Priority = task.Priority;
                    taskEntity.State = task.State;
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"layer data error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Cosmos Db

        public async Task<List<TaskCosmosDb>> GetListTaskFromCosmosDb()
        {
            try
            {
                List<TaskCosmosDb> listResult = new();
                var sqlQueryCommand = "SELECT * FROM c";
                var query = _cosmosContext._container.GetItemQueryIterator<TaskCosmosDb>(new QueryDefinition(sqlQueryCommand));

                while (query.HasMoreResults)
                {
                    _logger.LogInformation($"{DateTime.UtcNow} ** Tratando de consultar consmos Db ** ");
                    var response = await query.ReadNextAsync();
                    _logger.LogInformation($"{DateTime.UtcNow} Se consulto consmos Db");
                    listResult.AddRange(response);
                }

                return listResult;

            }
            catch (Exception ex)
            {
                _logger.LogError($"layer data error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }


        public async Task CreateTaskCosmos(TaskCosmosDb taskCosmos)
        {
            try
            {
                await _cosmosContext._container.CreateItemAsync(taskCosmos, new PartitionKey(taskCosmos.Name));
            }
            catch (Exception ex)
            {
                _logger.LogError($"layer data error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateTaskCosmos(TaskCosmosDb taskCosmos)
        {
            try
            {
                await _cosmosContext._container.UpsertItemAsync<TaskCosmosDb>(taskCosmos, new PartitionKey(taskCosmos.Name));
            }
            catch (Exception ex)
            {
                _logger.LogError($"layer data error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }


        public async Task<TaskCosmosDb> GetTaskCosmosById(string id)
        {
            try
            {
                // var task = await _cosmosContext._container.ReadItemAsync<TaskCosmosDb>(id.ToString(), new PartitionKey("Id"));
                // var aaa = task.Resource;
                List<TaskCosmosDb> listResult = new();
                var sqlQueryCommand = $"SELECT * FROM c WHERE c.id = '{id}'";
                var query = _cosmosContext._container.GetItemQueryIterator<TaskCosmosDb>(new QueryDefinition(sqlQueryCommand));

                while (query.HasMoreResults)
                {
                    _logger.LogInformation($"{DateTime.UtcNow} ** Tratando de consultar consmos Db ** ");
                    var response = await query.ReadNextAsync();
                    _logger.LogInformation($"{DateTime.UtcNow} Se consulto consmos Db");
                    listResult.AddRange(response);
                }
                return listResult.FirstOrDefault()!;
            }
            catch (Exception ex)
            {
                _logger.LogError($"layer data error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateTaskCosmosPatch(TaskCosmosDb taskCosmos)
        {
            try
            {
                await _cosmosContext._container.UpsertItemAsync<TaskCosmosDb>(taskCosmos, new PartitionKey(taskCosmos.Name));
            }
            catch (Exception ex)
            {
                _logger.LogError($"layer data error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }

    #endregion
}