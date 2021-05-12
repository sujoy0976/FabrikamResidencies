using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FabrikamResidences_Activities.Models;
using Microsoft.Extensions.Logging;

namespace FabrikamResidences_Activities.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger; 

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {            
            _logger.LogInformation("Home Page Viewed");
            return View();
        }

        public IActionResult About()
        {
            _logger.LogInformation("About Page Viewed");
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            _logger.LogInformation("Contact Page Viewed");
            ViewData["Message"] = "Your contact page.";

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
    }
}
