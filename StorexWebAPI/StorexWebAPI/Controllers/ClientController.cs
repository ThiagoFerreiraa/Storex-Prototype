using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorexWebAPI.Models;
using StorexWebAPI.Services;
using StorexWebAPI.Repository;

namespace StorexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClientController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public ClientController(UnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Client>>>> GetAll()
        {
            var response = new ServiceResponse<List<Client>>();
            try
            {
          
                var clients = await _unitOfWork.ClientRepository.GetAllAsync(includeProperties:"Person");
                if (clients is null)
                {
                    response.SuccessResponse(message: "Any client found");
                }
                else
                {
                    response.SuccessResponse(data: clients.ToList());
                }
            }
            catch (Exception e)
            {
                response.FailResponse(message: e.Message);
            }

            if (response.IsFail())
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
