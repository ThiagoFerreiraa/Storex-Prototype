using StorexWebAPI.Models;

namespace StorexWebAPI.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClients();
    }
}
