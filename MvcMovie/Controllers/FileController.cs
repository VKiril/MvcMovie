using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class FileController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        /// <summary>
        /// Index action function
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            var fileToRetreive = db.Files.Find(id);
            System.Console.WriteLine("test");
            return File(fileToRetreive.Content, fileToRetreive.ContentType);
        }

        public ActionResult LoadImage(string name, int id)
        {
            var fileToRetreive = db.FilePaths.Find(id);
            var filePath = Server.MapPath("../UploadedImages/") + fileToRetreive.FileName;
            return File(filePath, System.IO.Path.GetExtension(fileToRetreive.FileName));
        }
    }
}