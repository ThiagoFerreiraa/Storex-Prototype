using Microsoft.AspNetCore.Mvc;
using StorexWebAPI.Models;
using StorexWebAPI.Services;

namespace StorexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Person>>> GetPeople()
        {
            try
            {
                var people = await _personService.GetPeople();

                return Ok(people);
            }
            catch
            {
                //return BadRequest("");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to find people !");
            }
        }

        [HttpGet]
        [Route("FindPersonByName")]
        public async Task<ActionResult<IAsyncEnumerable<Person>>> GetPersonByName([FromQuery] string name)
        {
            try
            {
                var people = await _personService.GetPersonByName(name);
                if (people == null)
                {
                    return NotFound($"Do not exist person with this name {name}");
                }

                return Ok(people);
            }
            catch
            {

                return BadRequest("Error to find specific person ");
            }
        }

        [HttpGet]
        [Route("FindPersonByID/{id:int}", Name = "GetPerson")]
        public async Task<ActionResult<IAsyncEnumerable<Person>>> GetPersonByID(int id)
        {
            try
            {
                var person = await _personService.GetPerson(id);
                if (person == null)
                    return NotFound($"Not found person with ID {id}");

                return Ok(person);
            }
            catch
            {

                return BadRequest("Not Found Object Person");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreatePerson(Person person)
        {
            try
            {
                await _personService.CreatePerson(person);
                //return CreatedAtRoute(nameof(GetPersonByID), new { id = person.Id, person});

                return Ok($"Person add success {person.Id}");

            }
            catch (Exception)
            {

                return BadRequest($"Error");
            }
        }

        [HttpPut]
        [Route ("UpdatePerson")]
        public async Task<ActionResult> UpdatePerson(int id, [FromBody] Person person)
        {
            try
            {
                if(person.Id == id)
                {
                    await _personService.UpdatePerson(person);

                    return Ok($"Update person realize with success, id {id}");

                }
                else
                {
                    return BadRequest("Incomplete Data");
                }
            }
            catch 
            {
                return BadRequest("Incomplete Data");
            }
        }

        [HttpDelete]
        [Route("DeletePerson")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            try
            {
                var person = await _personService.GetPerson(id);

                if (person != null)
                {
                    await _personService.DeletePerson(person);

                    return Ok($"This person was deleted");
                }
                else
                {
                    return BadRequest($"Person not found , id {id}");
                }
            }
            catch
            {
                return BadRequest("Incomplete Data");
            }
        }
    }
}
