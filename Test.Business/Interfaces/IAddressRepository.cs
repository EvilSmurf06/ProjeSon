using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Database.Model_Map;
using Test.Database.Models;

namespace Test.Business.Interfaces
{
    public interface IAddressRepository :IGenericRepository<Address>

    {
        IEnumerable<Address> OrderByAdrId(int count);
        IEnumerable<Address> OrderByAdrId2(int count);
    }
}
