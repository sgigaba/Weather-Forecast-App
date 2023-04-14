namespace Weather_Forecast_App.ViewModels
{
    public class WeatherViewModel
    {
        public string name { get; set; }

        public string region { get; set; }

        public string country { get; set; }

        public decimal lat { get; set; }

        public decimal lon { get; set; }

        public string tz_id { get; set; }

        public int localtime_epoch { get; set; }

        public string localtime { get; set; }

        public decimal temp_c { get; set; }

        public decimal wind_mph { get; set; }

        public int humidity { get; set; }

        public int is_day { get; set; }

        public string feelslike_c { get; set; }
    }
}
