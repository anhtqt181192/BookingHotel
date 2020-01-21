using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsiteBookingHotel.Data;

namespace WebsiteBookingHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GaleryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnvironment;

        public GaleryController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
    }

        public IActionResult Index()
        {
            return View(_context.ImageCollection.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> UploadImgGalleryAsync(IList<IFormFile> files, string title, string tag)
        {
            try
            {
                foreach (var file in files)
                {
                    ImageCollection collection = new ImageCollection();

                    if (file == null)
                    {
                        return Json(false);
                    }

                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath) + "\\Upload\\Img";
                    var fileName = file.FileName;

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    using (FileStream stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    collection.Link = "/Upload/Img/" + fileName;
                    collection.Tag = tag;
                    collection.Title = title;
                    _context.ImageCollection.Add(collection);
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(false);
            }

            return Json(true);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            try
            {
                ImageCollection collection = _context.ImageCollection.Find(Id);
                _context.ImageCollection.Remove(collection);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(false);
            }

            return Json(true);
        }
    }
}