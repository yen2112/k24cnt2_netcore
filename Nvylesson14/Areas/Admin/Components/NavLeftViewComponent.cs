using Nvylesson14.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Nvylesson14.Areas.Admin.Components
{
    public class NavLeftViewModel
    {
        public int CategoryCount { get; set; }
        public int ProductCount { get; set; }
        public int BannerCount { get; set; }
        public int BlogCount { get; set; }
        public string ActiveController { get; set; } = string.Empty;
        public string ActiveAction { get; set; } = string.Empty;
    }

    public class NavLeftViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public NavLeftViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var routeData = ViewContext.RouteData.Values;
            var currentController = routeData["controller"]?.ToString() ?? "";
            var currentAction = routeData["action"]?.ToString() ?? "";

            var model = new NavLeftViewModel
            {
                CategoryCount = await _context.Categories.CountAsync(),
                ProductCount = await _context.Products.CountAsync(),
                BannerCount = await _context.Banners.CountAsync(),
                BlogCount = await _context.Blogs.CountAsync(),
                ActiveController = currentController,
                ActiveAction = currentAction
            };

            return View(model);
        }
    }
}
