using Microsoft.AspNetCore.Mvc;
using TaskManagement.Tasks.Application.Dto;
using TaskManagement.Tasks.Application.Interfaces;

namespace TaskManagement.Tasks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskBL _business;

        public TasksController( ITaskBL business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _business.GetAllTasks();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(string id)
        {
            var response = await _business.GetTaskById(Guid.Parse(id));
            return Ok(response);
        }

        [HttpPost("GetTaskByFilter")]
        public async Task<IActionResult> GetTaskByFilter(TaskItemDto task)
        {
            var response = await _business.GetTasksByFilter(task);
            return Ok(response);
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask(TaskItemDto task)
        {
            var response = await _business.CreateTask(task);
            return Ok(response);
        }

        [HttpPut("UpdateTask/{id}")]
        public async Task<IActionResult> UpdateTask(string id, TaskItemDto task)
        {
            var response = await _business.CreateTask(task);
            return Ok(response);
        }

        [HttpGet("GetTaskFromCosmosDb")]
        public async Task<IActionResult> GetListTaskFromCosmosDb()
        {
            var response = await _business.GetListTaskFromCosmosDb();
            return Ok(response);
        }

        [HttpPost("CreateCosmosTask")]
        public async Task<IActionResult> CreateCosmosTask(TaskCosmosDbDto cosmosTask)
        {
            var response =  await _business.CreateTaskCosmos(cosmosTask);
            return Ok(response);
        }

        [HttpPut("UpdateTaskCosmos")]
        public async Task<IActionResult> UpdateCosmosTask(TaskCosmosDbDto cosmosTask)
        {
            var response =  await _business.UpdateTaskCosmos(cosmosTask);
            return Ok(response);
        }

        [HttpGet("GetTaskCosmosById/{id}")]
        public async Task<IActionResult> GetTaskCosmosById(string id)
        {
            var response =  await _business.GetTaskCosmosDbById(id);
            return Ok(response);
        }

        [HttpGet("Saludo/{saludo}")]
        public IActionResult SaludoMethod(string saludo)
        {
            var response = $"Hola {saludo}";
            return Ok(response);
        }
    }
}