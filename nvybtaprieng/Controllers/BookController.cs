using Microsoft.AspNetCore.Mvc;
using nvybtaprieng.Models;
using System.Linq;

namespace nvybtaprieng.Controllers
{
    public class BookController : Controller
    {
        protected Book book = new Book();

        public IActionResult Index(int? authorId, int? genreId)
        {
            // danh sách authors & genres SelectListItem để hiển thị trên combobox
            ViewBag.authors = book.Authors; // truyền dữ liệu SelectListItem qua view
            ViewBag.genres = book.Genres;   // truyền dữ liệu SelectListItem qua view

            var books = book.GetBookList();

            if (authorId.HasValue && authorId.Value > 0)
            {
                books = books.Where(b => b.AuthorId == authorId.Value).ToList();
            }

            if (genreId.HasValue && genreId.Value > 0)
            {
                books = books.Where(b => b.GenreId == genreId.Value).ToList();
            }

            return View(books); // truyền dữ liệu qua view dưới dạng tham số
        }

        public IActionResult Create()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book newBook)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            return View(newBook);
        }

        public IActionResult Edit(int id)
        {
            var b = book.GetBookById(id);
            if (b == null)
            {
                return NotFound();
            }

            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            return View(b);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book updatedBook)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            return View(updatedBook);
        }
    }
}
