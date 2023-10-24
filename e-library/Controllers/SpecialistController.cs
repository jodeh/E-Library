using e_library.Models;
using e_library.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace e_library.Controllers
{
    public class SpecialistController : Controller
    {
        // GET: SpecialistController
        public IRepository<Specialist> Specialists { get; }
        public SpecialistController(IRepository<Specialist> _specialists)
        {
            Specialists = _specialists;
        }

        public ActionResult Index()
        {
            var data = Specialists.View();

            return View(data);
        }

        // GET: SpecialistController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpecialistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialistController/Create
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

        // GET: SpecialistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpecialistController/Edit/5
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

        // GET: SpecialistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpecialistController/Delete/5
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
