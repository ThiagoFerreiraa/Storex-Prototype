using Microsoft.EntityFrameworkCore;
using StorexWebAPI.Data;
using StorexWebAPI.Models;

namespace StorexWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<IEnumerable<dynamic>> GetUsers()
        {
            try
            {
                var response = (from u in _dataContext.User
                                join p in _dataContext.Person on u.PersonId equals p.Id
                                select new
                                {
                                    name = p.Name,
                                    user = u.Username,
                                }
                                 ).ToList();

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
