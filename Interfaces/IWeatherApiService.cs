namespace Weather_Forecast_App.Interfaces
{
    using Weather_Forecast_App.Models.Weather;

    public interface IWeatherApiService
    {
        Task<Weather> GetWeather();

        Weather DecodeWeatherResponse(string response);
    }
}
