using Microsoft.AspNetCore.Mvc;
using nvylessson6.Models;
using System.Collections.Generic;
using System.Linq;

namespace nvylessson6.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int? n)
        {
            List<Category> categories = new List<Category>()
            {
                new Category { CategoryId = 1, CategoryName = "Điện tử" },
                new Category { CategoryId = 2, CategoryName = "Điện lạnh" },
                new Category { CategoryId = 3, CategoryName = "Đồ gia dụng" },
                new Category { CategoryId = 4, CategoryName = "Tiện ích" },
            };

            int limit = n ?? 0;
            var search = categories.Where(x => x.CategoryId > limit);
            return View(search);
        }
    }
}
