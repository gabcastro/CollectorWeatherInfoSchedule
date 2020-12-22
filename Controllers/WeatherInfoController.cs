using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherCollector.Repositories;
using WeatherCollector.ViewModels.WeatherInfoViewModels;

namespace WeatherCollector.Controller
{
    [ApiController]
    [Route("api/v1/weatherinfo")]
    [Produces(MediaTypeNames.Application.Json)]
    public class WeatherInfoController : ControllerBase
    {
        private readonly WeatherInfoRepository _weatherInfoRepository;

        public WeatherInfoController(WeatherInfoRepository weatherInfoRepository) 
        {
            _weatherInfoRepository = weatherInfoRepository;
        }

        /// <summary>
        /// Get informations of temperature to some city
        /// Conditions: 
        ///     - Parameters must especify
        /// </summary>
        /// <param name="city"></param>
        /// <param name="start_date"></param>
        /// <param name="end_date"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ListWeatherInfoViewModel> Get(string city, string start_date, string end_date)
        {
            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(start_date) || string.IsNullOrEmpty(end_date))
                return BadRequest("Todos os campos devem ser preechidos");

            var wInfo = _weatherInfoRepository.GetInfoCity(city, start_date, end_date);

            return Ok(wInfo);
        }
    }

}