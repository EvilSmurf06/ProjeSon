using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Database.Model_Map
{
    public class PersonMap
    {
        public int BusinessEntityId { get; set; }
        public string FirstName { get; set; }
        public string PersonType { get; set; }
        public string LastName { get; set; }
        protected string MyProtected { get; set; }

        private string MyPrivate { get; set; }

        internal string MyInternal { get; set; }
    }
}
