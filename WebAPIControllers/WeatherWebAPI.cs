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

        public IActionResult GetForeCastData(DataSourceLoadOptions loadOptions, string data)
        {
            Weather weatherData = this.weatherApiService.GetForecastWeather("England").Result;
            List<Day> days = new List<Day>();

            foreach (var weatherForcast in weatherData.Forecast.forecastday)
            {
                days.Add(weatherForcast.day);
            }

            return Json(DataSourceLoader.Load(days, loadOptions));
        }

        [HttpGet]
        public Weather test(string data)
        {
            Weather weatherData = this.weatherApiService.GetForecastWeather("England").Result;
            
            return weatherData;
        }

        public IActionResult GetCountryList(DataSourceLoadOptions loadOptions)
        {
            EnumCountries taiwan = new EnumCountries()
            {
                Id = 1,
                name = "Taiwan"
            };

            EnumCountries england = new EnumCountries()
            {
                Id = 2,
                name = "England"
            };

            List<EnumCountries> countries = new List<EnumCountries>();

            countries.Add(taiwan);
            countries.Add(england);

            return Json(DataSourceLoader.Load(countries, loadOptions));
        }
    }

}