using InimcoDemoBackEnd.Models;
using InimcoDemoBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace InimcoDemoBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;
        private readonly IPersonService _personService;

        public PersonsController(ILogger<PersonsController> logger, IPersonService personService)
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

        //* Extended person calls
        //TODO: change to uint (need to build a custom route constraint)
        [HttpGet("extended/{id}", Name = "GetExtendedPerson")]
        public async Task<ActionResult> GetExtendedPerson(uint id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var requestedPerson = await _personService.GetExtendedPersonById(id);
                return Ok(requestedPerson);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
