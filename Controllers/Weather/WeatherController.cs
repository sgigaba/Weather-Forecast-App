using Microsoft.AspNetCore.Mvc;

namespace Weather_Forecast_App.Controllers.Weather
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
