using Microsoft.EntityFrameworkCore;
using StorexWebAPI.Models;

namespace StorexWebAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Distributed> Distributed { get; set; }


    }
}
