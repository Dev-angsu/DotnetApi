using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public WeatherForecastController()
        {

        }

        [HttpGet]
        [Route("getHello")]
        public string hello()
        {
            return "Hello";
        }

        
    }
}
