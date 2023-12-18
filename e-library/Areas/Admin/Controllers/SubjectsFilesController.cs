using e_library.Models.Repositories;
using e_library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using e_library.ViewModels;
using System.IO;
using System;

namespace e_library.Area.Admin.Controlers
{
    [Area("Admin")]
    public class SubjectsFilesController : Controller
    {
        public IRepository<SubjectFiles> Subjectfiles { get; }
        public IRepository<Subject> Subjects { get; }
        public IRepository<LookupMediaType> LookupMediaType { get; }
        public IHostingEnvironment Host { get; }
       
        public SubjectsFilesController(IRepository<SubjectFiles> subjectfiles, IRepository<Subject> subjects, IRepository<LookupMediaType> _LookupMediaType, IHostingEnvironment host)
        {
            Subjectfiles = subjectfiles;
            Subjects = subjects;
            Host = host;
            LookupMediaType = _LookupMediaType;
        }

        // GET: SubjectsFilesController

        public ActionResult Index()
        {


            return View(Subjectfiles.View());
        }

        // GET: SubjectsFilesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Subjectfiles.Find(id);
            return View(data);
        }

        // GET: SubjectsFilesController/Create
        public ActionResult Create()
        {
            ViewBag.Listsub = Subjects.View();
            ViewBag.ListLuk = LookupMediaType.View();

            return View();
            
        }

        // POST: SubjectsFilesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectFilesViewModel collection)
        {
            try

            {
                string ImageName = "";

                if (collection.LookupMediaTypeId== 2)
                {
                    ImageName = collection.SubjectFileURLOthers;
                }
                else
                {
                    if (collection.File != null)
                    {
                        string pathImage = Path.Combine(Host.WebRootPath, "Images");
                        FileInfo f = new FileInfo(collection.File.FileName);
                        ImageName = "Pdf" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "")
                            .Replace(" ", "") + f.Extension;
                        string FullPath = Path.Combine(pathImage, ImageName);
                        collection.File.CopyTo(new FileStream(FullPath, FileMode.Create));


                    }
                }

              

                SubjectFiles Sub = new SubjectFiles
                {

                    SubjectFileId = collection.SubjectFileId,
                    

                    SubjectDescription=collection.SubjectDescription,

                    SubjectFileName=collection.SubjectFileName,

                    SubjectId=collection.SubjectId,
                    
                    Type=collection.Type,
                    
                    
                    

                    SubjectFileURL= ImageName,
                    LookupMediaTypeId= collection.LookupMediaTypeId,
                    SubjectFileURLOthers=collection.SubjectFileURLOthers,


                };



                Subjectfiles.Add(Sub);

                return RedirectToAction(nameof(Index));



            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectsFilesController/Edit/5
        public ActionResult Edit(int id)
        {

            ViewBag.Listsub = Subjects.View();

            var data = Subjectfiles.Find(id);
            SubjectFilesViewModel obj = new SubjectFilesViewModel();
            obj.SubjectId = data.SubjectId; ;
            obj.SubjectFileId = data.SubjectFileId;
            obj.SubjectFileName = data.SubjectFileName;
            obj.SubjectDescription = data.SubjectDescription;
            obj.Type = data.Type;
            obj.SubjectFileURL= data.SubjectFileURL;
            return View(obj);
            

            
        }

        // POST: SubjectsFilesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SubjectFilesViewModel collection)
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
                SubjectFiles sub = new SubjectFiles {

                SubjectId=collection.SubjectId,
                SubjectFileId=collection.SubjectFileId,
                SubjectFileName=collection.SubjectFileName,
                SubjectDescription=collection.SubjectDescription,
                SubjectFileURL= ImageName == "" ? collection.SubjectFileURL:ImageName,
                SubjectFileURLOthers=collection.SubjectFileURLOthers,




                };
                Subjectfiles.Update(id, sub);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectsFilesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Subjectfiles.Find(id);
            return View(data);
        }

        // POST: SubjectsFilesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SubjectFiles collection)
        {
            try
            {
                Subjectfiles.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
