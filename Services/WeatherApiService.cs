namespace Weather_Forecast_App.Services
{
    using System.Net.Http.Headers;
    using System.Net.Http;
    using Weather_Forecast_App.Interfaces;
    using Weather_Forecast_App.Models.Weather;
    using Newtonsoft.Json;

    public class WeatherApiService : IWeatherApiService
    {
        private readonly IHttpClientFactory HttpClientFactory;

        public WeatherApiService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public Weather DecodeWeatherResponse(string response)
        {
            var weather = JsonConvert.DeserializeObject<Weather>(response);

            return weather;
        }

        public async Task<Weather> GetWeather()
        {

            var client = HttpClientFactory.CreateClient();

            client.DefaultRequestHeaders
                .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client
                .GetAsync(string
                .Format("http://api.weatherapi.com/v1/forecast.json?key=71de2c37ead844df82261931231404&q=London&days=3&aqi=no&alerts=no"))
                .Result;

            var responseString = await response.Content.ReadAsStringAsync();

            var weather = this.DecodeWeatherResponse(responseString);

            return weather;
        }
    }
}
