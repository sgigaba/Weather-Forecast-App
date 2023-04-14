namespace Weather_Forecast_App.WebAPIControllers
{
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;

    using Microsoft.AspNetCore.Mvc;
    using Weather_Forecast_App.Models.Weather;

    public class WeatherWebAPI : Controller
    {

        private readonly IHttpClientFactory HttpClientFactory;

        public WeatherWebAPI(IHttpClientFactory HttpClientFactory)
        {
            this.HttpClientFactory = HttpClientFactory;
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            this.WeatherAPI();

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

        public async Task WeatherAPI()
        {
            var json = new 
            {
                url = "http://api.weatherapi.com/v1/current.json?key=71de2c37ead844df82261931231404&q=England&aqi=no" 
            };

            string jsonString = JsonSerializer.Serialize(json);

            var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var client = HttpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "71de2c37ead844df82261931231404");

            HttpResponseMessage response = await 
                client.PostAsync("http://api.weatherapi.com/v1/current.json?key=71de2c37ead844df82261931231404&q=England&aqi=no", payload);

            string responseJson = await response.Content.ReadAsStringAsync();
        }
    }
}
