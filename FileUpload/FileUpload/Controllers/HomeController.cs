using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        private readonly string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    // Get file extension
                    string fileExtension = Path.GetExtension(file.FileName).ToLower();

                    // Validate file extension
                    if (Array.Exists(allowedExtensions, ext => ext.Equals(fileExtension)))
                    {
                        // Generate a unique filename
                        string filename = Path.GetFileName(file.FileName);
                        string uniqueFilename = Guid.NewGuid().ToString() + "_" + filename;

                        // Define the path to save the file
                        string uploadsPath = Path.Combine(Server.MapPath("~/Uploads"), uniqueFilename);

                        // Ensure the directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(uploadsPath));

                        // Save the file
                        file.SaveAs(uploadsPath);

                        // Generate the URL for the uploaded file
                        string imageUrl = Url.Content("~/Uploads/" + uniqueFilename);

                        ViewBag.Message = "Image uploaded successfully.";
                        ViewBag.ImageUrl = imageUrl;
                    }
                    else
                    {
                        ViewBag.Message = "Invalid file type. Only image files are allowed.";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = $"File upload failed: {ex.Message}";
                }
            }
            else
            {
                ViewBag.Message = "No file uploaded.";
            }

            return View();
        }
    }
}
