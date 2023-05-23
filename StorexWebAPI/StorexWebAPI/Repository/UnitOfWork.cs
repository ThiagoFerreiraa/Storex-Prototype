using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorexWebAPI.Models;
using StorexWebAPI.Data;

namespace StorexWebAPI.Repository
{
    public class UnitOfWork : IDisposable
    {
        private DataContext _context;
        private GenericRepository<Client>? _clientRepository;
        private GenericRepository<Person>? _personRepository;
        private GenericRepository<Product>? _productRepository;
        private GenericRepository<Sales>? _salesRepository;
        private GenericRepository<Storage>? _storageRepository;
        private GenericRepository<User>? _userRepository;
        private GenericRepository<Distributed>? _distributedRepository;
        



        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public GenericRepository<Client> ClientRepository
        {
            get
            {

                if (this._clientRepository is null)
                {
                    this._clientRepository = new GenericRepository<Client>(_context);
                }
                return this._clientRepository;
            }
        }

        public GenericRepository<Person> Personpository
        {
            get
            {

                if (this._personRepository is null)
                {
                    this._personRepository = new GenericRepository<Person>(_context);
                }
                return this._personRepository;
            }
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {

                if (this._productRepository is null)
                {
                    this._productRepository = new GenericRepository<Product>(_context);
                }
                return _productRepository;
            }
        }

        public GenericRepository<Sales> SalesRepository
        {
            get
            {

                if (this._salesRepository is null)
                {
                    this._salesRepository = new GenericRepository<Sales>(_context);
                }
                return this._salesRepository;
            }
        }

        public GenericRepository<Storage> StorageRepository
        {
            get
            {

                if (this._storageRepository is null)
                {
                    this._storageRepository = new GenericRepository<Storage>(_context);
                }
                return this._storageRepository;
            }
        }
    
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository is null)
                {
                    this._userRepository = new GenericRepository<User>(_context);
                }
                return this._userRepository;
            }
        }

         public GenericRepository<Distributed> DistributedRepository
        {
            get
            {
                if (this._distributedRepository is null)
                {
                    this._distributedRepository = new GenericRepository<Distributed>(_context);
                }
                return this._distributedRepository;
            }
        }
       

        
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}