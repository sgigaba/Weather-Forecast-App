namespace Weather_Forecast_App.ViewModels
{
    public class WeatherViewModel
    {

        public string Region { get; set; }

        public string Country { get; set; }

        public decimal Temparatue { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public decimal WindSpeed { get; set; } 

        public int Humidity { get; set; }

    }
}
