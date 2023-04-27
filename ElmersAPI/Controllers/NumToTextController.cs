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
    public class NumToTextController : ControllerBase
    {
        private readonly ILogger<NumToTextController> _logger;
        private readonly INumToTextConverter _converter;
        public NumToTextController(ILogger<NumToTextController> logger, INumToTextConverter converter)
        {
            _logger = logger;
            _converter = converter;
        }

        [Route("convert")]
        [HttpPost]
        public async Task<IActionResult> Convert(string numToConvert)
        {
            try
            {
                var result = _converter.ConvertNumberToWords(numToConvert);
                if (result == String.Empty)
                    return BadRequest("Only 32-bit integer is supported for the conversion request.");
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
