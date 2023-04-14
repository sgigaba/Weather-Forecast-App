namespace Weather_Forecast_App.Services
{
    using Microsoft.Extensions.Caching.Memory;
    using Weather_Forecast_App.Interfaces;
    using Weather_Forecast_App.Models.Weather;

    public class CacheService : ICacheService
    {
        private readonly IMemoryCache cache;

        public CacheService(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public void AddToCache(string key, Weather value)
        {
            this.cache.Set(key, value);
        }

        public object FetchFromCache(string key)
        {
            var cachedData = this.cache.Get(key);
            return cachedData;
        }
    }
}
