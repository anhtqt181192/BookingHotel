using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebsiteBookingHotel.Data;

namespace WebsiteBookingHotel.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Phong-Khach-San")]
        [Route("Danh-Sach-Phong")]
        public IActionResult Index()
        {
            ViewData["WebsiteInfo"] = _context.WebsiteInfo.Find(1);
            ViewData["websiteBLog"] = _context.Blog.Take(2).ToList();
            ViewBag.Banner = _context.ImageCollection.Where(c => c.Tag == "banner").FirstOrDefault();
            ViewBag.Room = _context.Room.ToList();
            return View();
        }

        [Route("Phong-Khach-San/{alias}")]
        [Route("Danh-Sach-Phong/{alias}")]
        public IActionResult Room(string alias)
        {
            ViewData["WebsiteInfo"] = _context.WebsiteInfo.Find(1);
            ViewData["websiteBLog"] = _context.Blog.Take(2).ToList();
            ViewBag.Room = _context.Room.ToList();
            ViewBag.Banner = _context.ImageCollection.Where(c => c.Tag == "banner").FirstOrDefault();
            Room models = _context.Room.Where(c => c.Alias.ToLower() == alias.ToLower()).FirstOrDefault();
            if (models == null)
                models = _context.Room.FirstOrDefault();
            return View(models);
        }
    }
}