using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Database.Model_Map;
using Test.Database.Models;

namespace Test.Business.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        IEnumerable<Person> OrderByLN(int count);
        IEnumerable<Person> OrderByFN(int count);

        IEnumerable<Person> Join(int count);
        IEnumerable<BusinessEntityAddress> JoinSet(int count);
        IEnumerable<BusinessEntity2> Join4(int count);
        IEnumerable<BusinessEntity2> Join5(int count);
        IEnumerable<PersonMap> Join6(int count);
        IEnumerable<Person> Put();
        IEnumerable<Person> Put2(int count);
        IEnumerable<Person> Greater();
        int Complete();

        
    }
}
