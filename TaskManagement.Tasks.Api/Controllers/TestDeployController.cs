using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Tasks.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestDeployController : ControllerBase
    {
        private readonly ILogger<TestDeployController> _logger;

        public TestDeployController(ILogger<TestDeployController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult EstaFuncionando ()
        {
            return Ok("El hijo de puta funciona");
        }
    }
}