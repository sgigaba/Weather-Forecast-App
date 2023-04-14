namespace Weather_Forecast_App.WebAPIControllers
{
    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;

    using Microsoft.AspNetCore.Mvc;

    using Weather_Forecast_App.Models;
    using Weather_Forecast_App.Models.Weather;

    public class WeatherWebAPI : Controller
    {
        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            Weather weatherData = new Weather()
            {
                TemparatureInCelcius = 20,
                WindSpeed = 35,
                Humidity = 27,
                IsDayOrNight = 1,
                Condition = "Beautiful and Sunny"
            };

            List<Weather> weatherList = new List<Weather>() { weatherData };

            return Json(DataSourceLoader.Load(weatherList, loadOptions));
        }
    }
}
