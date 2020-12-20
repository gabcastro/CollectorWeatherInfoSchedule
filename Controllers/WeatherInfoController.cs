using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace WeatherCollector.Controller
{
    [ApiController]
    [Route("api/v1/weatherinfo")]
    [Produces(MediaTypeNames.Application.Json)]
    public class WeatherInfoController : ControllerBase
    {
        public WeatherInfoController() 
        {
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok("Yeap, working");
        }
    }

}