using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Models
{
    public class FileUploadController : Controller
    {
        //  https://www.mikesdotnetting.com/article/259/asp-net-mvc-5-with-ef-6-working-with-files
        // GET: FileUpload
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var photo = new FilePath
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Photo
                    };
                    //instructor.FilePaths = new List<FilePath>();
                    //instructor.FilePaths.Add(photo);
                }
                //db.Instructors.Add(instructor);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}