using ElmersAPIService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ElmersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ILogger<CoffeeController> _logger;
        private readonly ICoffee _coffee;
        public CoffeeController(ILogger<CoffeeController> logger, ICoffee coffee)
        {
            _logger = logger;
            _coffee = coffee;
        }

        [Route("process")]
        [HttpPost]
        public async Task<IActionResult> Process(string hexString)
        {
            try
            {
                var result = _coffee.ProcessCoffee(hexString);
                if (result == null)
                    return BadRequest("Only hexadecimal string equivalent to 2-byte integer is supported for the process request.");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
