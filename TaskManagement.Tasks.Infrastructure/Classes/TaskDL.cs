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
        private readonly CosmosDbContext _cosmosContext;
        private readonly ILogger<TaskDL> _logger;
        public TaskDL(ILogger<TaskDL> logger, CosmosDbContext cosmosContext)
        {
            _logger = logger;
            _cosmosContext = cosmosContext;
        }

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