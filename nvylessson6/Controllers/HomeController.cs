using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nvylessson6.Models;

namespace nvylessson6.Controllers
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

        /*
         * Tạo action trả về danh sách các sản phẩm HOT
         * Hiển thị trên partial view _ProductHotPartialView
         */
        public PartialViewResult GetProductHot()
        {
            List<Product> productHot = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop Dell XPS 15", Price = 35000000, Image = "icon1.png" },
                new Product { Id = 2, Name = "iPhone 15 Pro Max", Price = 30000000, Image = "icon2.png" },
                new Product { Id = 3, Name = "Samsung Galaxy S24 Ultra", Price = 28000000, Image = "icon3.png" },
                new Product { Id = 4, Name = "MacBook Pro M3", Price = 42000000, Image = "icon4.png" }
            };
            return PartialView("_ProductHotPartialView", productHot);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
