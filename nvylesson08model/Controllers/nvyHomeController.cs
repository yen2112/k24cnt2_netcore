using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nvylesson08model.Models;

namespace nvylesson08model.Controllers
{
    public class nvyHomeController : Controller
    {
        private readonly ILogger<nvyHomeController> _logger;

        public nvyHomeController(ILogger<nvyHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult nvyIndex()
        {
            return View();
        }

        public IActionResult nvyPrivacy()
        {
            return View();
        }

        public IActionResult nvyAbout()
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
