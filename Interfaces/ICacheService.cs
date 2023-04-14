namespace Weather_Forecast_App.Interfaces
{
    using Weather_Forecast_App.Models.Weather;

    public interface ICacheService
    {
        void AddToCache(string key, Weather value);

        object FetchFromCache(string key);
    }
}
