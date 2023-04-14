namespace Weather_Forecast_App.Models.Weather
{
    public class EnumCountries
    {
        public int Id { get; set; }
        public string name { get; set; }
    }

    public partial class SampleData
    {

        public static readonly IEnumerable<EnumCountries> EnumCountries = new[] {
            new EnumCountries
            {
                Id = 1,
                name = "England"
            },
            new EnumCountries
            {
                Id = 2,

                name = "Taiwan"
            }
        };
    }
}