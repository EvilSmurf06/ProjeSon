using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test.Business.Interfaces;
using Test.Database.Models;

namespace Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : Controller
    {
        private readonly IEntityRepository _entity;
        private readonly IUnitOfWork _work;
        private readonly IPersonRepository _person;
        private readonly IMapper _mapper;
        public EntityController(IEntityRepository entity , IUnitOfWork work, IPersonRepository person, IMapper mapper)
        {
            _entity = entity;
            _work = work;
            _person = person;
            _mapper = mapper;
        }
        [Route("ent")]
        public IActionResult GetAddress([FromQuery] int count)
        {
            var getaddress = _entity.GetById(count);
            return Ok(getaddress);
        }
        [Route("ent2")]
        public IActionResult GetAddress2([FromQuery] int count)
        {
            var getaddress = _person.OrderByFN(count);
            return Ok(getaddress);
        }

    }
}
