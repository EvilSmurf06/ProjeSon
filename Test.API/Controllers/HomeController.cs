using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test.Business.Interfaces;
using Test.Database.Model_Map;
using Test.Database.Models;

namespace Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : MainController
    {
        private readonly IPersonRepository _personRepository;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));
        public HomeController(IPersonRepository personRepository, IMapper mapper):base(mapper)
        {
            _personRepository = personRepository;
        }
        [Route("people")]
        public IActionResult GetPeople([FromQuery] int count)
        {
            var getpeople = _personRepository.OrderByLN(count);
            return Ok(getpeople);
        }
        [Route("people2")]
        public IActionResult GetPeople2([FromQuery] int count)
        {
            var getpeople2 = _personRepository.OrderByFN(count);
            return Ok(getpeople2);
        }
        [Route("people3")]
        public IActionResult GetPeople3([FromQuery] int count)
        {
            var getpeople3 = _personRepository.GetById(count);
            return Ok(getpeople3);
        }
        [Route("people4")]
        [HttpGet]
        public ActionResult<PersonMap> Get()
        {
            var person = _personRepository.GetById(20776);
            var persondetails = _mapper.Map<PersonMap>(person);
            return Ok(persondetails);
        }
        [Route("people5")]
        [HttpGet]
        public IActionResult Get2(int count)
        {
            var person2 = _personRepository.GetById(count);
            var persondetails2 = _mapper.Map<PersonMap>(person2);
            return Ok(persondetails2);
        }
        [Route("join")]
        public IActionResult GetJoin([FromQuery] int count)
        {
            var join = _personRepository.Join(count);
            return Ok(join);
        }

        [Route("join2")]
        public IActionResult GetJoin2([FromQuery] int count)
        {
            var join2 = _personRepository.JoinSet(count);
            return Ok(join2);
        }
        [Route("join3")]
        public IActionResult GetJoin3([FromQuery] int count)
        {
            var join3 = _personRepository.Join4(count);
            return Ok(join3);
        }
        [Route("join4")]
        public IActionResult GetJoin4([FromQuery] int count)
        {
            var join4 = _personRepository.Join5(count);
            return Ok(join4);
        }
        [Route("join5")]
        public IActionResult GetJoin5([FromQuery] int count)
        {
            var join5 = _personRepository.Join6(count);
            return Ok(join5);
        }


        [HttpPost]
        [Route("post")]
        public IActionResult Post([FromBody] Person person)
        {

            person.Rowguid = Guid.NewGuid();
            person.ModifiedDate = DateTime.Now;
            _personRepository.Add(person);
            _personRepository.Complete();
            return Ok(person);
        }
        [HttpPost]
        [Route("post2")]
        public IActionResult Post2([FromBody] Person person)
        {
            var putEx = _personRepository.Put();
            var id = putEx.Select(x => x.BusinessEntityId);
            try
            {
                person.Rowguid = Guid.NewGuid();
                person.ModifiedDate = DateTime.Now;
                _personRepository.Add(person);
                _personRepository.Complete();
                return Ok(person);
            }
            catch (Exception ex)
            {

                if (id.Contains(person.BusinessEntityId))
                {
                    return StatusCode(500, "There is already someone with this id");
                }

                return StatusCode(404, "Page not found");
            }

        }
        [HttpPost]
        [Route("post3")]
        public IActionResult Post3([FromBody] Person person)
        {
            if (person == null)
            {
                return NotFound("Person not found");
            }
            person.Rowguid = Guid.NewGuid();
            person.ModifiedDate = DateTime.Now;
            _personRepository.Add(person);
            _personRepository.Complete();
            return Ok(person);


        }

        [HttpPost]
        [Route("post4")]
        public IActionResult postEx(string value)
        {
            var newPerson = new Person
            {
                BusinessEntityId = 20790,
                PersonType = "EM",
                NameStyle = true,
                Title = "Mr.",
                FirstName = "Fatih",
                LastName = "Emecen",
                MiddleName = "M.",
                Rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };
            return Ok(newPerson);
        }
        [HttpPost]
        [Route("post5")]


        public void Post4([FromBody] Person person)
        {
            var data = _personRepository.Put();
            var id = data.Where(d => d.BusinessEntityId == person.BusinessEntityId).FirstOrDefault<Person>();
            var data2 = _mapper.Map<PersonMap>(person);


            id.FirstName = data2.FirstName;
            id.LastName = data2.LastName;
            person.Rowguid = Guid.NewGuid();
            person.ModifiedDate = DateTime.Now;
            _personRepository.Complete();

        }

        // Create
        [HttpPost]
        [Route("post6")]
        public async Task<IActionResult> Create([FromBody] Person person)
        {
            var per = new Person
            {
                BusinessEntityId = person.BusinessEntityId,
                NameStyle = person.NameStyle,
                PersonType = person.PersonType,
                FirstName = person.FirstName,
                LastName = person.LastName,
                EmailPromotion = person.EmailPromotion,
                Rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now

            };
            _personRepository.Add(per);
            _personRepository.Complete();
            var customerResponse = _mapper.Map<Person>(per);
            return Ok();
        }
        [HttpDelete]
        [Route("delete")]
        public IActionResult DeletePerson(Person person)
        {

            _personRepository.Remove(person);
            _personRepository.Complete();
            return Ok();
        }
        [HttpDelete]
        [Route("delete2")]
        public ActionResult DeleteMapper(int id)
        {
            var person = _personRepository.GetById(id);
            //var userDetails = _personRepo.FirstOrDefault(userId => userId.UserId == id);
            var user = _mapper.Map<Person, PersonMap>(person);
            _personRepository.Remove(person);
            _personRepository.Complete();
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdatePerson([FromBody] Person person)
        {

            var putEx = _personRepository.Put();
            var id = putEx.Where(d => d.BusinessEntityId == person.BusinessEntityId).FirstOrDefault<Person>();
            if (id != null)
            {
                id.BusinessEntityId = person.BusinessEntityId;
                id.PersonType = person.PersonType;
                id.NameStyle = person.NameStyle;
                id.FirstName = person.FirstName;
                id.MiddleName = person.MiddleName;
                id.LastName = person.LastName;
                id.EmailPromotion = person.EmailPromotion;
                id.Rowguid = Guid.NewGuid();
                id.ModifiedDate = DateTime.Now;
                _personRepository.Complete();
            }
            else
            {
                return NotFound();
            }
            return Ok(person);


        }
        [HttpPut]
        [Route("update2")]
        
        public IActionResult UpdatePerson2(int id2, [FromBody] Person person)
        {

            var putEx = _personRepository.GetById(id2);
            
            if (putEx != null)
            {
                putEx.BusinessEntityId = id2;
                putEx.PersonType = person.PersonType;
                putEx.NameStyle = person.NameStyle;
                putEx.FirstName = person.FirstName;
                putEx.MiddleName = person.MiddleName;
                putEx.LastName = person.LastName;
                putEx.EmailPromotion = person.EmailPromotion;
                putEx.Rowguid = Guid.NewGuid();
                putEx.ModifiedDate = DateTime.Now;
                _personRepository.Complete();



            }
            else
            {
                return NotFound();
            }
            return Ok();


        }
        [Route("deneme2")]
        public ActionResult Index2()
        {
            try
            {
                int x, y, z;
                x = 5; y = 1;
                z = x / y;
                logger.Debug(z);
                logger.Info("Sorunsuz çalışıyor");
                logger.Warn("Uyarı.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
            return Ok();
        }
        // UI

        [HttpGet]
        [Route("in")]
        public IActionResult Index()
        {
            var people = _personRepository.Greater();
            return View(people);
        }
        [HttpPost]
        [Route("create")]
        public IActionResult New([FromForm] Person person)
        {
            var per = new Person
            {
                BusinessEntityId = person.BusinessEntityId,
                NameStyle = person.NameStyle,
                PersonType = person.PersonType,
                Title = person.Title,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                LastName = person.LastName,
                Suffix = person.Suffix,
                EmailPromotion = person.EmailPromotion,
                Rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now

            };
            _personRepository.Add(per);
            _personRepository.Complete();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [Route("update2")]


        public IActionResult Update(int id2)
        {

            //var data2 = _mapper.Map<PersonMap>(data);

            //id.NameStyle = data2.NameStyle;
            //id.PersonType = data2.PersonType;
            //id.Title = data2.Title;
            //data.FirstName = data2.FirstName;
            //data.MiddleName = data2.MiddleName;
            //data.LastName = data2.LastName;
            //id.EmailPromotion = data2.EmailPromotion;
            //data.Rowguid = Guid.NewGuid();
            //data.ModifiedDate = DateTime.Now;
            //_personRepo.Complete();
            var data = _personRepository.GetById(id2);
            ViewData["person"] = data;
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [Route("update")]


        public IActionResult Update([FromForm] Person person)
        {
            var data = _personRepository.GetAll();
            var id = data.Where(d => d.BusinessEntityId == person.BusinessEntityId).FirstOrDefault<Person>();
            var data2 = _mapper.Map<Person>(person);

            id.NameStyle = data2.NameStyle;
            id.PersonType = data2.PersonType;
            id.Title = data2.Title;
            id.FirstName = data2.FirstName;
            id.MiddleName = data2.MiddleName;
            id.LastName = data2.LastName;
            id.EmailPromotion = data2.EmailPromotion;
            person.Rowguid = Guid.NewGuid();
            person.ModifiedDate = DateTime.Now;
            _personRepository.Complete();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [Route("in5")]
        public IActionResult DeleteData(int count)
        {
            var people2 = _personRepository.GetById(count);
            _personRepository.Remove(people2);
            _personRepository.Complete();
            return RedirectToAction("Index", "Home");
        }
    }
}

