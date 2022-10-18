using Microsoft.EntityFrameworkCore;
using StorexWebAPI.Data;
using StorexWebAPI.Models;

namespace StorexWebAPI.Services
{
    public class PersonService: IPersonService
    {
        private readonly DataContext _datacontext;

        public PersonService(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            try
            {
                return await _datacontext.Person.ToListAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<Person>> GetPersonByName(string name)
        {
            IEnumerable<Person> people;
            if (!string.IsNullOrEmpty(name))
            {
                people = await _datacontext.Person.Where(obj => obj.Name.Contains(name)).ToListAsync();
            }
            else
            {
                people = await GetPeople();
            }

            return people;
        }

        public async Task<Person> GetPerson(int id)
        {
            var person = await _datacontext.Person.FindAsync(id);

            return person;
        }


        public async Task CreatePerson(Person person)
        {
            _datacontext.Person.Add(person);
            await _datacontext.SaveChangesAsync();
        }

        public async Task UpdatePerson(Person person)
        {
            _datacontext.Entry(person).State = EntityState.Modified;
            await _datacontext.SaveChangesAsync();
        }

        public async Task DeletePerson(Person person)
        {
            _datacontext.Person.Remove(person);
            await _datacontext.SaveChangesAsync();
        }

        //User querys
        //public async Task<IEnumerable<Person>> GetUserByUserName(string username)
        //{

        //    IEnumerable<Person> user;

        //    try
        //    {
        //        user = await _datacontext.Person.Where(obj => obj.Username.Contains(username)).ToListAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }


        //    return user;

        //}
    }
}
