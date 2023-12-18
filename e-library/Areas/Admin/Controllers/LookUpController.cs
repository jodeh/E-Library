using e_library.Models.Repositories;
using e_library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Runtime.InteropServices;
using e_library.ViewModels;

namespace e_library.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LookUpController : Controller
    {
        // GET: LookUpController
        public IRepository<LookupMediaType> LookupMediaType { get; }
        public IHostingEnvironment Host { get; }
        public LookUpController(IRepository<LookupMediaType> _LookupMediaType, IHostingEnvironment _Host)
        {
            LookupMediaType= _LookupMediaType;
            Host= _Host;
        }
        public ActionResult Index()
        {

            return View(LookupMediaType.View());
        }

        // GET: LookUpController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LookUpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LookUpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LookupMediaType collection)
        {
            try
            {
                LookupMediaType Lup = new LookupMediaType
                {
                    LookupMediaTypeId = collection.LookupMediaTypeId,
                    LookupMediaTypeName = collection.LookupMediaTypeName,
                };
                LookupMediaType.Add(Lup);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LookUpController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LookUpController/Edit/5
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

        // GET: LookUpController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LookUpController/Delete/5
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
