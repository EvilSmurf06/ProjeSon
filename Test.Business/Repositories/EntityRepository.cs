using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using New.Test.Database;
using Test.Business.Interfaces;
using Test.Database.Model_Map;
using Test.Database.Models;
using Test.Database.Repositories;

namespace Test.Business.Repositories
{
    public class EntityRepository : GenericRepository<BusinessEntity>, IEntityRepository
    {
        public EntityRepository(AdventureWorks2019Context context) : base(context)
        {
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public IEnumerable<Address> OrderByAdrId(int count)
        {
            return _context.Addresses.OrderByDescending(d => d.AddressId).Take(count).ToList();
        }
        public IEnumerable<Address> OrderByAdrId2(int count)
        {
            return _context.Addresses.OrderBy(d => d.AddressId).Take(count).ToList();
        }
    }
}
