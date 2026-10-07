using Microsoft.AspNetCore.Mvc;

namespace NvyLesson15.Controllers
{
    public class NvyOtherStateDemoController : Controller
    {
        public IActionResult Index(string? category, string? searchKeyword, int? page)
        {
            // 1. QueryString Demo
            ViewBag.Category = category ?? "Tất cả";
            ViewBag.SearchKeyword = searchKeyword ?? "";
            ViewBag.Page = page ?? 1;

            // 2. HttpContext.Items Demo (Single Request Scope)
            HttpContext.Items["RequestStartTime"] = DateTime.Now;
            HttpContext.Items["ProcessedBy"] = "NvyOtherStateDemoController.Index";

            return View();
        }

        [HttpPost]
        public IActionResult SubmitHiddenForm(string originalId, string updatedName)
        {
            // 3. Hidden Fields Demo
            ViewBag.OriginalId = originalId;
            ViewBag.UpdatedName = updatedName;
            ViewBag.HiddenFormSubmitted = true;

            return View("Index");
        }
    }
}
