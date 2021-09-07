using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using New.Test.Database;
using Test.Business.Interfaces;
using Test.Business.Repositories;

namespace Test.Business.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdventureWorks2019Context _context;
        public UnitOfWork(AdventureWorks2019Context context)
        {
            _context = context;
         
            People = new PersonRepository(_context);

            Address = new AddressRepository(_context);

            Entity = new EntityRepository(_context);
        }
       
        public IPersonRepository People { get; private set; }
        public IAddressRepository Address { get; private set; }
        public IEntityRepository Entity { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
