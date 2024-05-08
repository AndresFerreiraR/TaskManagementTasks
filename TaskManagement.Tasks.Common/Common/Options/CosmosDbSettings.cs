namespace TaskManagement.Tasks.Common.Common.Options
{
    public class CosmosDbSettings
    {
        public const string Options = "CosmosDbSettings";
        public string BaseUrl { get; set; }
        public string PrimaryKey { get; set; }
        public string DatabaseName { get; set; }
        public string ContainerName { get; set; }
        public string ConnectionString { get; set; }
    }
}