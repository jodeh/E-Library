using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_library.Controllers
{
    public class SubFilesController : Controller
    {
        // GET: SubFilesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubFilesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubFilesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubFilesController/Create
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

        // GET: SubFilesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubFilesController/Edit/5
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

        // GET: SubFilesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubFilesController/Delete/5
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
