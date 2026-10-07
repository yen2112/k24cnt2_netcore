using Microsoft.AspNetCore.Mvc;

namespace NvyLesson15.Controllers
{
    public class NvyCookieDemoController : Controller
    {
        public IActionResult Index()
        {
            // Read Cookies from Request
            ViewBag.UserName = Request.Cookies["Nvy_UserName"] ?? "Chưa đăng nhập (Khách)";
            ViewBag.Theme = Request.Cookies["Nvy_Theme"] ?? "light";
            ViewBag.LastVisit = Request.Cookies["Nvy_LastVisit"] ?? "Lần đầu ghé thăm";

            // Record current visit in cookie
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true,
                IsEssential = true
            };
            Response.Cookies.Append("Nvy_LastVisit", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), cookieOptions);

            return View();
        }

        [HttpPost]
        public IActionResult SavePreferences(string userName, string theme, bool rememberMe)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true
            };

            if (rememberMe)
            {
                // Persistent Cookie (hạn 30 ngày)
                cookieOptions.Expires = DateTime.Now.AddDays(30);
            }

            if (!string.IsNullOrEmpty(userName))
            {
                Response.Cookies.Append("Nvy_UserName", userName, cookieOptions);
            }

            if (!string.IsNullOrEmpty(theme))
            {
                Response.Cookies.Append("Nvy_Theme", theme, cookieOptions);
            }

            TempData["Success"] = "Đã lưu thông tin Cookie thành công!";
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCookie(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                Response.Cookies.Delete(key);
                TempData["Success"] = $"Đã xóa Cookie [{key}]!";
            }
            return RedirectToAction("Index");
        }
    }
}
