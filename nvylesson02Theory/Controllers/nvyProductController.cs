using Microsoft.AspNetCore.Mvc;
using nvylesson02Theory.Models;

namespace nvylesson02Theory.Controllers
{
    public class nvyProductController : Controller
    {
        public IActionResult NvyIndex()
        {
            ViewBag.name = "Nguyen Van Yen";
            ViewData["product"] = "Lap Dell Vostro";
            TempData["truong"] = "Truong dai hoc Nguyen Trai - NTU";

            return View();
        }

        public IActionResult GetProduct()
        {
            nvyproduct newproduct = new nvyproduct()
            {
                ProductID = "2410900091",
                ProductName = "Nguyen Van Yen",
                YearRelease = "2006",
                Price = "1000"
            };

            ViewBag.product = newproduct;
            ViewData["product"] = newproduct;

            return View("product");
        }
    }
}