using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeNumbers.Server.Controllers
{
    [ApiController]
    [Route("/")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Web service 'Prime numbers' by Andrey Basystyi");
        }
    }
}
