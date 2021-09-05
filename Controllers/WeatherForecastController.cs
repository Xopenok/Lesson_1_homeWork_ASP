using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lesson_1_homeWork_ASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly List<WeatherForecast> _weatherForecasts;


        public WeatherForecastController(List<WeatherForecast> weatherForecasts)
        {
            _weatherForecasts = weatherForecasts;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_weatherForecasts.OrderBy(el => el.Date));
        }
        [HttpPost]
        public IActionResult Post([FromBody] WeatherForecast weatherForecast)
        {
            if (_weatherForecasts.TrueForAll(el => el.Date != weatherForecast.Date))
                _weatherForecasts.Add(weatherForecast);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] WeatherForecast weatherForecast)
        {
            _weatherForecasts.Remove(weatherForecast);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put([FromBody] WeatherForecast replace)
        {
            _weatherForecasts.FirstOrDefault(el => el.Date == replace.Date)?.CopyData(replace);
            return Ok();
        }
    }
}
