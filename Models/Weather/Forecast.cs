using System.Text.Json.Nodes;

namespace Weather_Forecast_App.Models.Weather
{
    public class Forecast
    {
        public List<ForeCastDay> forecastday { get; set; }
    }

    public class ForeCastDay
    {
        public string date { get; set; }

        public Day day { get; set; }
    }

    public class Day
    {
       public decimal maxtemp_c { get; set; }

       public decimal mintemp_c { get; set; }

       public decimal avgtemp_c { get; set; }
    }
}
