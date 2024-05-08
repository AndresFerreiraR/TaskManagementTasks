using System.Security;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using TaskManagement.Tasks.Common.Common.Options;

namespace TaskManagement.Tasks.Infrastructure.Contexts
{
    public class CosmosDbContext
    {
        private readonly IOptions<CosmosDbSettings> _options;
        public readonly Container _container;
        public CosmosClient _cosmosClient;
        public string _containerName;
        public string _dbName;


        public CosmosDbContext(IOptions<CosmosDbSettings> options)
        {
            _options = options;
            _cosmosClient = new CosmosClient(options.Value.BaseUrl, _options.Value.PrimaryKey);
            _containerName = options.Value.ContainerName;
            _dbName = options.Value.DatabaseName;
            _container = _cosmosClient.GetContainer(_containerName, _dbName);
        }
    }
}