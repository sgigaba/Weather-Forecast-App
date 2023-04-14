namespace Weather_Forecast_App.Models.Weather
{
    public class Weather
    {
        public CurrentWeather Current { get; set; }

        public Location Location { get; set; }

        public Forecast Forecast { get; set; }
    }
}
