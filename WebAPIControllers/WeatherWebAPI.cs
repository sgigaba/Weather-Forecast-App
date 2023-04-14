namespace Weather_Forecast_App.WebAPIControllers
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;

    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Weather_Forecast_App.Interfaces;
    using Weather_Forecast_App.Models.Weather;

    public class WeatherWebAPI : Controller
    {
        private readonly IWeatherApiService weatherApiService;

        public WeatherWebAPI(IWeatherApiService weatherApiService)
        {
            this.weatherApiService = weatherApiService;
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            Weather weatherData = this.weatherApiService.GetWeather().Result;

            List<Weather> weatherList = new List<Weather>() { weatherData };

            return Json(DataSourceLoader.Load(weatherList, loadOptions));
        }
    }

}