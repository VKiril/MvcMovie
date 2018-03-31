using MFile = MvcMovie.Models.File;
using SPath = System.IO.Path;
using MvcMovie.Models;
using System.Web;

namespace MvcMovie.Services
{
    public class FileUpload
    {
        /// <summary>
        /// Store uploaded file into project database as binary string 
        /// </summary>
        /// <param name="upload"> Uploaded file </param>
        /// <returns></returns>
        public static MFile StoreIntoDatabase(HttpPostedFileBase upload)
        {
            var avatar = new MFile
            {
                FileName = System.IO.Path.GetFileName(upload.FileName),
                FileType = FileType.Avatar,
                ContentType = upload.ContentType
            };

            using (var renderer = new System.IO.BinaryReader(upload.InputStream))
            {
                avatar.Content = renderer.ReadBytes(upload.ContentLength);
            }

            return avatar;
        }

        /// <summary>
        /// Store uploaded file on server folder as file 
        /// </summary>
        /// <param name="upload"> Uploaded file </param>
        /// <returns></returns>
        public static FilePath StoreOnServer(HttpPostedFileBase upload)
        {
            var filePath = HttpContext.Current.Server.MapPath("../UploadedImages/");
            var fullPath = SPath.Combine(filePath, upload.FileName);
            fullPath = fullPath.Replace("\\", "/");

            upload.SaveAs(fullPath);

            var photo = new FilePath
            {
                FileName = System.IO.Path.GetFileName(fullPath),
                FileType = FileType.Photo
            };

            return photo;
        }
    }
}