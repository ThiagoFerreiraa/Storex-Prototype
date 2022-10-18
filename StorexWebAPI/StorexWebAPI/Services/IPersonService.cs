using StorexWebAPI.Models;

namespace StorexWebAPI.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetPeople();
        Task<Person> GetPerson(int id);
        Task<IEnumerable<Person>> GetPersonByName(string name);
        Task CreatePerson(Person person);
        Task UpdatePerson(Person person);
        Task DeletePerson(Person person);
        //Task <IEnumerable<Person>>GetUserByUserName(string userName);
    }
}
