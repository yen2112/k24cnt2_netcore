using System;
using System.IO;
using System.Linq;
using lesson04.lad.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace lesson04.lad.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PeopleController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: PeopleController
        public IActionResult Index()
        {
            var _peoples = DataLocal.GetPeoples();
            return View(_peoples);
        }

        // GET: PeopleController/Details/5
        public IActionResult Details(int id)
        {
            var people = DataLocal.GetPeopleById(id);
            if (people == null)
            {
                return NotFound();
            }
            return View(people);
        }

        // GET: PeopleController/Create
        public IActionResult Create()
        {
            var people = new People();
            return View(people);
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(People model)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var fileName = Path.GetFileName(file.FileName);
                    var avatarFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "avatar");
                    if (!Directory.Exists(avatarFolder))
                    {
                        Directory.CreateDirectory(avatarFolder);
                    }
                    var filePath = Path.Combine(avatarFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    model.Avatar = "images/avatar/" + fileName;
                }
                else if (string.IsNullOrEmpty(model.Avatar))
                {
                    model.Avatar = "images/avatar/01.jpg";
                }

                model.Id = DataLocal._peoples.Count > 0 ? DataLocal._peoples.Max(x => x.Id) + 1 : 1;
                DataLocal._peoples.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(model);
            }
        }

        // GET: PeopleController/Edit/5
        public IActionResult Edit(int id)
        {
            var people = DataLocal.GetPeopleById(id);
            if (people == null)
            {
                return NotFound();
            }
            return View(people);
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, People model)
        {
            try
            {
                var existingPeople = DataLocal.GetPeopleById(id);
                if (existingPeople == null)
                {
                    return NotFound();
                }

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var fileName = Path.GetFileName(file.FileName);
                    var avatarFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "avatar");
                    if (!Directory.Exists(avatarFolder))
                    {
                        Directory.CreateDirectory(avatarFolder);
                    }
                    var filePath = Path.Combine(avatarFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    model.Avatar = "images/avatar/" + fileName;
                }
                else
                {
                    model.Avatar = existingPeople.Avatar;
                }

                for (int i = 0; i < DataLocal._peoples.Count; i++)
                {
                    if (DataLocal._peoples[i].Id == id)
                    {
                        DataLocal._peoples[i] = model;
                        break;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(model);
            }
        }

        // GET: PeopleController/Delete/5
        public IActionResult Delete(int id)
        {
            var people = DataLocal.GetPeopleById(id);
            if (people == null)
            {
                return NotFound();
            }
            return View(people);
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, People model)
        {
            try
            {
                for (int i = 0; i < DataLocal._peoples.Count; i++)
                {
                    if (DataLocal._peoples[i].Id == id)
                    {
                        DataLocal._peoples.RemoveAt(i);
                        break;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
