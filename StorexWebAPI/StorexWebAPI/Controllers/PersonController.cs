using Microsoft.AspNetCore.Mvc;
using StorexWebAPI.Models;
using StorexWebAPI.Services;
using StorexWebAPI.Repository;

namespace StorexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public PersonController(UnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Person>>>> GetAll()
        {
            var response = new ServiceResponse<List<Person>>();
            try
            {
                var people = await _unitOfWork.Personpository.GetAllAsync();
                if (people is null)
                {
                    response.SuccessResponse(message: "Anybody has been found!");
                }
                else
                {
                    response.SuccessResponse(data: people.ToList());
                }
            }
            catch(Exception e)
            {
                //return BadRequest("");
                //return StatusCode(StatusCodes.Status500InternalServerError, "Error to find people !");
                response.FailResponse(message: e.Message);
            }
            return response.IsFail() ? BadRequest(response) : Ok(response);
        }

        [HttpGet]
        [Route("FindPersonByName")]
        public async Task<ActionResult<ServiceResponse<Person>>> GetByName([FromQuery] string name)
        {
            var response = new ServiceResponse<Person>();
            try
            {
                Person? people = (await _unitOfWork.Personpository.GetAllAsync())?
                    .FirstOrDefault(person => person.Name.Equals(name));
                if (people is null)
                {
                    response.SuccessResponse(message: $"Do not exist person with this name {name}");
                }
                else
                {
                    response.SuccessResponse(data: people);
                }
            }
            catch(Exception e)
            {
                response.FailResponse(message: e.Message);
            }

            return response.IsFail()? BadRequest(response) : Ok(response);
        }

        [HttpGet]
        [Route("FindPersonByID/{id:int}", Name = "GetPerson")]
        public async Task<ActionResult<ServiceResponse<Person>>> GetByID(int id)
        {
            var response = new ServiceResponse<Person>();
            try
            {
                var person = await _unitOfWork.Personpository.GetByIdAsync(id);
                if (person is null)
                {
                    response.SuccessResponse(message: $"Anyone has ben found with this ID: ${id}");
                }
                else
                {
                    response.SuccessResponse(data: person);
                }
            }
            catch(Exception e)
            {
                response.FailResponse(message: e.Message);
            }

            return response.IsFail() ? BadRequest(response) : Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<bool>>> Create(Person person)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                string guid = new Guid().ToString();
                person.Guid = guid;
                await _unitOfWork.Personpository.InsertAsync(person);
                Person createdPerson = (await _unitOfWork.Personpository.GetAllAsync())!
                    .FirstOrDefault(person => person.Guid == guid)!;
              
                response.SuccessResponse(message: $"Person add success {person.Id}");

            }
            catch (Exception e)
            {
                response.FailResponse(message: e.Message);
            }

            return response.IsFail() ? BadRequest(response) : Ok(response);
        }

        [HttpPut]
        [Route ("UpdatePerson")]
        public ActionResult<ServiceResponse<bool>> Update(int id, [FromBody] Person person)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                if(person.Id == id)
                {
                    _unitOfWork.Personpository.Update(person);
                    response.SuccessResponse();
                }
                else
                {
                    response.FailResponse(message: "Invalid data");
                }
            }
            catch (Exception e)
            {
                response.FailResponse(message: e.Message);
            }

            return response.IsFail() ? BadRequest(response) : Ok(response);
        }

        [HttpDelete]
        [Route("DeletePerson")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeletePerson(int id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var person = await _unitOfWork.Personpository.GetByIdAsync(id);

                if (person is not null)
                {
                    _unitOfWork.Personpository.Delete(person);
                    response.SuccessResponse(message: "This person was deleted");
                }
                else
                {
                    response.FailResponse(message: $"Person not found, id {id}");
                }
            }
            catch(Exception e)
            {
                response.FailResponse(message: e.Message);
            }

            return response.IsFail() ? BadRequest(response) : Ok(response);
        }
    }
}
