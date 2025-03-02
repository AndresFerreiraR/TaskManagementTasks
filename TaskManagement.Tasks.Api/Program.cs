using Microsoft.EntityFrameworkCore;
using TaskManagement.Tasks.Infrastructure.Contexts;
using TaskManagement.Tasks.Application;
using TaskManagement.Tasks.Infrastructure;
using TaskManagement.Tasks.Common.Common.Options;
using Azure.Identity;
using TaskManagement.Tasks.Api.Modules.Injection;
using TaskManagement.Tasks.Api.Modules.Middlewares;

var MyCorsPolicy = "MyPolicy";

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();


var keyVaultName = builder.Configuration["KeyVaultName"];
var keyVaultUri = new Uri($"https://{keyVaultName}.vault.azure.net/");
builder.Configuration.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());

builder.Services.Configure<CosmosDbSettings>(options =>
{
    var jsonSecret = builder.Configuration["CosmosDbSettings"];
    if (jsonSecret != null)
    {
        var settings = System.Text.Json.JsonSerializer.Deserialize<CosmosDbSettings>(jsonSecret);
        options.BaseUrl = settings?.BaseUrl;
        options.PrimaryKey = settings?.PrimaryKey;
        options.DatabaseName = settings?.DatabaseName;
        options.ContainerName = settings?.ContainerName;
        options.ConnectionString = settings?.ConnectionString;
    }
});

string myPolicy = "PolicyApiEcommerce";

builder.Services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.AllowAnyOrigin()
                                                                               .AllowAnyHeader()
                                                                               .AllowAnyMethod()));

builder.Services.AddInjection();


builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(myPolicy);
app.UseHttpsRedirection();
app.MapControllers();
app.AddMiddleware();
app.Run();