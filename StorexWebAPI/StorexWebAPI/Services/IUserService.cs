using StorexWebAPI.Models;

namespace StorexWebAPI.Services
{
    public interface IUserService
    {

        public Task<IEnumerable<dynamic>> GetUsers();
    }
}
