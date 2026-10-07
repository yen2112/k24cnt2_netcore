using Nvylesson14.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Nvylesson14.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Blog
        public async Task<IActionResult> Index(string? searchString)
        {
            var query = _context.Blogs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(b => b.Name.Contains(searchString) || (b.Description != null && b.Description.Contains(searchString)));
            }

            ViewBag.SearchString = searchString;
            var blogs = await query.OrderByDescending(b => b.CreatedDate).ThenByDescending(b => b.Id).ToListAsync();
            return View(blogs);
        }

        // GET: Admin/Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var blog = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null) return NotFound();

            return View(blog);
        }

        // GET: Admin/Blog/Create
        public IActionResult Create()
        {
            return View(new Blog { CreatedDate = DateTime.Now, Status = 1 });
        }

        // POST: Admin/Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Status,CreatedDate,Image,Description")] Blog blog)
        {
            if (await _context.Blogs.AnyAsync(b => b.Name.ToLower() == blog.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Tiêu đề bài viết này đã tồn tại trong hệ thống.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Đã thêm bài viết '{blog.Name}' thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Admin/Blog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return NotFound();

            return View(blog);
        }

        // POST: Admin/Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,CreatedDate,Image,Description")] Blog blog)
        {
            if (id != blog.Id) return NotFound();

            if (await _context.Blogs.AnyAsync(b => b.Id != id && b.Name.ToLower() == blog.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Tiêu đề bài viết này đã tồn tại ở bản ghi khác.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"Cập nhật bài viết '{blog.Name}' thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Admin/Blog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var blog = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null) return NotFound();

            return View(blog);
        }

        // POST: Admin/Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Đã xóa bài viết '{blog.Name}' thành công!";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }
    }
}
