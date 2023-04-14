namespace Weather_Forecast_App.Interfaces
{
    using Weather_Forecast_App.Models.Weather;

    public interface IWeatherApiService
    {
        Weather DecodeWeatherResponse(string response);

        Task<Weather> GetForecastWeather(string country);

    }
}
