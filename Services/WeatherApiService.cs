namespace Weather_Forecast_App.Services
{
    using System.Net.Http.Headers;
    using System.Net.Http;

    using Newtonsoft.Json;

    using Weather_Forecast_App.Interfaces;
    using Weather_Forecast_App.Models.Weather;

    public class WeatherApiService : IWeatherApiService
    {
        private readonly IHttpClientFactory HttpClientFactory;
        private readonly ICacheService cacheService;

        public WeatherApiService(IHttpClientFactory httpClientFactory, ICacheService cacheService)
        {
            HttpClientFactory = httpClientFactory;
            this.cacheService = cacheService;
        }

        public Weather DecodeWeatherResponse(string response)
        {
            var weather = JsonConvert.DeserializeObject<Weather>(response);

            return weather;
        }

        public async Task<Weather> GetForecastWeather(string country)
        {
            Weather weather = (Weather)this.cacheService.FetchFromCache(country);

            if (weather == null)
            {
                var client = HttpClientFactory.CreateClient();

                client.DefaultRequestHeaders
                    .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client
                    .GetAsync(string
                    .Format("http://api.weatherapi.com/v1/forecast.json?key=71de2c37ead844df82261931231404&q=" + country + "&days=3&aqi=no&alerts=no"))
                    .Result;

                var responseString = await response.Content.ReadAsStringAsync();
                weather = this.DecodeWeatherResponse(responseString);
                cacheService.AddToCache(country, weather);
            }
   
            return weather;
        }
    }
}
