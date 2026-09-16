using System;
using System.IO;
using lesson04.lad.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lesson04.lad.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: ProductController
        public IActionResult Index()
        {
            var products = ProductDataLocal.GetProducts();
            ViewBag.Categories = ProductDataLocal.GetCategories();
            return View(products);
        }

        // GET: ProductController/Details/5
        public IActionResult Details(int id)
        {
            var product = ProductDataLocal.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.CategoryName = ProductDataLocal.GetCategories().Find(c => c.Id == product.CategoryId)?.Name ?? "Chưa xếp loại";
            return View(product);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(ProductDataLocal.GetCategories(), "Id", "Name");
            var product = new Product { CreatedDate = DateTime.Now, Status = true };
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product model)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var fileName = Path.GetFileName(file.FileName);
                    var productFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");
                    if (!Directory.Exists(productFolder))
                    {
                        Directory.CreateDirectory(productFolder);
                    }
                    var filePath = Path.Combine(productFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    model.Image = "images/products/" + fileName;
                }
                else if (string.IsNullOrEmpty(model.Image))
                {
                    model.Image = "images/products/product1.jpg";
                }

                ProductDataLocal.AddProduct(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                ViewBag.Categories = new SelectList(ProductDataLocal.GetCategories(), "Id", "Name", model.CategoryId);
                return View(model);
            }
        }

        // GET: ProductController/Edit/5
        public IActionResult Edit(int id)
        {
            var product = ProductDataLocal.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(ProductDataLocal.GetCategories(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product model)
        {
            try
            {
                var existingProduct = ProductDataLocal.GetProductById(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var fileName = Path.GetFileName(file.FileName);
                    var productFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");
                    if (!Directory.Exists(productFolder))
                    {
                        Directory.CreateDirectory(productFolder);
                    }
                    var filePath = Path.Combine(productFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    model.Image = "images/products/" + fileName;
                }
                else
                {
                    model.Image = existingProduct.Image;
                }

                ProductDataLocal.UpdateProduct(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                ViewBag.Categories = new SelectList(ProductDataLocal.GetCategories(), "Id", "Name", model.CategoryId);
                return View(model);
            }
        }

        // GET: ProductController/Delete/5
        public IActionResult Delete(int id)
        {
            var product = ProductDataLocal.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.CategoryName = ProductDataLocal.GetCategories().Find(c => c.Id == product.CategoryId)?.Name ?? "Chưa xếp loại";
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Product model)
        {
            try
            {
                ProductDataLocal.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
