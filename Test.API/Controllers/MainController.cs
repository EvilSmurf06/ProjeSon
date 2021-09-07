using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using log4net.Core;
using Microsoft.AspNetCore.Mvc;

namespace Test.API.Controllers
{
    public class MainController : Controller
    {
        protected readonly IMapper _mapper;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MainController));
        public MainController(IMapper mapper)
        {
            _mapper = mapper;
        }

    }
}
