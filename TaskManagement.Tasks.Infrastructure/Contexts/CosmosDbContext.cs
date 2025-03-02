using System.Security;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using TaskManagement.Tasks.Common.Common.Options;

namespace TaskManagement.Tasks.Infrastructure.Contexts
{
    public class CosmosDbContext
    {
        private readonly CosmosDbSettings _options;
        public readonly Container _container;
        public CosmosClient _cosmosClient;
        public string _containerName;
        public string _dbName;


        public CosmosDbContext(IOptions<CosmosDbSettings> options)
        {
            _options = options.Value;
            _cosmosClient = new CosmosClient(_options.BaseUrl, _options.PrimaryKey);
            _containerName = _options.ContainerName;
            _dbName = _options.DatabaseName;
            _container = _cosmosClient.GetContainer(_containerName, _dbName);
        }
    }
}