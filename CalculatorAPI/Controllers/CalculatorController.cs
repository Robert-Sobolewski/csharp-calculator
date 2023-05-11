using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CalculatorController> _logger;
        public CalculatorController(IConfiguration configuration, ILogger<CalculatorController> logger)
        {
            this._configuration = configuration;
            this._logger = logger;
        }

        [HttpGet("add/{a}/{b}")]
        public IActionResult Add(double a, double b)
        {
            return Ok(a + b);
        }

        [HttpGet("substract/{a}/{b}")]
        public IActionResult Substract(double a, double b)
        {
            return Ok(a - b);
        }
        [HttpGet("multiply/{a}/{b}")]
        public IActionResult Multiply(double a, double b)
        {
            return Ok(a * b);
        }

        [HttpGet("divide/{a}/{b}")]
        public IActionResult Divide(double a, double b)
        {
            return Ok( b==0.0? double.PositiveInfinity: a / b);
        }
    }
}
