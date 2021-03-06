﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBookingHotel.Data;

namespace WebsiteBookingHotel.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnvironment;

        public ServicesController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public IActionResult BookingRoom(string email, DateTime? fromDate, DateTime? toDate, int idRoom, string typeRoom, int unitCustomer, int unitChilrend)
        {
            try
            {
                Booking booking = new Booking();
                booking.Email = email;
                booking.FromDate = fromDate.HasValue ? fromDate.Value : DateTime.Now;
                booking.ToDate = toDate.HasValue ? toDate.Value : DateTime.Now;
                booking.IdRoom = idRoom;
                booking.Adults = unitCustomer;
                booking.Children = unitChilrend;
                booking.Note = typeRoom;
                _context.Booking.Add(booking);
                _context.SaveChanges();
                return Json(true);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UploadImgAsync(IFormFile file)
        {
            if (file == null)
            {
                return Json(false);
            }
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath) + "\\Upload\\Img";
            var fileName = file.FileName;
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            using (FileStream stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Json("/Upload/Img/" + fileName);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UploadMutipleImgAsync(IList<IFormFile> file)
        {
            string r = "";
            if (file == null)
            {
                return Json(false);
            }
            foreach(var item in file)
            {
                if (r != "")
                {
                    r += ",";
                }
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath) + "\\Upload\\Img";
                var fileName = item.FileName;
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                using (FileStream stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }
                r += "/Upload/Img/" + fileName;
            }
            return Json(r);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UploadBannerAsync(IFormFile file)
        {
            if (file == null)
            {
                return Json(false);
            }
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath) + "\\Upload\\Img";
            var fileName = file.FileName;
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            using (FileStream stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
                ImageCollection image = _context.ImageCollection.Where(c => c.Tag == "banner").FirstOrDefault();
                image.Tag = "banner";
                image.Link = "/Upload/Img/" + fileName;
                _context.ImageCollection.Update(image);
                _context.SaveChanges();
            }
            return Json("/Upload/Img/" + fileName);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UploadLogoAsync(IFormFile file)
        {
            if (file == null)
            {
                return Json(false);
            }
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath) + "\\Upload\\Img";
            var fileName = file.FileName;
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            using (FileStream stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
                WebsiteInfo websiteInfo = _context.WebsiteInfo.Find(1);
                websiteInfo.Logo = "/Upload/Img/" + fileName;
                _context.WebsiteInfo.Update(websiteInfo);
                _context.SaveChanges();
            }
            return Json("/Upload/Img/" + fileName);
        }
    }
}
