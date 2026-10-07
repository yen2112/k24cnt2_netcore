using Microsoft.AspNetCore.Mvc;
using NvyLesson15.Extensions;
using NvyLesson15.Models;

namespace NvyLesson15.Controllers
{
    public class NvySessionDemoController : Controller
    {
        private static readonly List<Product> SampleProducts = new()
        {
            new Product { Id = 101, Name = "Laptop Dell XPS 15", Price = 35000000, ImageUrl = "https://picsum.photos/200?1" },
            new Product { Id = 102, Name = "iPhone 15 Pro Max", Price = 30000000, ImageUrl = "https://picsum.photos/200?2" },
            new Product { Id = 103, Name = "Bàn phím cơ Keychron K2", Price = 2200000, ImageUrl = "https://picsum.photos/200?3" },
            new Product { Id = 104, Name = "Màn hình LG 27 inch 4K", Price = 9500000, ImageUrl = "https://picsum.photos/200?4" }
        };

        public IActionResult Index()
        {
            // Read primitive data from Session
            ViewBag.SessionId = HttpContext.Session.Id;
            ViewBag.Counter = HttpContext.Session.GetInt32("Nvy_VisitCount") ?? 0;
            
            // Increment counter in session
            int newCount = (ViewBag.Counter as int? ?? 0) + 1;
            HttpContext.Session.SetInt32("Nvy_VisitCount", newCount);
            ViewBag.Counter = newCount;

            // Read complex object from Session using extension method
            var currentUser = HttpContext.Session.Get<UserLogin>("USER_SESSION");
            ViewBag.CurrentUser = currentUser;

            // Read Cart from Session
            var cart = HttpContext.Session.Get<List<CartItem>>("CART_SESSION") ?? new List<CartItem>();
            ViewBag.Cart = cart;

            return View(SampleProducts);
        }

        [HttpPost]
        public IActionResult Login(string username, string fullName, string role)
        {
            if (string.IsNullOrEmpty(username))
            {
                TempData["Error"] = "Vui lòng nhập tên tài khoản!";
                return RedirectToAction("Index");
            }

            var user = new UserLogin
            {
                Username = username,
                FullName = string.IsNullOrEmpty(fullName) ? username : fullName,
                Email = $"{username}@devmaster.edu.vn",
                Role = string.IsNullOrEmpty(role) ? "Member" : role,
                LoginTime = DateTime.Now
            };

            // Write complex object to Session using JSON serialization
            HttpContext.Session.Set("USER_SESSION", user);

            TempData["Success"] = $"Đăng nhập Session thành công! Xin chào {user.FullName}";
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            // Remove specific item or clear session
            HttpContext.Session.Remove("USER_SESSION");
            TempData["Success"] = "Đã đăng xuất khỏi Session!";
            return RedirectToAction("Index");
        }

        public IActionResult AddToCart(int id)
        {
            var product = SampleProducts.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                var cart = HttpContext.Session.Get<List<CartItem>>("CART_SESSION") ?? new List<CartItem>();
                var item = cart.FirstOrDefault(c => c.Product.Id == id);
                if (item != null)
                {
                    item.Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { Product = product, Quantity = 1 });
                }

                // Update session
                HttpContext.Session.Set("CART_SESSION", cart);
                TempData["Success"] = $"Đã thêm '{product.Name}' vào giỏ hàng Session!";
            }

            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove("CART_SESSION");
            TempData["Success"] = "Đã làm trống giỏ hàng Session!";
            return RedirectToAction("Index");
        }
    }
}
