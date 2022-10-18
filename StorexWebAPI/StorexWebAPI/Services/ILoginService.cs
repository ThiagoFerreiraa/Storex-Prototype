using StorexWebAPI.Models;
using StorexWebAPI.Models.Dtos;

namespace StorexWebAPI.Services
{
    public interface ILoginService
    {     
        Task<UserDto> Authentication(UserDto user);
    }
}
