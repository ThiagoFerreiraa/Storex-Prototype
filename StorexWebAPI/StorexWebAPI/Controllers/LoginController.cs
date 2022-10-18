using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorexWebAPI.Models;
using StorexWebAPI.Models.Dtos;
using StorexWebAPI.Services;

namespace StorexWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("Authentication")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(UserDto request)
        {
            try
            {

                var user = await _loginService.Authentication(request);


                if (user.Status == true)
                {
                    var token = TokenService.GenerateToken(request);

                    request.Token = token;
                    request.Role = user.Role;

                    return Ok(request);
                }
                else
                {
                    return Ok(request);
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

    }
}
