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

        public TasksController(ITaskBL business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<IActionResult> GetListTaskFromCosmosDb()
        {
            var response = await _business.GetListTaskFromCosmosDb();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCosmosTask(TaskCosmosDbDto cosmosTask)
        {
            var response = await _business.CreateTaskCosmos(cosmosTask);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCosmosTask(TaskCosmosDbDto cosmosTask)
        {
            var response = await _business.UpdateTaskCosmos(cosmosTask);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskCosmosById(string id)
        {
            var response = await _business.GetTaskCosmosDbById(id);
            return Ok(response);
        }

        [HttpGet("GetTaskCardByProjectId")]
        public async Task<IActionResult> GetTaskCardByProjectId([FromQuery] string projectId)
        {
            var response = await _business.GetTaskCardByProjectId(projectId);
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> GetTaskCardByProjectId(string id, [FromBody] TaskCosmosDbDto cosmosDto)
        {
            cosmosDto.Id = id;
            cosmosDto.TaskId = id;
            var response = await _business.UpdateTaskState(cosmosDto);
            return Ok(response);
        }
    }
}