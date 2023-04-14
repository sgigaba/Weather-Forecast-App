namespace Weather_Forecast_App.Models.Weather
{
    public class Weather
    {
        public decimal TemparatureInCelcius { get; set; }

        public decimal WindSpeed { get; set; }

        public int Humidity { get; set; }

        public int IsDayOrNight { get; set; }

        public string Condition { get; set; }
    }
}
