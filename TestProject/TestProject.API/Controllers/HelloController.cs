using Microsoft.AspNetCore.Mvc;

namespace TestProject.API.Controllers {
    
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase {
        private readonly ILogger<WeatherForecastController> _logger;

        public HelloController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<string> GetAsync()
        {
            return "Hello";
        }
    }
}