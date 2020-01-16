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

        public IActionResult Index()
        {
            return View();
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
    }
}