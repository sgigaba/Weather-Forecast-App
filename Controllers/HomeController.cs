using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Weather_Forecast_App.Models;
using Weather_Forecast_App.Models.Weather;

namespace Weather_Forecast_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetCountryList(DataSourceLoadOptions loadOptions)
        {
            EnumCountries taiwan = new EnumCountries()
            {
                Id = 1,
                name = "Taiwan"
            };

            EnumCountries england = new EnumCountries()
            {
                Id = 2,
                name = "England"
            };

            List<EnumCountries> countries = new List<EnumCountries>();

            countries.Add(taiwan);
            countries.Add(england);

            return Json(DataSourceLoader.Load(countries, loadOptions));
        }
    }
}