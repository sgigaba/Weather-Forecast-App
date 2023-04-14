namespace Weather_Forecast_App.Models.Weather
{
    public class Current
    {
        public decimal temp_c { get; set; }

        public decimal wind_mph { get; set; }

        public int humidity { get; set; }

        public int is_day { get; set; }

        public string feelslike_c { get; set; }
    }
}
