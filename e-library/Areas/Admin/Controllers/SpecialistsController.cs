using e_library.Models;
using e_library.Models.Repositories;
using e_library.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace e_library.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialistsController : Controller
    {
        // GET: SpecialistController
        public IRepository<Specialist> Specialists { get; }
        public IHostingEnvironment Host { get; }
        public SpecialistsController(IRepository<Specialist> _specialists, IHostingEnvironment _Host)
        {
            
            Specialists = _specialists;
                Host = _Host;
        }

        public ActionResult Index()
        {
            var data = Specialists.View();

            return View(data);
        }

        // GET: SpecialistController/Details/5
        public ActionResult Details(int id)
        {
            var data = Specialists.Find(id);
            return View(data);
        }

        // GET: SpecialistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpecialistViewModel collection)
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

                Specialist Sp = new Specialist
                {

                    SpecialistId = collection.SpecialistId,

                    SpecialistName = collection.SpecialistName,
                   
                    SpecialestImageurl = ImageName,



                };



                Specialists.Add(Sp);

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
            var data = Specialists.Find(id);
            SpecialistViewModel obj = new SpecialistViewModel ();
            obj.SpecialistId = data.SpecialistId;
            obj.SpecialistName= data.SpecialistName;
            obj.SpecialestImageurl= data.SpecialestImageurl;

            return View(obj);
        }

        // POST: SpecialistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SpecialistViewModel collection)
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

                Specialist Sp = new Specialist
                {

                    SpecialistId = collection.SpecialistId,

                    SpecialistName = collection.SpecialistName,

                    SpecialestImageurl = ImageName,



                };



                Specialists.Update(id,Sp);

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

            var data = Specialists.Find(id);
            return View(data);
        }

        // POST: SpecialistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Specialist collection)
        {
            try
            {
                Specialists.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
