using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorexWebAPI.Models;
using StorexWebAPI.Services;

namespace StorexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Client>>> GetClients()
        {
            try
            {
                var clients = await _clientService.GetClients();

                return Ok(clients);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
