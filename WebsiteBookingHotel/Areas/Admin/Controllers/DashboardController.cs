using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebsiteBookingHotel.Data;
using WebsiteBookingHotel.Models;

namespace WebsiteBookingHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ErrorClass = "kt-hidden";
            return View(_context.WebsiteInfo.Find(1));
        }

        [HttpPost]
        public IActionResult Index(WebsiteInfo models)
        {
            try
            {
                ViewBag.ErrorClass = "kt-hidden";
                _context.WebsiteInfo.Update(models);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                ViewBag.ErrorClass = "";
                ModelState.AddModelError("500", e.Message);
            }
            return View(models);
        }

        [HttpPost]
        public IActionResult GetLogo()
        {
            return Json(_context.WebsiteInfo.Find(1).Logo);
        }

        [HttpPost]
        public IActionResult GetBanner()
        {
            return Json(_context.ImageCollection.Where(c => c.Tag == "banner").FirstOrDefault().Link);
        }

        [HttpPost]
        public IActionResult GetListBooking()
        {
            return Json(_context.Booking.Select(c => new BookingModels(c)).OrderByDescending(c => c.Id).ToList());
        }

        [HttpPost]
        public IActionResult DeleteBooking(int Id)
        {
            try
            {
                Booking r = _context.Booking.Find(Id);
                _context.Booking.Remove(r);
                _context.SaveChanges();
                return Json(true);
            }
            catch (Exception e)
            {
                ViewBag.ErrorClass = "";
                return Json(false);
            }
        }
        

        public IActionResult ListRoom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetListRoom()
        {
            return Json(_context.Room.ToList());
        }

        [HttpGet]
        public IActionResult CreateRoom()
        {
            ViewBag.ErrorClass = "kt-hidden";
            return View(new RoomModels());
        }

        [HttpPost]
        public IActionResult CreateRoom(RoomModels models)
        {
            ViewBag.ErrorClass = "";
            try
            {
                _context.Room.Add(models.GetRoom());
                _context.SaveChanges();
                return Redirect("/Admin/Dashboard/ListRoom");
            }
            catch(Exception e)
            {
                ViewBag.ErrorClass = "kt-hidden";
                return View(models);
            }
        }


        [HttpGet]
        public IActionResult EditRoom(int Id)
        {
            ViewBag.ErrorClass = "kt-hidden";
            return View(new RoomModels(_context.Room.Find(Id)));
        }

        [HttpPost]
        public IActionResult EditRoom(RoomModels models)
        {
            ViewBag.ErrorClass = "kt-hidden";
            try
            {
                _context.Room.Update(models.GetRoom());
                _context.SaveChanges();
                return Redirect("/Admin/Dashboard/ListRoom");
            }
            catch (Exception e)
            {
                ViewBag.ErrorClass = "";
                return View(models);
            }
        }

        [HttpPost]
        public IActionResult DeleteRoom(int Id)
        {
            ViewBag.ErrorClass = "kt-hidden";
            try
            {
                Room r = _context.Room.Find(Id);
                _context.Room.Remove(r);
                _context.SaveChanges();
                return Json(true);
            }
            catch (Exception e)
            {
                ViewBag.ErrorClass = "";
                return Json(false);
            }
        }

        public IActionResult Booking()
        {
            return View();
        }
    }
}