using e_library.Models;
using e_library.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using e_library.ViewModels;
using System.Threading.Tasks;

namespace e_library.Controllers
{
    public class SpecialistController : Controller
    {
        // GET: SpecialistController
        public IRepository<Specialist> Specialists { get; }
        public IRepository<Subject> Subjects { get; }
        IRepository<SubjectFiles> SubjectFiles { get; }
        IRepository<LookupMediaType> LookupMediaType { get; }
        public SpecialistController(IRepository<Specialist> _specialists, IRepository<Subject> _Subjects, IRepository<SubjectFiles> _subjectFiles, IRepository<LookupMediaType> lookupMediaType)
        {
            Specialists = _specialists;
            Subjects = _Subjects;
            SubjectFiles = _subjectFiles;
            LookupMediaType = lookupMediaType;
        }

        public ActionResult Index()
        {
            var data = Specialists.View();

            return View(data);
        }

        [HttpGet]


        // GET: SpecialistController/Details/5
        public ActionResult Details(int id)
        {
            
            var data = Specialists.Find(id);
            IEnumerable<Subject> _SUbjects =  Subjects.View();
            var obj = _SUbjects.Where(x => x.SpecialistId == data.SpecialistId);
            

            return View(obj);

       
        }
        public ActionResult Search(string entity)
        {
            var obj=Specialists.Search(entity);

            return View("Index", obj);
        }

        public ActionResult pdfs(int id)
        {


            var data = Subjects.Find(id);
            IEnumerable<SubjectFiles> _SUbjects = SubjectFiles.View();
            var obj = _SUbjects.Where(x => x.LookupMediaTypeId == 1 && x.SubjectId == data.SubjectId);


            return View(obj);
        } 
        public ActionResult videos(int id)
        {


            var data = Subjects.Find(id);
            IEnumerable<SubjectFiles> _SUbjects = SubjectFiles.View();
            var obj = _SUbjects.Where(x => x.LookupMediaTypeId == 2 && x.SubjectId == data.SubjectId);


            return View(obj);
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
