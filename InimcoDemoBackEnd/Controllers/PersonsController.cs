using InimcoDemoBackEnd.Models;
using InimcoDemoBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace InimcoDemoBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        #region Fields
        private readonly ILogger<PersonsController> _logger;
        private readonly IPersonService _personService;
        #endregion

        #region Contstructors
        public PersonsController(ILogger<PersonsController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }
        #endregion

        #region Api-endpoints
        [HttpPost(Name = "AddPerson")]
        public async Task<ActionResult> AddPerson([FromBody] PersonDto person)
        {
            _logger.LogInformation(String.Concat("started adding a person: ", person.Firstname, " ", person.Lastname));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!person.IsValid(false)) return BadRequest("Data isn't valid");
            try
            {
                var insertedPerson = await _personService.InsertNewPerson(person);
                _logger.LogInformation(String.Concat("Successfully added a person: ", insertedPerson.Firstname, " ", insertedPerson.Lastname, ". With id: ", insertedPerson.Id));
                return Ok(insertedPerson);
            }
            catch(Exception ex)
            {
                _logger.LogError(String.Concat("Error while adding person: ", person.Firstname, " ", person.Lastname, ". Error:\n", ex.Message));
                return StatusCode(500);
            }
        }
        #endregion

        #region Extended person calls

        [HttpGet("extended/{id}", Name = "GetExtendedPerson")]
        public async Task<ActionResult> GetExtendedPerson(uint id)
        {
            _logger.LogInformation("started get extended person with id: " + id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var requestedPerson = await _personService.GetExtendedPersonById(id);
                _logger.LogInformation("Successfully retuned extended person with id: " + id);
                return Ok(requestedPerson);
            }
            catch(Exception ex)
            {
                _logger.LogError(String.Concat("Error while getting extended person with id: ", id, ". Error:\n", ex.Message));
                return StatusCode(500);
            }
        }
        #endregion
    }
}
