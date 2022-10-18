using Microsoft.EntityFrameworkCore;
using StorexWebAPI.Data;
using StorexWebAPI.Models;

namespace StorexWebAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly DataContext _dataContext;

        public ClientService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            try
            {
                return await _dataContext.Client.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
