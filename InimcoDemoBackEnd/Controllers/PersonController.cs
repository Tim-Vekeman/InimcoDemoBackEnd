using InimcoDemoBackEnd.Models;
using InimcoDemoBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace InimcoDemoBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]/persons")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpPost(Name = "AddPerson")]
        public async Task<ActionResult> AddPerson([FromBody] PersonDto person)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!person.IsValid(false)) return BadRequest("Data isn't valid");
            try
            {
                var insertedPerson = await _personService.InsertNewPerson(person);
                return Ok(insertedPerson);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
