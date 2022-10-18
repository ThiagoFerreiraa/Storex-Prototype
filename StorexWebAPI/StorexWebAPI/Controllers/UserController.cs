using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorexWebAPI.Models;
using StorexWebAPI.Services;

namespace StorexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<User>>> GetUser()
        {
            try
            {
                var users = await _userService.GetUsers();

                return Ok(users);
            }
            catch (Exception ex)
            {

                return BadRequest($"Error {ex.Message}");
            }
        }
    }
}
