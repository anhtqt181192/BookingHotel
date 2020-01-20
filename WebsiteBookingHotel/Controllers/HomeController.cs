using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebsiteBookingHotel.Data;
using WebsiteBookingHotel.Models;

namespace WebsiteBookingHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                ViewData["WebsiteInfo"] = _context.WebsiteInfo.Find(1);
                ViewData["Welcome"] = _context.WebsiteInfo.Find(1).Note;
                ViewBag.Banner = _context.ImageCollection.Where(c => c.Tag == "banner").FirstOrDefault();
                ViewBag.Room = _context.Room.ToList();
            }
            catch (Exception e)
            {

            }
            return View();
        }

        [Route("BLog")]
        [Route("Bai-Viet")]
        [Route("Tin-Tuc")]
        public IActionResult Blog()
        {
            ViewData["WebsiteInfo"] = _context.WebsiteInfo.Find(1);
            ViewData["Welcome"] = _context.WebsiteInfo.Find(1).Note;
            ViewBag.Banner = _context.ImageCollection.Where(c => c.Tag == "banner").FirstOrDefault();
            ViewBag.Room = _context.Room.ToList();
            return View(_context.Blog.ToList());
        }

        [Route("BLog/{alias}")]
        [Route("Bai-Viet/{alias}")]
        [Route("Tin-Tuc/{alias}")]
        public IActionResult BlogDetails(string alias)
        {
            ViewData["WebsiteInfo"] = _context.WebsiteInfo.Find(1);
            ViewData["Welcome"] = _context.WebsiteInfo.Find(1).Note;
            ViewBag.Banner = _context.ImageCollection.Where(c => c.Tag == "banner").FirstOrDefault();
            ViewBag.Room = _context.Room.ToList();
            return View(_context.Blog.Where(c => c.Alias.ToLower() == alias.ToLower()).FirstOrDefault());
        }

        [Route("Lien-He")]
        public IActionResult Contact()
        {
            try
            {
                ViewData["WebsiteInfo"] = _context.WebsiteInfo.Find(1);
                ViewData["Welcome"] = _context.WebsiteInfo.Find(1).Note;
                ViewBag.Banner = _context.ImageCollection.Where(c => c.Tag == "banner").FirstOrDefault();
                ViewBag.Room = _context.Room.ToList();
            }
            catch (Exception e)
            {

            }
            return View();
        }

        [Route("Gioi-Thieu")]
        public IActionResult Detail()
        {
            try
            {
                ViewData["WebsiteInfo"] = _context.WebsiteInfo.Find(1);
                ViewData["websiteName"] = _context.WebsiteInfo.Find(1).Name;
                ViewData["Welcome"] = _context.WebsiteInfo.Find(1).Note;
                ViewBag.Banner = _context.ImageCollection.Where(c => c.Tag == "banner").FirstOrDefault();
                ViewBag.Room = _context.Room.ToList();
            }
            catch (Exception e)
            {

            }
            return View();
        }

        [Route("Thu-Vien-Anh")]
        public IActionResult Gallery()
        {
            try
            {
                ViewData["WebsiteInfo"] = _context.WebsiteInfo.Find(1);
                ViewData["websiteName"] = _context.WebsiteInfo.Find(1).Name;
                ViewData["Welcome"] = _context.WebsiteInfo.Find(1).Note;
                ViewBag.Banner = _context.ImageCollection.Where(c => c.Tag == "banner").FirstOrDefault();
                ViewBag.Room = _context.Room.ToList();
            }
            catch (Exception e)
            {

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
