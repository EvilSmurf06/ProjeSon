using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Business.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository People { get; }
        IAddressRepository Address { get; }
        IEntityRepository Entity { get; }
        int Complete();
    }
}
