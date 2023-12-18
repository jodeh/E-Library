using e_library.Models.Repositories;
using e_library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace e_library.Controllers
{
    public class SubjectController : Controller
    {
        public IRepository<Subject> Subjects { get;  }
        public IRepository<Specialist> Specialists { get; }
        public IHostingEnvironment Host { get; }
        IRepository<SubjectFiles> SubjectFiles { get; }
        IRepository<LookupMediaType> LookupMediaType { get; }

        // GET: SubjectController
        public SubjectController(IRepository<Subject> _Subjects, IRepository<Specialist> _Specialists, IHostingEnvironment _Host, IRepository<SubjectFiles> _subjectFiles, IRepository<LookupMediaType> _lookupMediaType)
        {
            Subjects = _Subjects;
            Specialists = _Specialists;
            Host = _Host;
            SubjectFiles = _subjectFiles;
            LookupMediaType = _lookupMediaType;
        }
        public ActionResult Index()
        {

            return View(Subjects.View());
        }

        // GET: SubjectController/Details/5
        public ActionResult pdfs(int id)
        {


            var data = Subjects.Find(id);
            IEnumerable<SubjectFiles> _SUbjects = SubjectFiles.View();
            var obj = _SUbjects.Where(x => x.LookupMediaTypeId == 1 && x.SubjectId==data.SubjectId);


            return View(obj);
        }

        // GET: SubjectController/Create
        public ActionResult Vedios()
        {
            return View();
        }

        // POST: SubjectController/Create
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

        // GET: SubjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubjectController/Edit/5
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

        // GET: SubjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubjectController/Delete/5
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
