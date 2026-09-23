using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nvylesson09.Models.DataModels;

namespace nvylesson09.Controllers
{
    public class NvyMemberController : Controller
    {
        private List<NvyMember> nvyMember = new List<NvyMember>();
        // GET: NvyMemberController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NvyMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NvyMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NvyMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NvyMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NvyMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NvyMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NvyMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
