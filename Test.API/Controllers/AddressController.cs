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
    public class AddressController : MainController
    {
        private readonly IAddressRepository _addressrepository;
       
        public AddressController(IAddressRepository addressrepository, IMapper mapper):base(mapper)
        {
            _addressrepository = addressrepository;
        }
        [Route("adr")]
        public IActionResult GetAddress([FromQuery] int count)
        {
            var getaddress = _addressrepository.GetById(count);
            return Ok(getaddress);
        }
        [Route("adr2")]
        public IActionResult GetAddress2([FromQuery] int count)
        {
            var getaddress = _addressrepository.OrderByAdrId(count);
            return Ok(getaddress);
        }
        [Route("adr3")]
        public IActionResult GetAddress3([FromQuery] int count)
        {
            var getaddress = _addressrepository.OrderByAdrId2(count);
            return Ok(getaddress);
        }
        //[Route("join")]
        //public void Join(IEnumerable<Address> addresses)
        //{
        //    var getaddress = _addressrepository.AddRange(addresses);
        //    return Ok(getaddress);
        //}
    }
}
