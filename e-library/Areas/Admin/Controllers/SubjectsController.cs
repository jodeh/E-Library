using e_library.Models.Repositories;
using e_library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using e_library.ViewModels;

namespace e_library.Area.Admin.Controlers
{
    [Area("Admin")]
    public class SubjectsController : Controller
    {
        public IRepository<Subject> Subjects { get; }
        public IRepository<Specialist> Specialists { get; }
        public IHostingEnvironment Host { get; }

        public SubjectsController(IRepository<Subject> _Subjects, IRepository<Specialist> _Specialists, IHostingEnvironment _Host)
        {
            Subjects = _Subjects;
            Specialists = _Specialists;
            Host = _Host;
        }
        // GET: SubjectsController
        public ActionResult Index()
        {

            return View(Subjects.View());
        }

        // GET: SubjectsController/Details/5
        public ActionResult Details(int id)
        {
            var data = Subjects.Find(id);
            return View(data);

        }

        // GET: SubjectsController/Create
        public ActionResult Create()
        {

            ViewBag.Listsp = Specialists.View();
            return View();
        }

        // POST: SubjectsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectViewModel collection)

        {
            try
            {
                string ImageName = "";

                if (collection.File != null)
                {
                    string pathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo f = new FileInfo(collection.File.FileName);
                    ImageName = "Image" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "")
                        .Replace(" ", "") + f.Extension;
                    string FullPath = Path.Combine(pathImage, ImageName);
                    collection.File.CopyTo(new FileStream(FullPath, FileMode.Create));


                }

                Subject Sub = new Subject
                {

                    SpecialistId = collection.SpecialistId,

                    SubjectId = collection.SubjectId,

                    SubjectImageurl = ImageName,
                    SubjectName = collection.SubjectName



                };



                Subjects.Add(Sub);

                return RedirectToAction(nameof(Index));



            }
            catch
            {
                return View();
            }
        }



        // GET: SubjectsController/Edit/5
        public ActionResult Edit(int id)
        {

            var data = Subjects.Find(id);
            SubjectViewModel obj= new SubjectViewModel();
            obj.SubjectId = data.SubjectId;
            obj.SubjectName = data.SubjectName;
            obj.SubjectImageurl = data.SubjectImageurl;
            return View(obj);
        }

        // POST: SubjectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SubjectViewModel collection)
        {

            try
            {
                string ImageName = "";

                if (collection.File != null)
                {
                    string pathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo f = new FileInfo(collection.File.FileName);
                    ImageName = "Image" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "")
                        .Replace(" ", "") + f.Extension;
                    string FullPath = Path.Combine(pathImage, ImageName);
                    collection.File.CopyTo(new FileStream(FullPath, FileMode.Create));


                }

                Subject Sub = new Subject
                {
                    SubjectId=collection.SubjectId,
                    SpecialistId = collection.SpecialistId,

                    SubjectName = collection.SubjectName,

                    SubjectImageurl = ImageName,



                };



                Subjects.Update(id, Sub);

                return RedirectToAction(nameof(Index));



            }
            catch
            {
                return View();
            }
        }

    

    // GET: SubjectsController/Delete/5
    public ActionResult Delete(int id)
        {

            return View(Subjects.Find(id));
        }

        // POST: SubjectsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Subject collection)
        {
            try
            {
                Subjects.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

