using Microsoft.AspNetCore.Mvc;
using nvylesson03.Models;

namespace nvylesson03.Controllers
{
    [Route("/danh-sach-san-pham")]
    public class nvyproductController : Controller
    {
        // Mock data
        private readonly List<nvyproduct> _products = new()
        {
                    new nvyproduct
            {
                nvyProducdID = "SP001",
                nvyProductName = "iPhone 15 Pro Max",
                nvyYearRelease = 2023,
                nvyPrice = 29990000
            },
            new nvyproduct
            {
                nvyProducdID = "SP002",
                nvyProductName = "iPhone 14 Pro",
                nvyYearRelease = 2022,
                nvyPrice = 24990000
            },
            new nvyproduct
            {
                nvyProducdID = "SP003",
                nvyProductName = "Samsung Galaxy S24 Ultra",
                nvyYearRelease = 2024,
                nvyPrice = 33990000
            },
            new nvyproduct
            {
                nvyProducdID = "SP004",
                nvyProductName = "Samsung Galaxy S23",
                nvyYearRelease = 2023,
                nvyPrice = 18990000
            },
            new nvyproduct
            {
                nvyProducdID = "SP005",
                nvyProductName = "Google Pixel 8 Pro",
                nvyYearRelease = 2023,
                nvyPrice = 25990000
            },
            new nvyproduct
            {
                nvyProducdID = "SP006",
                nvyProductName = "Xiaomi 14",
                nvyYearRelease = 2024,
                nvyPrice = 21990000
            },
            new nvyproduct
            {
                nvyProducdID = "SP007",
                nvyProductName = "OPPO Find X7 Ultra",
                nvyYearRelease = 2024,
                nvyPrice = 23990000
            },
            new nvyproduct
            {
                nvyProducdID = "SP008",
                nvyProductName = "OnePlus 12",
                nvyYearRelease = 2024,
                nvyPrice = 19990000
            },
            new nvyproduct
            {
                nvyProducdID = "SP009",
                nvyProductName = "Vivo X100 Pro",
                nvyYearRelease = 2024,
                nvyPrice = 22990000
            },
            new nvyproduct
            {
                nvyProducdID = "SP010",
                nvyProductName = "Samsung Galaxy Z Fold 6",
                nvyYearRelease = 2024,
                nvyPrice = 41990000
            }
        };
        public IActionResult Index()
        {
            return Json(_products);
        }

        //Collection => view
        [Route("all")]
        public IActionResult nvyGetAllProduct()
        {
            ViewData["products"] = _products;
            return View(_products);
        }
    }
}
