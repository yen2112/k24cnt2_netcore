using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NguyenVanYen2410900091_exam.Models;

namespace NguyenVanYen2410900091_exam.Controllers
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

        public IActionResult HvtAbout()
        {
            return View();
        }

        public IActionResult NvyAbout()
        {
            return View("HvtAbout");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
