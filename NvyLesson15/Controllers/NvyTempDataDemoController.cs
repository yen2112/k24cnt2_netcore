using Microsoft.AspNetCore.Mvc;

namespace NvyLesson15.Controllers
{
    public class NvyTempDataDemoController : Controller
    {
        public IActionResult Index()
        {
            // TempData is read here in View or Controller
            return View();
        }

        [HttpPost]
        public IActionResult SaveData(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                TempData["ErrorMessage"] = "Nội dung thông báo không được để trống!";
            }
            else
            {
                // Set TempData for Post-Redirect-Get pattern
                TempData["SuccessMessage"] = $"Xử lý thành công! Dữ liệu đã chuyển qua Redirect: '{message}'";
                TempData["CreateTime"] = DateTime.Now.ToString("HH:mm:ss");
            }

            return RedirectToAction("Index");
        }

        public IActionResult TestKeep()
        {
            TempData["PersistentMsg"] = "Thông báo này sẽ được giữ lại qua 2 lần Request nhờ TempData.Keep()!";
            return RedirectToAction("ShowKeep");
        }

        public IActionResult ShowKeep()
        {
            // Keep TempData value for subsequent request
            TempData.Keep("PersistentMsg");
            return View();
        }
    }
}
