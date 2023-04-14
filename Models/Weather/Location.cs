namespace Weather_Forecast_App.Models.Weather
{
    public class Location
    {
        public string name { get; set; }

        public string region { get; set; }

        public string country { get; set; }

        public decimal lat { get; set; }

        public decimal lon { get; set; }
        
        public string tz_id { get; set; }

        public int localtime_epoch { get; set; }

        public string localtime { get ; set; }
    }
}
