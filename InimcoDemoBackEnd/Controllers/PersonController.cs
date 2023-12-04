using InimcoDemoBackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace InimcoDemoBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]/Person")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "AddPerson")]
        public async Task<ActionResult> AddPerson([FromBody] PersonDto person)
        {
            return Ok();
        }
    }
}
