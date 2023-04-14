namespace Weather_Forecast_App.Interfaces
{
    using Weather_Forecast_App.Models.Weather;

    public interface IWeatherApiService
    {
        Weather GetWeather();

        Task<Weather> DecodeWeatherResponse(string response);
    }
}
