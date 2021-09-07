using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using New.Test.Database;
using Test.Business.Interfaces;
using Test.Database.Model_Map;
using Test.Database.Models;
using Test.Database.Repositories;

namespace Test.Business.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AdventureWorks2019Context context) : base(context)
        {
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public IEnumerable<Person> OrderByLN(int count)
        {
            return _context.People.OrderByDescending(d => d.LastName).Take(count).ToList();
        }
        public IEnumerable<Person> Put()
        {
            return _context.People.ToList();
            
        }
        public IEnumerable<Person> Put2(int count)
        {
            return _context.People.Take(count).ToList();

        }
        public IEnumerable<Person> Greater()
        {
            return _context.People.Where(d => d.BusinessEntityId > 20777).ToList();

        }

        public IEnumerable<Person> OrderByFN(int count)
        {
            return _context.People.OrderBy(d => d.FirstName).Take(count).ToList();
        }
       
        public IEnumerable<Person> Join(int count)
        {

            return _context.People
        .Join(
            _context.EmailAddresses,
            ID => ID.BusinessEntityId,
            ID2 => ID2.BusinessEntityId,
            (ID, ID2) => new Person()
            {
                BusinessEntityId = ID.BusinessEntityId,
                FirstName = ID.FirstName,
                MiddleName = ID.MiddleName,
                Suffix = ID.Suffix,
                LastName = ID.LastName,
                Demographics = ID.Demographics

            }
        )
        .Join(
            _context.Passwords,
            ID => ID.BusinessEntityId,
            ID4 => ID4.BusinessEntityId,
            (ID, ID4) => new Person()
            {

                BusinessEntityId = ID.BusinessEntityId,
                FirstName = ID.FirstName,
                MiddleName = ID.MiddleName,
                Suffix = ID.Suffix,
                LastName = ID.LastName,
                Demographics = ID.Demographics
            }
        ).OrderBy(x => x.BusinessEntityId).Take(count)
        .ToList();

        }

        public IEnumerable<BusinessEntityAddress> JoinSet(int count)
        {

            return _context.BusinessEntityAddresses
        .Join(
            _context.Addresses,
            ID => ID.BusinessEntityId,
            ID2 => ID2.StateProvinceId,
            (ID, ID2) => new BusinessEntityAddress()
            {
                BusinessEntityId = ID.BusinessEntityId,
                AddressId = ID.AddressId
                
            }
        )
        .Join(
            _context.Passwords,
            ID => ID.BusinessEntityId,
            ID4 => ID4.BusinessEntityId,
            (ID, ID4) => new BusinessEntityAddress()
            {

                BusinessEntityId = ID.BusinessEntityId,
                Address = ID.Address
                

                
                
            }
        ).OrderByDescending(x => x.BusinessEntityId).Take(count)
        .ToList();

        }
        public IEnumerable<BusinessEntity2> Join4(int count)
        {
            return _context.BusinessEntityAddresses.Join(_context.Addresses,
                bea => bea.BusinessEntityId,
                adr => adr.AddressId,
                (bea, adr) => new BusinessEntity2()
                {
                    AddressId = bea.AddressId,
                    AddressTypeId = bea.AddressTypeId,
                    BusinessEntityId = bea.BusinessEntityId
                }



                ).Where(x => x.BusinessEntityId > 32).Take(count).ToList();
        }
        public IEnumerable<BusinessEntity2> Join5(int count)
        {
            return _context.BusinessEntities.Join(_context.AddressTypes,
                adr => adr.BusinessEntityId,
                at => at.AddressTypeId,
                (adr, at) => new BusinessEntity2()
                {
                    BusinessEntityId = adr.BusinessEntityId,
                    AddressTypeId = at.AddressTypeId
                    
                }
                ).Join(_context.Addresses,
                ad => ad.BusinessEntityId,
                at => at.AddressId,
                (ad, at) => new BusinessEntity2()
                {
                    BusinessEntityId = ad.BusinessEntityId,
                    AddressId = at.AddressId

                }
                ).OrderBy(x => x.AddressId).Take(count).ToList();
        }

        public IEnumerable<PersonMap> Join6(int count)
        {
            PersonMap deneme = new PersonMap();
            
            return _context.People.Join(_context.PersonPhones,
                ppl => ppl.BusinessEntityId,
                pp => pp.PhoneNumberTypeId,
                (ppl, pp) => new PersonMap()
                {
                    BusinessEntityId = ppl.BusinessEntityId,
                    FirstName = ppl.FirstName,
                    LastName = ppl.LastName,
                    PersonType = ppl.PersonType
                }
                ).Join(_context.PhoneNumberTypes,
                ppl2 => ppl2.BusinessEntityId,
                pnt => pnt.PhoneNumberTypeId,
                (ppl2, pnt) => new PersonMap()
                {
                    BusinessEntityId = ppl2.BusinessEntityId,
                    FirstName = ppl2.FirstName,
                    LastName = ppl2.LastName,
                    PersonType = ppl2.PersonType
                }
                ).OrderByDescending(y => y.LastName).Take(count).ToList();
        }
        public int DeleteBook(int id)
        {
            int res = 0;
            var book = _context.Addresses.FirstOrDefault(b => b.AddressId == id);
            if (book != null)
            {
                _context.Addresses.Remove(book);
                res = _context.SaveChanges();
            }
            return res;
        }
    }
    }


