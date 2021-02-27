using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using PrimeNumbers.Server.Services;
using Microsoft.Extensions.Logging;

namespace PrimeNumbers.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimesController : ControllerBase
    {
        private readonly IPrimesService _primesService;
        private readonly ILogger<PrimesController> _logger;

        public PrimesController(
            IPrimesService primesService,
            ILogger<PrimesController> logger)
        {
            _primesService = primesService;
            _logger = logger;
        }


        [HttpGet("{number:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetIsPrime(
            [FromRoute] int number)
        {
            _logger.LogInformation($"prime number for {number} was requested");

            bool isPrime = await _primesService.IsPrimeNumber(number);

            _logger.LogInformation($"is prime number {number}: {isPrime}");

            if (isPrime) return Ok();
            else return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IEnumerable<int>>> GetPrimeNumbers(
            [FromQuery(Name = "from")] string from,
            [FromQuery(Name = "to")] string to)
        {
            _logger.LogInformation("primes from range was requested");

            try
            {
                var min = int.Parse(from);
                var max = int.Parse(to);

                _logger.LogInformation($"sets range {from}:{to}");

                var result = await _primesService.FromRange(min, max);

                _logger.LogInformation($"result: {result}");
                return Ok(result);
            }
            catch (Exception)
            {
                _logger.LogInformation($"Not valid query string");

                return BadRequest("");
            }
        }
    }
}
