namespace Weather_Forecast_App.WebAPIControllers
{
    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;

    using Microsoft.AspNetCore.Mvc;

    using Weather_Forecast_App.Interfaces;
    using Weather_Forecast_App.Models.Weather;
    using Weather_Forecast_App.ViewModels;

    public class WeatherWebAPI : Controller
    {
        private readonly IWeatherApiService weatherApiService;

        public WeatherWebAPI(IWeatherApiService weatherApiService)
        {
            this.weatherApiService = weatherApiService;
        }

        [HttpGet]

        public IActionResult GetForeCastData(DataSourceLoadOptions loadOptions, string data)
        {
            Weather weatherData = this.weatherApiService.GetForecastWeather(data).Result;
            var weatherViewModel = new WeatherViewModel()
            {
                Region = weatherData.Location.region,
                Country = weatherData.Location.country,
                Latitude = weatherData.Location.lat,
                Temparatue = weatherData.Current.temp_c,
            };
            List<WeatherViewModel> weatherList = new List<WeatherViewModel>();

            weatherList.Add(weatherViewModel);

            return Json(DataSourceLoader.Load(weatherList, loadOptions));
        }

        public IActionResult GetDailyData(DataSourceLoadOptions loadOptions, string data)
        {
            if (data == null)
            {
                data = "England";
            }
            Weather weatherData = this.weatherApiService.GetForecastWeather(data).Result;

            List<Day> days = new List<Day>();

            foreach (var dailyData in weatherData.Forecast.forecastday)
            {
                days.Add(dailyData.day);

            }

            return Json(DataSourceLoader.Load(days, loadOptions));
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

            EnumCountries albania = new EnumCountries()
            {
                Id = 3,
                name = "Albania"
            };

            EnumCountries Zimbabwe = new EnumCountries()
            {
                Id = 4,
                name = "Zimbabwe"
            };

            EnumCountries Nigeria = new EnumCountries()
            {
                Id = 4,
                name = "Nigeria"
            };


            List<EnumCountries> countries = new List<EnumCountries>();

            countries.Add(taiwan);
            countries.Add(england);
            countries.Add(albania);
            countries.Add(Zimbabwe);
            countries.Add(Nigeria);

            return Json(DataSourceLoader.Load(countries, loadOptions));
        }
    }

}